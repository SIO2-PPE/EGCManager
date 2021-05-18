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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Direction.ViewModels;
using Model.Data;
using Direction.Models;

namespace Direction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dbal _dbal;
        public MainWindow()
        {
            InitializeComponent();
            _dbal = new Dbal("ppe3_mmd", "localhost", "root", "5MichelAnnecy");
            DataContext = new DashboardViewModel(new DaoPartie(_dbal), new DaoSite(_dbal));
        }

        private void TopBar_MouseDown(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void Dashboard_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new DashboardViewModel(
                new DaoPartie(_dbal),
                new DaoSite(_dbal)
            );
        }

        private void SiteManagement_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SiteManagementViewModel(
                new DaoSite(_dbal),
                new DaoSalle(_dbal),
                new DaoHoraire(_dbal),
                new DaoTheme(_dbal),
                new DaoObstacle(_dbal)
            );
        }

        private void CustomerReviews_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new CustomerReviewsViewModel(
                new DaoTheme(_dbal),
                new DaoAvis(_dbal)
            );
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
