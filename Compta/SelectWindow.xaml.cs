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
using Model.Data;

namespace Compta
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        private Dbal _dbal;
        public SelectWindow(Dbal dbal)
        {
            InitializeComponent();
            _dbal = dbal;
        }

        private void Button_Click() //object sender, RoutedEventArgs e
        {
            {
                SaisieClient subWindow = new SaisieClient(_dbal);
                subWindow.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                CreationClient subWindow = new CreationClient();
                subWindow.Show();
                this.Close();
            }
        }
    }
}
