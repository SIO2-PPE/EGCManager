using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Model.Business;
using Model.Data;
using Compta.viewModel;


namespace Compta
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Login : Window
    {


        public Login(DaoClient thedaoclient, DaoFacture thedaofacture)
        {
            InitializeComponent();
            Login.DataContext = new viewModel.viewModelClient(thedaoclient, thedaofacture);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                SelectWindow subWindow = new SelectWindow();
                subWindow.Show();
                this.Close();
            }
        }

    }
}

