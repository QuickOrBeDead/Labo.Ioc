﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Labo.Common.Ioc.Resources {
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Labo.Common.Ioc.Resources.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Circular dependency detected: &apos;{0}&apos;.
        /// </summary>
        internal static string CircularDependencyValidator_CheckCircularDependency_Circular_dependency_detected {
            get {
                return ResourceManager.GetString("CircularDependencyValidator_CheckCircularDependency_Circular_dependency_detected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Probable circular dependency between services. Resolve depth reached to the max resolve depth which is {0}.
        /// </summary>
        internal static string CircularDependencyValidator_CheckCircularDependency_max_resolve_depth {
            get {
                return ResourceManager.GetString("CircularDependencyValidator_CheckCircularDependency_max_resolve_depth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Implementation type &apos;{0}&apos; cannot be abstract, interface, array or type of object.
        /// </summary>
        internal static string LaboIocContainer_ValidateRegistrationTypes_ImplementationCannotBeInRestrictedForms {
            get {
                return ResourceManager.GetString("LaboIocContainer_ValidateRegistrationTypes_ImplementationCannotBeInRestrictedForm" +
                        "s", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Implementation type &apos;{0}&apos; must be reference type.
        /// </summary>
        internal static string LaboIocContainer_ValidateRegistrationTypes_ImplementationTypeMustBeReferenceType {
            get {
                return ResourceManager.GetString("LaboIocContainer_ValidateRegistrationTypes_ImplementationTypeMustBeReferenceType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; must be assignable from &apos;{1}&apos;.
        /// </summary>
        internal static string LaboIocContainer_ValidateRegistrationTypes_XMustBeAssignableFromY {
            get {
                return ResourceManager.GetString("LaboIocContainer_ValidateRegistrationTypes_XMustBeAssignableFromY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service type &apos;{0}&apos; cannot be type of Type or String.
        /// </summary>
        internal static string LaboIocContainer_ValidateServiceType_ServiceTypeCannotBeOfRestrictedTypes {
            get {
                return ResourceManager.GetString("LaboIocContainer_ValidateServiceType_ServiceTypeCannotBeOfRestrictedTypes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service type &apos;{0}&apos; must be reference type.
        /// </summary>
        internal static string LaboIocContainer_ValidateServiceType_ServiceTypeMustBeReferenceType {
            get {
                return ResourceManager.GetString("LaboIocContainer_ValidateServiceType_ServiceTypeMustBeReferenceType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No constructors on type &apos;{0}&apos; can be found..
        /// </summary>
        internal static string LaboIocEmitServiceCreator_CreateServiceInstance_NoConstructorsCanBeFound {
            get {
                return ResourceManager.GetString("LaboIocEmitServiceCreator_CreateServiceInstance_NoConstructorsCanBeFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The required constructor on type &apos;{0}&apos;  with signature &apos;{1}&apos; is unavailable..
        /// </summary>
        internal static string LaboIocEmitServiceCreator_CreateServiceInstance_RequiredConstructorNotMatchWithSignature {
            get {
                return ResourceManager.GetString("LaboIocEmitServiceCreator_CreateServiceInstance_RequiredConstructorNotMatchWithSi" +
                        "gnature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No registration could be found for the type &apos;{0}&apos;..
        /// </summary>
        internal static string ServiceCreatorManager_GetServiceCreator_No_registration_could_be_found_for_type {
            get {
                return ResourceManager.GetString("ServiceCreatorManager_GetServiceCreator_No_registration_could_be_found_for_type", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No registration could be found for the type &apos;{0}&apos; named &apos;{1}&apos;..
        /// </summary>
        internal static string ServiceCreatorManager_GetServiceCreator_No_registration_found_for_type_and_name {
            get {
                return ResourceManager.GetString("ServiceCreatorManager_GetServiceCreator_No_registration_found_for_type_and_name", resourceCulture);
            }
        }
    }
}
