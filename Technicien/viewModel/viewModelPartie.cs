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
    class viewModelPartie : viewModelBase
    {
        //DAO

        private DaoHoraire _daoHoraire;
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        private DaoPartie _daoPartie;
        private DaoObstacle _daoObstacle;
        private DaoJoueur _daoJoueur;

        private Partie _activePartie;

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

        public viewModelPartie(DaoHoraire daoHoraire, DaoSite daoSite, DaoSalle daoSalle, DaoPartie daoPartie,
            DaoObstacle daoObstacle, DaoJoueur daoJoueur, Partie activePartie)
        {
            _daoHoraire = daoHoraire;
            _daoSite = daoSite;
            _daoSalle = daoSalle;
            _daoPartie = daoPartie;
            _daoObstacle = daoObstacle;
            _daoJoueur = daoJoueur;
            _activePartie = activePartie;
        }

        public ObservableCollection<Joueur> ListJoueur
        {
            get => _listJoueur;
            set => _listJoueur = value;
        }

        public ObservableCollection<Joueur> ListJoueurPartie
        {
            get => _listJoueurPartie;
            set => _listJoueurPartie = value;
        }

        public ObservableCollection<Obstacle> ListObstacle
        {
            get => _listObstacle;
            set => _listObstacle = value;
        }

        public ObservableCollection<Obstacle> ListObstaclePartie
        {
            get => _listObstaclePartie;
            set => _listObstaclePartie = value;
        }

        public Joueur SelectedJoueur
        {
            get => _selectedJoueur;
            set
            {
                _selectedJoueur = value;
                OnPropertyChanged("SelectedJoueur");
            }
        }

        public Joueur SelectedJoueurPartie
        {
            get => _selectedJoueurPartie;
            set
            {
                _selectedJoueurPartie = value;
                OnPropertyChanged("SelectedJoueurPartie");
            }
        }

        public Obstacle SelectedObstacle
        {
            get => _selectedObstacle;
            set
            {
                _selectedObstacle = value;
                OnPropertyChanged("SelectedObstacle");
            }
        }
    }
}