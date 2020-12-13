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
using Model.Business;
using Model.Data;

namespace Technicien
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private DaoSite thedaoSite;
        private DaoSalle thedaoSalle;
        private DaoPartie thedaoPartie;
        private DaoHoraire thedaoHoraire;
        public MainWindow(DaoSite daosite,DaoSalle daosalle,DaoPartie daopartie,DaoHoraire daohoraire)
        {
            thedaoSite = daosite;
            thedaoSalle = daosalle;
            thedaoHoraire = daohoraire;
            thedaoPartie = daopartie;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                Planning subWindow = new Planning(thedaoSite,thedaoSalle,thedaoPartie,thedaoHoraire);
                subWindow.Show();
                Close();
            
            
            
        }
    }
}
