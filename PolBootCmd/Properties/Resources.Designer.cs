﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PolBoot.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PolBoot.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   ERROR: Regsvr32 Failed. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Msg_Err_DllRegsvr32Failed {
            get {
                return ResourceManager.GetString("Msg_Err_DllRegsvr32Failed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ERROR: FFXI Config Boot Failed. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Msg_Err_FfxiConfigBootFailed {
            get {
                return ResourceManager.GetString("Msg_Err_FfxiConfigBootFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ERROR: FFXI Not Installed. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Msg_Err_FfxiNotInstalled {
            get {
                return ResourceManager.GetString("Msg_Err_FfxiNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ERROR: POL Boot Failed. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Msg_Err_PolBootFailed {
            get {
                return ResourceManager.GetString("Msg_Err_PolBootFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ERROR: POL Config Boot Failed. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Msg_Err_PolConfigBootFailed {
            get {
                return ResourceManager.GetString("Msg_Err_PolConfigBootFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   ERROR: POL Not Installed. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Msg_Err_PolNotInstalled {
            get {
                return ResourceManager.GetString("Msg_Err_PolNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   PolBootCmd &lt;command&gt;
        ///  /polboot-jp or /bj  Boot JP PlayOnline.
        ///  /polboot-us or /bu  Boot US PlayOnline.
        ///  /polboot-eu or /be  Boot EU PlayOnline.
        ///  /polcfg-jp  or /pj  Boot JP PlayOnline Configure.
        ///  /polcfg-us  or /pu  Boot US PlayOnline Configure.
        ///  /polcfg-eu  or /pe  Boot EU PlayOnline Configure.
        ///  /ffxicfg-jp or /fj  Boot JP FFXI Configure.
        ///  /ffxicfg-us or /fu  Boot US FFXI Configure.
        ///  /ffxicfg-eu or /fe  Boot EU FFXI Configure. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Usage {
            get {
                return ResourceManager.GetString("Usage", resourceCulture);
            }
        }
    }
}
