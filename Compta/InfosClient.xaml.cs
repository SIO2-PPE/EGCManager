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

namespace Compta
{
    /// <summary>
    /// Logique d'interaction pour FenetreClient.xaml
    /// </summary>
    public partial class InfosClient : Window
    {
        public InfosClient(Client leClient)
        {
            InitializeComponent();
        }
        private void Click_Edit(object sender, RoutedEventArgs e)
        {
            {
                SelectWindow subWindow = new SelectWindow();
                subWindow.Show();
                this.Close();
            }
        }

        private void Factu_Click(object sender, RoutedEventArgs e)
        {
            {
                Facturation subWindow = new Facturation();
                subWindow.Show();
                this.Close();
            }
        }

        private void Return1_Click_1(object sender, RoutedEventArgs e)
        {
            {
                SaisieClient subWindow = new SaisieClient();
                subWindow.Show();
                this.Close();
            }
        }
    }
}