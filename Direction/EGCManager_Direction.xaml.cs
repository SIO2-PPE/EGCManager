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
using System.Windows.Threading;
using Model.Data;

namespace Direction
{
    /// <summary>
    /// Logique d'interaction pour EGCManager_Direction.xaml
    /// </summary>
    public partial class EGCManager_Direction : Window
    {
        public EGCManager_Direction(DaoSite daoSite, DaoSalle daoSalle, DaoHoraire daoHoraire)
        {
            InitializeComponent();
            MainGrid.DataContext = new viewModel.ViewModelSite(daoSite, daoSalle, daoHoraire);
        }
    }
}
