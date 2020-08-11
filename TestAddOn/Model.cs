using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGD.Framework;

namespace RBRProTestAddOn
{
    public class Model : ContextManager
    {
        /// <summary>
        /// The Persistent Properties are loaded and saved automatically. They can have a default value. 
        /// Only C# base types only (the framework cannot persist complex types)
        /// </summary>
        #region PERSISTENT PROPERTIES
        [DefaultValue(true)]
        [ConfigProperty]
        public bool ShowCarSpeed { get { return GetProperty<bool>("ShowCarSpeed"); } set { SetProperty("ShowCarSpeed", value); } }

        [ConfigProperty]
        public string AnotherPersistentProperty { get { return GetProperty<string>("AnotherPersistentProperty"); } set { SetProperty("AnotherPersistentProperty", value); } }
        #endregion

        /// <summary>
        /// The Runtime Properties are the volatile ones. No limitations about the types: complex types and collections are allowed
        /// </summary>
        #region RUNTIME PROPERTIES
        [RuntimeProperty]
        public float CarSpeed { get { return GetRuntimeProperty<float>("CarSpeed"); } set { SetRuntimeProperty("CarSpeed", value); } }

        [RuntimeProperty]
        public int AnotherRuntimeProperty { get { return GetRuntimeProperty<int>("AnotherRuntimeProperty"); } set { SetRuntimeProperty("AnotherRuntimeProperty", value); } }
        #endregion

        /// <summary>
        /// The file TestAddOn.ini is used as the main repository of the persistent properties
        /// </summary>
        public Model() : base("Addons\\TestAddon\\TestAddOn.ini")
        {
            // Other model initialization code here
        }
    }
}
