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
using System.Windows.Threading;
using Model.Data;

namespace Direction
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private Dbal _dbal;
        public Home(Dbal dbal)
        {
            _dbal = dbal;
            InitializeComponent();
        }

        private void Click_Gestion(object sender, RoutedEventArgs e)
        {
            Gestion gestionPage = new Gestion(_dbal, this);
            Content = gestionPage;
        }

        private void Click_Avis(object sender, RoutedEventArgs e)
        {

        }
    }
}
