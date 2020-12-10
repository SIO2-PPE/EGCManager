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
using Model.Data;

namespace Direction
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        public Login(DaoSite daoSite, DaoSalle daoSalle)
        {
            _daoSite = daoSite;
            _daoSalle = daoSalle;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EGCManager_Direction wnd = new EGCManager_Direction(_daoSite, _daoSalle);
            wnd.Show();
            this.Close();
        }
    }
}
