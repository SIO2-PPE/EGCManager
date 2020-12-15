﻿using System;
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
    /// Logique d'interaction pour Planning.xaml
    /// </summary>
    public partial class Planning : Window
    {

        private DaoSite thedaoSite;
        private DaoSalle thedaoSalle;
        private DaoPartie thedaoPartie;
        private DaoHoraire thedaoHoraire;
        private DaoObstacle thedaoObstacle;
        private DaoJoueur thedaoJoueur;

        public Planning(DaoSite daosite, DaoSalle daosalle, DaoPartie daopartie, DaoHoraire daohoraire, DaoObstacle daoobstacle, DaoJoueur daojoeueur)
        {

            thedaoSite = daosite;
            thedaoSalle = daosalle;
            thedaoHoraire = daohoraire;
            thedaoPartie = daopartie;
            thedaoObstacle = daoobstacle;
            thedaoJoueur = daojoeueur;
            InitializeComponent();
            MainGrid.DataContext = new viewModel.viewModelPlanning(daosite, daosalle, daopartie, daohoraire);

        }

        private void btn_new_partie_Click(object sender, RoutedEventArgs e)
        {
            if (ListPlanningView.SelectedItem != null)
            {
                Création_de_partie subWindow = new Création_de_partie(thedaoSite, thedaoSalle, thedaoPartie, thedaoHoraire, thedaoObstacle, thedaoJoueur);
                subWindow.Show();
                this.Close();
            }
            else
            {
                
               
                MessageBox.Show("veuillez selectionner une partie non réserver");
            }



        }


    }
}
