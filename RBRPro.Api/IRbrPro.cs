using RbrPro.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TGD.Rbr.Telemetry.Data;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace RBRPro.Api
{
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
        IOptionPackList OptionPackList { get; }
        ICoDriverList CoDriverList { get; }

        Task StartGame(bool a, bool b, bool c);
        void Speak(string phrase);
        Image GetCountryFlag(string country);

        event EventHandler<ICar> SelectedCarChanged;
        event EventHandler<IStage> SelectedStageChanged;
        event EventHandler<ICoDriver> SelectedCoDriverChanged;
        event EventHandler<ICoDriver> ActiveCoDriverChanged;
        event EventHandler<TelemetryData> DataReceived;        
        event EventHandler<SpeechRecognizedEventArgs> VocalCommandRecognized;
        event EventHandler<string> SelectedLanguageChanged;
        event EventHandler GameStarted;
        event EventHandler GameStopped;
        event EventHandler GamePaused;
        event EventHandler<string> GameExited;
        
    }
}
