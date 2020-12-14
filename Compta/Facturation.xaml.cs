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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Facturation : Window
    {
        private Dbal _dbal;
        public Facturation(Dbal dbal)
        {
            _dbal = dbal;
            InitializeComponent();
        }

        private void Return1_Click(object sender, RoutedEventArgs e)
        {

            {
                InfosClient subWindow = new InfosClient(new Client(),_dbal);
                subWindow.Show();
                Close();
            }

        }

        private void Create_facture_Click(object sender, RoutedEventArgs e)
        {
            {
                SelectWindow subWindow = new SelectWindow(_dbal);
                subWindow.Show();
                Close();
            }
        }
    }
}
