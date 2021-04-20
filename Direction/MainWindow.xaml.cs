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

namespace Direction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dashboard_Clicked(object sender, RoutedEventArgs e)
        {
            Dbal dbal = new Dbal("ppe3_mmd");
            DataContext = new DashboardViewModel(new DaoPartie(dbal), new DaoSite(dbal));
        }

        private void SiteManagement_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SiteManagementViewModel();
        }

        private void CustomerReviews_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new CustomerReviewsViewModel();
        }
    }
}
