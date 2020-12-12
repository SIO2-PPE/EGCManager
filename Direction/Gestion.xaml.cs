using System.Windows;
using System.Windows.Controls;
using Model.Data;
using Xceed.Wpf.AvalonDock.Controls;

namespace Direction
{
    public partial class Gestion : Page
    {
        private Home _homeWnd;
        private Dbal _dbal;
        public Gestion(Dbal dbal, Home home)
        {
            _dbal = dbal;
            _homeWnd = home;
            InitializeComponent();
            MainGrid.DataContext = new viewModel.ViewModelGestion(
            new DaoSite(dbal), new DaoSalle(dbal), new DaoHoraire(dbal), new DaoTheme(dbal));
        }

        private void back(object sender, RoutedEventArgs routedEventArgs)
        {
            
        }
    }
}