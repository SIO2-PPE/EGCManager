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
using System.Windows.Shapes;
using Model.Business;
using Model.Data;

namespace Compta
{
    /// <summary>
    /// Logique d'interaction pour FenetreClient.xaml
    /// </summary>
    public partial class InfosClient : Window
    {
        private Dbal _dbal;

        public InfosClient(Client leClient, Dbal dbal)
        {
            _dbal = dbal;
            InitializeComponent();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            SelectWindow subWindow = new SelectWindow(_dbal);
            subWindow.Show();
            Close();
        }

        private void Factu_Click(object sender, RoutedEventArgs e)
        {
            Facturation subWindow = new Facturation(_dbal);
            subWindow.Show();
            Close();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            SaisieClient subWindow = new SaisieClient(_dbal);
            subWindow.Show();
            Close();
        }
    }
}