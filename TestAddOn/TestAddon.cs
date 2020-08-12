using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using RBRPro.Api;
using TGD.Localization;
using TGD.Rbr.Telemetry.Data;
using TGD.Utils;

namespace RBRProTestAddOn
{
    /// <summary>
    /// The TestAddon
    /// A RBRPro Addon is a class implementing the IRbrProAddOn interface.
    /// Optionally, the Addon can receive telemetry by implementing the ITelemetryClient interface
    /// </summary>
    public class TestAddon : IRbrProAddOn, ITelemetryClient
    {
        // Maybe in future these properties will be replaced by class attributes
        #region PLUGIN INFO
        public string Name { get => "Test Add-On"; }
        public string Description { get => "This is a Test Add-On"; }
        public string Author { get => "TGD"; }
        
        public Image Icon => new Image { Source = new BitmapImage(new Uri($"pack://application:,,,/TestAddOn;component/icon.png", UriKind.Absolute)) };
        #endregion

        // The interface used to interact with the manger
        public IRbrPro _interactor;

        // The viewmodel class
        Model _model;

        public TestAddon()
        {
            _model = new Model();
            _model.CarSpeed = 1;    // Just to test the data binding...                        
        }

        /// <summary>
        /// Called by the manager just after the addon loading, the contents are not ready yet...
        /// but in the meantime you can do something to prepare...
        /// for example we can load our language strings
        /// </summary>
        public void Init(IRbrPro rbrProInteractor)
        {
            _interactor = rbrProInteractor;
        }

        /// <summary>
        /// Called by the manager when it finishes the initialization and the contents are available
        /// </summary>
        /// <param name="rbrProInteractor"></param>
        public void Ready(IRbrPro rbrProInteractor)
        {

        }

        /// <summary>
        /// Called by the manager, this method just returns an instance of the GUI Control
        /// </summary>
        /// <returns></returns>
        public System.Windows.Controls.Control GetGui()
        {
            return new TestAddonGui(_interactor, _model);
        }
        
        public void Exit()
        {

        }

        public void DataReceived(TelemetryData data)
        {
            _model.CarSpeed = data.car.speed;
        }
    }
}
