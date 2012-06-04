﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beast {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Beast.CommonResources", typeof(CommonResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to You need to login before attempting to execute this command..
        /// </summary>
        internal static string AccessDenied {
            get {
                return ResourceManager.GetString("AccessDenied", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The arguments supplied with the command were invalid. Use the &apos;{0}&apos; command in the following manner: {1}.
        /// </summary>
        internal static string CommandInvalidArgumentsFormat {
            get {
                return ResourceManager.GetString("CommandInvalidArgumentsFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The direction &apos;{0}&apos; was not a valid direction or alias..
        /// </summary>
        internal static string DirectionNotFoundFormat {
            get {
                return ResourceManager.GetString("DirectionNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALIASES.
        /// </summary>
        internal static string HelpAliases {
            get {
                return ResourceManager.GetString("HelpAliases", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DESCRIPTION.
        /// </summary>
        internal static string HelpDescription {
            get {
                return ResourceManager.GetString("HelpDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please specify a command in which you need help information..
        /// </summary>
        internal static string HelpInvalidArgument {
            get {
                return ResourceManager.GetString("HelpInvalidArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NAME.
        /// </summary>
        internal static string HelpName {
            get {
                return ResourceManager.GetString("HelpName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help information could not located for the command &apos;{0}&apos;. Please check the spelling of the command and try again..
        /// </summary>
        internal static string HelpNotFoundFormat {
            get {
                return ResourceManager.GetString("HelpNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SYNOPSIS.
        /// </summary>
        internal static string HelpSynopsis {
            get {
                return ResourceManager.GetString("HelpSynopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The command &apos;{0}&apos; is not a valid or recognized command. Please check the spelling of the command and try again..
        /// </summary>
        internal static string InvalidCommandFormat {
            get {
                return ResourceManager.GetString("InvalidCommandFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please login to continue playing..
        /// </summary>
        internal static string LoginRequired {
            get {
                return ResourceManager.GetString("LoginRequired", resourceCulture);
            }
        }
    }
}
