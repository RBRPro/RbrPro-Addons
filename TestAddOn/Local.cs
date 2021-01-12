using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TGD.Localization;

namespace RBRProTestAddOn
{
    /// <summary>
    /// Static proxy to the localizer object
    /// </summary>
    public static class Local
    {
        static Localizer _localizer = new Localizer();

        public static void Load(string languageFile)
        {
            _localizer.Load(languageFile);
        }

        public static string String(string s)
        {
            return _localizer.String(s);
        }

        public static void Translate(FrameworkElement e)
        {
            _localizer.Translate(e);
        }

        public static void GenerateToFile(string path)
        {
            _localizer.GenerateToFile(path);
        }
    }
}
