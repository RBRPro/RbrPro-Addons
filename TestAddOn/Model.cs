using RBRPro.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGD.Framework;
using TGD.Utils;

namespace RBRProTestAddOn
{
    public class Model : DynamicContextManager
    {
        static IniFile _otherIni = new IniFile("OtherIniFile.ini");

        /// <summary>
        /// The Persistent Properties are loaded and saved automatically. They can have a default value. 
        /// Only C# base types only (the framework cannot persist complex types)
        /// </summary>
        #region PERSISTENT PROPERTIES
        [DefaultValue(true)]
        [ConfigProperty]
        public bool ShowCarSpeed { get { return GetIniProperty<bool>(); } set { SetIniProperty(value); } }

        /// <summary>
        /// This property is mapped in a specific section of the .ini File
        /// </summary>
        [ConfigProperty("Section2")] 
        public string AnotherPersistentProperty { get { return GetIniProperty<string>(); } set { SetIniProperty(value); } }

        /// <summary>
        /// This property is mapped in a specific section of the .ini File with a specific name
        /// </summary>
        [ConfigProperty("Section2", "PropertyName")]
        public string YetAnotherPersistentProperty { get { return GetIniProperty<string>(); } set { SetIniProperty(value); } }

        /// <summary>
        /// This property is mapped in a specific section of the .ini File with a specific name
        /// </summary>
        [ConfigProperty]
        public string AdditionalPersistentProperty { get { return GetIniProperty<string>(_otherIni); } set { SetIniProperty(_otherIni, value); } }
        #endregion

        /// <summary>
        /// The Runtime Properties are the volatile ones. No limitations about the types: complex types and collections are allowed
        /// </summary>
        #region RUNTIME PROPERTIES
        [RuntimeProperty("Car.Speed")]
        public float CarSpeed { get { return GetRuntimeProperty<float>(); } set { SetRuntimeProperty(value); } }

        [RuntimeProperty]
        public int AnotherRuntimeProperty { get { return GetRuntimeProperty<int>(); } set { SetRuntimeProperty(value); } }
        #endregion

        /// <summary>
        /// The file TestAddOn.ini is used as the main repository of the persistent properties
        /// </summary>
        public Model() : base($"{AddOns.BASEPATH}\\TestAddon\\TestAddOn.ini")
        {
            // Other model initialization code here
        }
    }
}
