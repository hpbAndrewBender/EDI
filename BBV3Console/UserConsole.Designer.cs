﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserConsole {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class UserConsole : global::System.Configuration.ApplicationSettingsBase {
        
        private static UserConsole defaultInstance = ((UserConsole)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new UserConsole())));
        
        public static UserConsole Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dev|porcupine|HPB_EDI|trusted||;prd|silverbell|HPB_EDI|trusted||")]
        public string ConStrgs_HPBEDI {
            get {
                return ((string)(this["ConStrgs_HPBEDI"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dev")]
        public string Env {
            get {
                return ((string)(this["Env"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(";|")]
        public string ConStrgs_Delims {
            get {
                return ((string)(this["ConStrgs_Delims"]));
            }
        }
    }
}