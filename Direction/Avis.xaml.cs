using System.Windows;
using Model.Data;

namespace Direction
{
    public partial class Avis : Window
    {
        private Dbal _dbal;
        public Avis(Dbal dbal)
        {
            InitializeComponent();
            _dbal = dbal;
            MainGrid.DataContext = new viewModel.ViewModelAvis(
                new DaoTheme(dbal)
            );
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Home wnd = new Home(_dbal);
            wnd.Show();
            Close();
        }
    }
}