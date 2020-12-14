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
using Model.Business;
using Model.Data;

namespace Compta
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class SaisieClient: Window
    {
        private Dbal _dbal;
        public SaisieClient(Dbal dbal)
        {
            InitializeComponent();
            maGrid.DataContext = new viewModel.ViewModelSaisieClient(new DaoClient(dbal),new DaoFacture(dbal));
        }

        private void ReturnButton(object sender, RoutedEventArgs e)
        {
            {
                SelectWindow subWindow = new SelectWindow(_dbal);
                subWindow.Show();
                this.Close();
            }
        }
    }
}
