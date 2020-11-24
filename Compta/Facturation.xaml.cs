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

namespace PPE_1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Facturation : Window
    {
        public Facturation()
        {
            InitializeComponent();
        }

        private void Return1_Click(object sender, RoutedEventArgs e)
        {

            {
                InfosClient subWindow = new InfosClient();
                subWindow.Show();
                this.Close();
            }

        }
    }
}
