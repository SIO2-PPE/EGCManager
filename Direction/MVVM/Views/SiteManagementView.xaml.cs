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
    /// Logique d'interaction pour SiteManagementView.xaml
    /// </summary>
    public partial class SiteManagementView : Page
    {
        public SiteManagementView(Dbal dbal)
        {
            InitializeComponent();
            DataContext = new SiteManagementViewModel(
                new DaoSite(dbal),
                new DaoSalle(dbal),
                new DaoHoraire(dbal),
                new DaoTheme(dbal),
                new DaoObstacle(dbal)
            );
        }
    }
}
