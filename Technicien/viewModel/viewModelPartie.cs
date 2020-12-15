using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Technicien.viewModel
{
    class viewModelApp : viewModelBase
    {
        //DAO

        private DaoHoraire _daoHoraire;
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        private DaoPartie _daoPartie;
        private DaoObstacle _daoObstacle;
        private DaoJoueur _daoJoueur;


        //LISTE
        private ObservableCollection<Joueur> _listJoueur;
        private ObservableCollection<Joueur> _listJoueurPartie;
        private ObservableCollection<Obstacle> _listObstacle;
        private ObservableCollection<Obstacle> _listObstaclePartie;

        //SELECTION
        private Joueur _selectedJoueur;
        private Joueur _selectedJoueurPartie;
        private Obstacle _selectedObstacle;


        //COMMANDE



    }


}
