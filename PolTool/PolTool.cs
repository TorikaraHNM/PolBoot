using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PolBoot
{
    /// <summary>
    /// POLツールクラス
    /// </summary>
    public class PolTool
    {
        private readonly Dictionary<PlatformType, PlatformInformation> PlatformInformationDictionary = new Dictionary<PlatformType, PlatformInformation>();

        /// <summary>
        /// プラットフォームごとの情報を取得
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        /// <returns>プラットフォームごとの情報</returns>
        public PlatformInformation GetInformation(PlatformType TargetPlatform) => PlatformInformationDictionary[TargetPlatform];

        /// <summary>
        /// プラットフォームごとの情報を取得
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        /// <returns>プラットフォームごとの情報</returns>
        public PlatformInformation this[PlatformType TargetPlatform] => PlatformInformationDictionary[TargetPlatform];

        private readonly string[] RegistTargets = { "FFXi.dll", "FFXiMain.dll", "FFXiVersions.dll" };

        /// <summary>
        /// POLツールクラス初期化
        /// </summary>
        public PolTool()
        {
            PlatformInformationDictionary.Add(PlatformType.JP, ReadRegistry(PlatformType.JP));
            PlatformInformationDictionary.Add(PlatformType.US, ReadRegistry(PlatformType.US));
            PlatformInformationDictionary.Add(PlatformType.EU, ReadRegistry(PlatformType.EU));
        }

        private PlatformInformation ReadRegistry(PlatformType TargetPlatform)
        {
            switch (TargetPlatform)
            {
                case PlatformType.JP:
                    return ReadRegistry("PlayOnline");
                case PlatformType.US:
                    return ReadRegistry("PlayOnlineUS");
                case PlatformType.EU:
                    return ReadRegistry("PlayOnlineEU");
                default:
                    return PlatformInformation.NotInstalled;
            }
        }

        private PlatformInformation ReadRegistry(string TargetRegistry)
        {
            try
            {
                using (var PlayOnlineRegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + TargetRegistry + @"\InstallFolder"))
                {
                    if (PlayOnlineRegKey == null) throw new ApplicationException();

                    string POL_Dir = (string)PlayOnlineRegKey.GetValue("1000");
                    string FFXI_Dir = (string)PlayOnlineRegKey.GetValue("0001");
                    bool FFXI_RoZ_Installed = FFXI_Dir != null && Directory.Exists(Path.Combine(FFXI_Dir, "ROM2"));
                    bool FFXI_CoP_Installed = FFXI_Dir != null && Directory.Exists(Path.Combine(FFXI_Dir, "ROM3"));
                    bool FFXI_ToA_Installed = FFXI_Dir != null && Directory.Exists(Path.Combine(FFXI_Dir, "ROM4"));
                    bool FFXI_WoG_Installed = FFXI_Dir != null && Directory.Exists(Path.Combine(FFXI_Dir, "ROM5"));
                    bool FFXI_SoA_Installed = FFXI_Dir != null && Directory.Exists(Path.Combine(FFXI_Dir, "ROM9"));

                    return new PlatformInformation(POL_Dir, FFXI_Dir, FFXI_RoZ_Installed, FFXI_CoP_Installed, FFXI_ToA_Installed, FFXI_WoG_Installed, FFXI_SoA_Installed);
                }
            }
            catch
            {
                return PlatformInformation.NotInstalled;
            }
        }

        /// <summary>
        /// Regsvr32で指定のプラットフォームのDLLを登録する
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        /// <param name="FailedCallback">Regsvr32失敗時のコールバック</param>
        /// <returns>成功時true</returns>
        public bool ExecRegsvr32(PlatformType TargetPlatform, Func<string, Regsvr32FailedCallbackResult> FailedCallback)
        {
            try
            {
                var TargetInformation = GetInformation(TargetPlatform);

                if (!TargetInformation.FFXI_Installed) throw new ApplicationException();

                foreach (var t in RegistTargets)
                {
                    while (!ExecRegsvr32(Path.Combine(TargetInformation.FFXI_Dir, t)))
                    {
                        switch (FailedCallback == null ? Regsvr32FailedCallbackResult.Abort : FailedCallback(t))
                        {
                            case Regsvr32FailedCallbackResult.Abort:
                                return false;
                            case Regsvr32FailedCallbackResult.Ignore:
                                goto IgnoreError;
                        }
                    }

                IgnoreError:;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ExecRegsvr32(string Target)
        {
            try
            {
                var myProsess = Exec("regsvr32", "/s \"" + Target + "\"", true);
                if (myProsess == null) throw new ApplicationException();
                myProsess.WaitForExit();
                if (myProsess.ExitCode != 0) throw new ApplicationException();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetPolFullFileName(PlatformType TargetPlatform) => Path.Combine(GetInformation(TargetPlatform).POL_Dir, "pol.exe");

        /// <summary>
        /// POLを起動する
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        /// <returns>プロセス情報</returns>
        public Process ExecPol(PlatformType TargetPlatform)
        {
            if (!GetInformation(TargetPlatform).POL_Installed) return null;

            return Exec(GetPolFullFileName(TargetPlatform));
        }

        private Process SearchPOLProcess(PlatformType TargetPlatform)
        {
            var pl = Process.GetProcessesByName("pol");
            foreach (var p in pl)
            {
                try
                {
                    if (string.Equals(p.MainModule.FileName.ToLower(), GetPolFullFileName(TargetPlatform).ToLower())) return p;
                }
                catch
                {
                }
            }
            return null;
        }

        /// <summary>
        /// POLの終了を待つ
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        public void WaitForExitPol(PlatformType TargetPlatform)
        {
            int TimeOutCounter = 0;

            while (true)
            {
                var p = SearchPOLProcess(TargetPlatform);
                if (p == null)
                {
                    TimeOutCounter++;
                    if (TimeOutCounter >= 10)
                    {
                        return;
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    TimeOutCounter = 0;
                    p.WaitForExit();
                }
            }
        }

        /// <summary>
        /// POL設定を起動する
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        /// <returns>プロセス情報</returns>
        public Process ExecPolCfg(PlatformType TargetPlatform)
        {
            if (!GetInformation(TargetPlatform).POL_Installed) return null;

            return Exec(Path.Combine(GetInformation(TargetPlatform).POL_Dir, "polcfg", "polcfg.exe"));
        }

        /// <summary>
        /// FFXI設定を起動する
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        /// <returns>プロセス情報</returns>
        public Process ExecFfxiCfg(PlatformType TargetPlatform)
        {
            if (!GetInformation(TargetPlatform).FFXI_Installed) return null;

            switch (TargetPlatform)
            {
                case PolBoot.PlatformType.JP:
                    return Exec(Path.Combine(GetInformation(TargetPlatform).FFXI_Dir, "Tools", "FINAL FANTASY XI Config.exe"));
                case PolBoot.PlatformType.US:
                    return Exec(Path.Combine(GetInformation(TargetPlatform).FFXI_Dir, "ToolsUS", "FINAL FANTASY XI Config.exe"));
                case PolBoot.PlatformType.EU:
                    return Exec(Path.Combine(GetInformation(TargetPlatform).FFXI_Dir, "ToolsEU", "FINAL FANTASY XI Config.exe"));
                default:
                    return null;
            }
        }

        private Process Exec(string FileName) => Exec(FileName, null, false);
        private Process Exec(string FileName, bool Hidden) => Exec(FileName, null, Hidden);
        private Process Exec(string FileName, string Arguments) => Exec(FileName, Arguments, false);

        private Process Exec(string FileName, string Arguments, bool Hidden)
        {
            try
            {
                var myStartInfo = new ProcessStartInfo(FileName);
                if (Arguments != null) myStartInfo.Arguments = Arguments;
                myStartInfo.UseShellExecute = false;
                if (Hidden) myStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                return Process.Start(myStartInfo);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// クライアントダウンロードのURLを取得します
        /// </summary>
        /// <param name="TargetPlatform">プラットフォーム種別</param>
        /// <returns>URL</returns>
        public string GetClientDownloadURL(PlatformType TargetPlatform)
        {
            switch (TargetPlatform)
            {
                case PlatformType.JP:
                    return "http://www.playonline.com/ff11/download/media/install_win.html";
                case PlatformType.US:
                    return "http://www.playonline.com/ff11us/download/media/install_win.html";
                case PlatformType.EU:
                    return "http://www.playonline.com/ff11eu/download/media/install_win.html";
                default:
                    return null;
            }
        }
    }
}
