using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceDeLEnfer
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    


    public partial class App : Application
    {

        static internal Dictionary<string, string> Localized { get; private set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var Localized_a_remplir = new ResourceDictionary();
            Localized_a_remplir.Source = 
                new Uri("InterfaceDeLEnfer;component/resources/resources.xaml", UriKind.Relative);
            Localized = Localized_a_remplir.Keys.Cast<string>().ToDictionary(x => x, x => (string)Localized_a_remplir[x]);

        }
    }
}
