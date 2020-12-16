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
        private Obstacle _selectedObstaclePartie;


        //COMMANDE
        private ICommand _AddJoueurPartie;
        private ICommand _AddJoueur;
        private ICommand _researchJoueur;
        private ICommand _DelJoueurPartie;
        private ICommand _AddObstacle;
        private ICommand _DelObstacle;

        private string researchText;


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

            _listJoueur = new ObservableCollection<Joueur>(daoJoueur.GetAllJoueur());
            _listObstacle = new ObservableCollection<Obstacle>(daoObstacle.GetAllObstacle());
            _listJoueurPartie = new ObservableCollection<Joueur>();
            _listObstaclePartie = new ObservableCollection<Obstacle>();
            researchText = "!";
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
        public Obstacle SelectedObstaclePartie
        {
            get => _selectedObstaclePartie;
            set
            {
                _selectedObstaclePartie = value;
                OnPropertyChanged("SelectedObstaclePartie");
            }
        }
        public string ResearchText
        {
            get
            {
                return researchText;
            }
            set
            {
                if (value != researchText)
                {
                    researchText = value;
                    OnPropertyChanged("ResearchText");
                }
            }
        }


        //commande
        public ICommand ResearchJoueur
        {
            get
            {
                if (this._researchJoueur == null)
                {
                    this._researchJoueur = new RelayCommand(() => RechercheJoueur(), () => true);
                }
                return this._researchJoueur;
            }
        }
        //methode commande
        private void RechercheJoueur()
        {
            if (researchText == "")
            {
                _listJoueur.Clear();
                foreach (Joueur joueur in _daoJoueur.GetAllJoueur())
                {
                    _listJoueur.Add(joueur);
                }
            }
            else
            {
                _listJoueur.Clear();
               
                foreach (Joueur joueur in  _daoJoueur.GetJoueurByPseudo(researchText))
                {
                _listJoueur.Add(joueur);
                }
                


                
            }
        }
        //Refresh liste

    }
}