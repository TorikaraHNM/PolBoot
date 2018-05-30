namespace PolBoot
{
    /// <summary>
    /// POLのプラットフォームごとの情報クラス
    /// </summary>
    public class PlatformInformation
    {
        /// <summary>
        /// POLのインストールフォルダ
        /// </summary>
        public readonly string POL_Dir;
        /// <summary>
        /// FFXIのインストールフォルダ
        /// </summary>
        public readonly string FFXI_Dir;
        /// <summary>
        /// POLのインストール有無
        /// </summary>
        public readonly bool POL_Installed;
        /// <summary>
        /// FFXIのインストール有無
        /// </summary>
        public readonly bool FFXI_Installed;
        /// <summary>
        /// RoZのインストール有無
        /// </summary>
        public readonly bool FFXI_RoZ_Installed;
        /// <summary>
        /// CoPのインストール有無
        /// </summary>
        public readonly bool FFXI_CoP_Installed;
        /// <summary>
        /// ToAのインストール有無
        /// </summary>
        public readonly bool FFXI_ToA_Installed;
        /// <summary>
        /// WoG
        /// </summary>
        public readonly bool FFXI_WoG_Installed;
        /// <summary>
        /// SoAのインストール有無
        /// </summary>
        public readonly bool FFXI_SoA_Installed;

        internal static readonly PlatformInformation NotInstalled = new PlatformInformation(null, null, false, false, false, false);

        internal PlatformInformation(string POL_Dir, string FFXI_Dir, bool FFXI_RoZ_Installed, bool FFXI_CoP_Installed, bool FFXI_ToA_Installed, bool FFXI_WoG_Installed, bool FFXI_SoA_Installed = false)
        {
            this.POL_Dir = POL_Dir;
            this.FFXI_Dir = FFXI_Dir;
            this.POL_Installed = POL_Dir != null;
            this.FFXI_Installed = FFXI_Dir != null;
            this.FFXI_RoZ_Installed = FFXI_RoZ_Installed;
            this.FFXI_CoP_Installed = FFXI_CoP_Installed;
            this.FFXI_ToA_Installed = FFXI_ToA_Installed;
            this.FFXI_WoG_Installed = FFXI_WoG_Installed;
            this.FFXI_SoA_Installed = FFXI_SoA_Installed;
        }
    }
}
