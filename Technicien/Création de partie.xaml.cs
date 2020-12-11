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
using Model.Business;


namespace Technicien
{
    /// <summary>
    /// Logique d'interaction pour Création_de_partie.xaml
    /// </summary>
    public partial class Création_de_partie : Window
    {  /// <summary>
       /// Logique d'interaction pour Création_de_partie.xaml
       /// </summary>
       private Dbal thedbal;
        private DaoSite thedaoSite;
        private DaoSalle thedaoSalle;

        public Création_de_partie()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Cree_Partie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Retour_Click(object sender, RoutedEventArgs e)
        {
            Planning subWindow = new Planning(thedaoSite,thedaoSalle);
            subWindow.Show();
            this.Close();
        }

        private void txt_recherche_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ajouter_joueur_list(object sender, RoutedEventArgs e)
        {

        }

        private void Button_newjoueur(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
    }
}

