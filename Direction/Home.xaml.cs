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
using Model.Business;
using Model.Data;

namespace Direction
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private Dbal _dbal;
        public Home(Dbal dbal)
        {
            _dbal = dbal;
            // DaoPartie daoPartie = new DaoPartie(dbal);
            // DaoSite daoSite = new DaoSite(dbal);
            // DaoSalle daoSalle = new DaoSalle(dbal);
            InitializeComponent();
            StatWrapPanel.DataContext = new viewModel.ViewModelStat(new DaoPartie(dbal));
            // List<string> lstBindingSalle = new List<string>();
            // foreach (Site site in daoSite.GetAllSite())
            // {
            //     Grid gridSite = new Grid();
            //     StatWrapPanel.Children.Add(gridSite);
            //     
            //     // Nom du site
            //     gridSite.RowDefinitions.Add(new RowDefinition());
            //     TextBlock nomSite = new TextBlock();
            //     nomSite.Text = site.ToString();
            //     gridSite.Children.Add(nomSite);
            //     Grid.SetRow(nomSite,0);
            //
            //     WrapPanel wrapPanelSite = new WrapPanel();
            //     gridSite.Children.Add(wrapPanelSite);
            //     Grid.SetRow(wrapPanelSite,1);
            //     foreach (var salle in daoSalle.GetBySite(site))
            //     {
            //         Grid gridSalle = new Grid();
            //         wrapPanelSite.Children.Add(gridSalle);
            //         
            //         // Nom de la salle
            //         gridSalle.RowDefinitions.Add(new RowDefinition());
            //         TextBlock nomSalle = new TextBlock();
            //         nomSalle.Text = salle.ToString();
            //         gridSalle.Children.Add(nomSalle);
            //         Grid.SetRow(nomSalle,0);
            //         
            //         // Nombre de visiteur pour le jour selectionné
            //         gridSalle.RowDefinitions.Add(new RowDefinition());
            //         TextBlock nbVisiteur = new TextBlock();
            //         Binding bindingNbVisiteur = new Binding();
            //         bindingNbVisiteur. = "iuhez";
            //         lstBindingSalle.Add(binding);
            //         nbVisiteur.Text = bindingNbVisiteur;
            //         gridSalle.Children.Add(nbVisiteur);
            //         Grid.SetRow(nbVisiteur,1);
            //     }
            // }
        }

        private void Click_Gestion(object sender, RoutedEventArgs e)
        {
            Gestion wnd = new Gestion(_dbal);
            wnd.Show();
            Close();
        }

        private void Click_Avis(object sender, RoutedEventArgs e)
        {
            AvisClients wnd = new AvisClients(_dbal);
            wnd.Show();
            Close();
        }
    }
}
