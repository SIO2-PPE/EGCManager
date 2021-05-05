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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Direction.ViewModels;
using Model.Data;

namespace Direction.Views
{
    /// <summary>
    /// Logique d'interaction pour DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Page
    {
        public DashboardView(Dbal dbal)
        {
            InitializeComponent();
            DataContext = new DashboardViewModel(
                new DaoPartie(dbal),
                new DaoSite(dbal)
            );
        }
    }
}
