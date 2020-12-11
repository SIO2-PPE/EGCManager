using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Model.Business;
using Model.Data;

namespace Technicien
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender,StartupEventArgs e)
        {
            Dbal dbal = new Dbal("ppe3_mmd");
            DaoSite daoSite = new DaoSite(dbal);

            MainWindow Wnd = new MainWindow(daoSite);
            Wnd.Show();
        }
    }
}
