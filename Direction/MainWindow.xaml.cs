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
using Direction.Views;

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
            _dbal = new Dbal("ppe3_mmd");
            Body.Content = new DashboardView(_dbal);
        }

        private void TopBar_MouseDown(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void Dashboard_Clicked(object sender, RoutedEventArgs e)
        {
            Body.Content = new DashboardView(_dbal);
        }

        private void SiteManagement_Clicked(object sender, RoutedEventArgs e)
        {
            Body.Content = new SiteManagementView(_dbal);
        }

        private void CustomerReviews_Clicked(object sender, RoutedEventArgs e)
        {
            Body.Content = new CustomerReviewsView(_dbal);
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
