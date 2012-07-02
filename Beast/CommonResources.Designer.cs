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
    public class CommonResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
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
        public static global::System.Globalization.CultureInfo Culture {
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
        public static string AccessDenied {
            get {
                return ResourceManager.GetString("AccessDenied", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The arguments supplied with the command were invalid. Use the &apos;{0}&apos; command in the following manner: {1}.
        /// </summary>
        public static string CommandInvalidArgumentsFormat {
            get {
                return ResourceManager.GetString("CommandInvalidArgumentsFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The command &apos;{0}&apos; is not a valid or recognized command. Please check the spelling of the command and try again..
        /// </summary>
        public static string CommandInvalidFormat {
            get {
                return ResourceManager.GetString("CommandInvalidFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;beast&apos; configuration section was not found. Ensure the configuration section exists in the application configuration file or use an overloaded method that accepts the configuration section or file name..
        /// </summary>
        public static string ConfigBeastSectionNotFound {
            get {
                return ResourceManager.GetString("ConfigBeastSectionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The direction &apos;{0}&apos; was not a valid direction or alias..
        /// </summary>
        public static string DirectionNotFoundFormat {
            get {
                return ResourceManager.GetString("DirectionNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALIASES.
        /// </summary>
        public static string HelpAliases {
            get {
                return ResourceManager.GetString("HelpAliases", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DESCRIPTION.
        /// </summary>
        public static string HelpDescription {
            get {
                return ResourceManager.GetString("HelpDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please specify a command in which you need help information..
        /// </summary>
        public static string HelpInvalidArgument {
            get {
                return ResourceManager.GetString("HelpInvalidArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NAME.
        /// </summary>
        public static string HelpName {
            get {
                return ResourceManager.GetString("HelpName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help information could not located for the command &apos;{0}&apos;. Please check the spelling of the command and try again..
        /// </summary>
        public static string HelpNotFoundFormat {
            get {
                return ResourceManager.GetString("HelpNotFoundFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SYNOPSIS.
        /// </summary>
        public static string HelpSynopsis {
            get {
                return ResourceManager.GetString("HelpSynopsis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A user account already exists for the username specified..
        /// </summary>
        public static string LoginAlreadyExists {
            get {
                return ResourceManager.GetString("LoginAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The login credentials supplied are invalid. Please check your username and password and try again..
        /// </summary>
        public static string LoginInvalid {
            get {
                return ResourceManager.GetString("LoginInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please login to continue playing..
        /// </summary>
        public static string LoginRequired {
            get {
                return ResourceManager.GetString("LoginRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An instance of Beast.IVirtualPathResolver could not be found. Provide an IVirtualPathResolver instance to use virtual paths..
        /// </summary>
        public static string VirtualPathResolverNotSet {
            get {
                return ResourceManager.GetString("VirtualPathResolverNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are no players currently online..
        /// </summary>
        public static string WhoNoPlayers {
            get {
                return ResourceManager.GetString("WhoNoPlayers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player currently online {0}:.
        /// </summary>
        public static string WhoPlayersFormat {
            get {
                return ResourceManager.GetString("WhoPlayersFormat", resourceCulture);
            }
        }
    }
}
