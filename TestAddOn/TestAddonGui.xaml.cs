using RBRPro.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TGD.Utils;

namespace RBRProTestAddOn
{
    /// <summary>
    /// Logica di interazione per TestAddonGui.xaml
    /// </summary>
    public partial class TestAddonGui : UserControl
    {
        IRbrPro _rbrPro = null;
        Model _model = null;

        public TestAddonGui(IRbrPro interactor, Model model)
        {
            this.DataContext = _model = model;
            _rbrPro = interactor;

            InitializeComponent();
            
            _rbrPro.SelectedLanguageChanged += _rbrPro_SelectedLanguageChanged;
            _rbrPro.ActiveCoDriverChanged += _rbrPro_ActiveCoDriverChanged;
        }

        private void _rbrPro_ActiveCoDriverChanged(object sender, RbrPro.API.ICoDriver e)
        {
            //MsgBox.Info($"The active codriver changed: the new one is {e.Name}");
        }        

        private void _rbrPro_SelectedLanguageChanged(object sender, string newLanguage)
        {
            // Translates the GUI according to the language selected in the manager
            Local.Load($"TestAddon\\languages\\{newLanguage}.ini");
            Local.Translate(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _rbrPro?.StartGame(false, false, false);
        }
    }
}
