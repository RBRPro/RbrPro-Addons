using RbrPro.API;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TGD.Rbr.Telemetry.Data;

namespace RBRPro.Api
{
    public static class AddOns
    {
        public const string BASEPATH = "Addons";     
    }

    /// <summary>
    /// RBRPro interactor interface
    /// </summary>
    public interface IRbrPro
    {
        Window MainWindow { get; }

        IDriver User { get; }
        ICar SelectedCar { get; }
        IStage SelectedStage { get; }
        ICoDriver SelectedCodriver { get; }
        ICarList CarList { get; }
        IStageList StageList { get; }
        ICoDriverList CoDriverList { get; }

        Task StartGame(bool a, bool b, bool c);
        
        event EventHandler<ICar> SelectedCarChanged;
        event EventHandler<IStage> SelectedStageChanged;
        event EventHandler<ICoDriver> SelectedCoDriverChanged;
        event EventHandler<ICoDriver> ActiveCoDriverChanged;
        event EventHandler<string> SelectedLanguageChanged;
        event EventHandler GameStarted;
        event EventHandler GameStopped;
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
        /// Returns the Add-on GUI interface (a WPF Control)
        /// </summary>
        /// <returns></returns>
        System.Windows.Controls.Control GetGui();

        /// <summary>
        /// Called before exit
        /// </summary>
        void Exit();
    }

    /// <summary>
    /// RBRPro interface for telemetry clients
    /// </summary>
    public interface ITelemetryClient
    {
        void DataReceived(TelemetryData data);
    }
}
