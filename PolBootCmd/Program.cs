using System;

namespace PolBoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var tool = new PolTool();

                switch (args.Length == 0 ? "/help" : args[0].ToLower())
                {
                    case "/polboot-jp":
                    case "/bj":
                        ExecPol(tool, PlatformType.JP);
                        return;
                    case "/polboot-us":
                    case "/bu":
                        ExecPol(tool, PlatformType.US);
                        return;
                    case "/polboot-eu":
                    case "/be":
                        ExecPol(tool, PlatformType.EU);
                        return;
                    case "/polcfg-jp":
                    case "/pj":
                        ExecPolCfg(tool, PlatformType.JP);
                        return;
                    case "/polcfg-us":
                    case "/pu":
                        ExecPolCfg(tool, PlatformType.US);
                        return;
                    case "/polcfg-eu":
                    case "/pe":
                        ExecPolCfg(tool, PlatformType.EU);
                        return;
                    case "/ffxicfg-jp":
                    case "/fj":
                        ExecFfxiCfg(tool, PlatformType.JP);
                        return;
                    case "/ffxicfg-us":
                    case "/fu":
                        ExecFfxiCfg(tool, PlatformType.US);
                        return;
                    case "/ffxicfg-eu":
                    case "/fe":
                        ExecFfxiCfg(tool, PlatformType.EU);
                        return;
                }

                ShowUsage();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        private static void ShowUsage() => Console.Write(Properties.Resources.Usage);

        private static Regsvr32FailedCallbackResult Regsvr32FailedCallback(string s)
        {
            Console.WriteLine(Properties.Resources.Msg_Regsvr32FailedFilename + s);
            Console.Write(Properties.Resources.Msg_Regsvr32FailedPrompt);
            var res = Console.ReadKey();
            Console.WriteLine();

            switch (res.KeyChar)
            {
                case 'A':
                case 'a':
                    return Regsvr32FailedCallbackResult.Abort;
                case 'R':
                case 'r':
                    return Regsvr32FailedCallbackResult.Retry;
                case 'I':
                case 'i':
                    return Regsvr32FailedCallbackResult.Ignore;
                default:
                    return Regsvr32FailedCallbackResult.Abort;
            }
        }

        private static void ExecPol(PolTool tool, PlatformType type)
        {
            if (!tool[type].POL_Installed)
            {
                Console.WriteLine(Properties.Resources.Msg_Err_PolNotInstalled);
                return;
            }

            if (tool[type].FFXI_Installed)
            {
                if (!tool.ExecRegsvr32(type, Regsvr32FailedCallback))
                {
                    Console.WriteLine(Properties.Resources.Msg_Err_DllRegsvr32Failed);
                    return;
                }
            }

            var proc = tool.ExecPol(type);
            if (proc == null)
            {
                Console.WriteLine(Properties.Resources.Msg_Err_PolBootFailed);
                return;
            }
            else
            {
                tool.WaitForExitPol(type);
            }
        }

        private static void ExecPolCfg(PolTool tool, PlatformType type)
        {
            if (!tool[type].POL_Installed)
            {
                Console.WriteLine(Properties.Resources.Msg_Err_PolNotInstalled);
                return;
            }

            var proc = tool.ExecPolCfg(type);
            if (proc == null)
            {
                Console.WriteLine(Properties.Resources.Msg_Err_PolConfigBootFailed);
                return;
            }
            else
            {
                proc.WaitForExit();
            }
        }

        private static void ExecFfxiCfg(PolTool tool, PlatformType type)
        {
            if (!tool[type].FFXI_Installed)
            {
                Console.WriteLine(Properties.Resources.Msg_Err_FfxiNotInstalled);
                return;
            }

            var proc = tool.ExecFfxiCfg(type);
            if (proc == null)
            {
                Console.WriteLine(Properties.Resources.Msg_Err_FfxiConfigBootFailed);
                return;
            }
            else
            {
                proc.WaitForExit();
            }
        }
    }
}
