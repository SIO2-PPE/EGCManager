using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Technicien
{
    /// <summary>
    /// Logique d'interaction pour Planning.xaml
    /// </summary>
    public partial class Planning : Window
    {
        public Planning()
        {
            InitializeComponent();
        }

        private void btn_new_partie_Click(object sender, RoutedEventArgs e)
        {
            {
                Création_de_partie subWindow = new Création_de_partie();
                subWindow.Show();
                this.Close();
            }
        }
    }
}
