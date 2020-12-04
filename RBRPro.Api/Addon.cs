using RbrPro.API;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TGD.Rbr.Telemetry.Data;
using System.Speech.Recognition;

namespace RBRPro.Api
{
    public static class AddOns
    {
        public const string BASEPATH = "Addons";     
    }

    /// <summary>
    /// RBRPro Add-on interface
    /// </summary>
    public interface IRbrProAddOn
    {
        string Name { get; }
        string Description { get; }
        string Author { get; }
        Image Icon { get; }
        bool IsDetachable { get; }

        /// <summary>
        /// Called on loading
        /// </summary>
        /// <param name="addonManager"></param>
        void Init(IRbrPro rbrProInteractor);

        /// <summary>
        /// Called when contents are ready
        /// </summary>
        /// <param name="addonManager"></param>
        void Ready(IRbrPro rbrProInteractor);

        /// <summary>
        /// Called to notify a change of the parent window when the addon is attached or detached
        /// </summary>
        /// <param name="parent"></param>
        void OnParentWindowChange(Window parent);
        
        /// <summary>
        /// Returns the Add-on GUI interface (a WPF Control)
        /// </summary>
        /// <returns></returns>
        System.Windows.Controls.Control GetGui();

        /// <summary>
        /// Called before exit
        /// </summary>
        void Exit();
    }
}
