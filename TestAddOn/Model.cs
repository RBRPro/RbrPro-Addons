using RBRPro.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGD.Framework;

namespace RBRProTestAddOn
{
    public class Model : DynamicContextManager
    {
        /// <summary>
        /// The Persistent Properties are loaded and saved automatically. They can have a default value. 
        /// Only C# base types only (the framework cannot persist complex types)
        /// </summary>
        #region PERSISTENT PROPERTIES
        [DefaultValue(true)]
        [ConfigProperty]
        public bool ShowCarSpeed { get { return GetCfgProperty<bool>(); } set { SetCfgProperty(value); } }

        [ConfigProperty]
        public string AnotherPersistentProperty { get { return GetCfgProperty<string>(); } set { SetCfgProperty(value); } }
        #endregion

        /// <summary>
        /// The Runtime Properties are the volatile ones. No limitations about the types: complex types and collections are allowed
        /// </summary>
        #region RUNTIME PROPERTIES
        [RuntimeProperty]
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
