using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Direction.viewModel
{
    class ViewModelSite : ViewModelBase
    {
        #region Attributs
        // DAO
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        // LISTES
        private ObservableCollection<Site> _listSites;
        private ObservableCollection<Salle> _listSalles;
        private ObservableCollection<Theme> _listThemes;
        // SELECTION
        private Site _selectedSite;
        private Salle _selectedSalle;
        // COMMANDES
        private ICommand updateCommand;
        private ICommand addCommand;
        private ICommand deleteCommand;
        #endregion

        #region Constructeur
        public ViewModelSite(DaoSite daoSite, DaoSalle daoSalle)
        {
            _daoSite = daoSite;
            _daoSalle = daoSalle;
            
            _listSites = new ObservableCollection<Site>();
            _listSalles = new ObservableCollection<Salle>();
            _listThemes = new ObservableCollection<Theme>();

            // _selectedSite = new Site();
            // _selectedSalle = new Salle();
            
        }
        #endregion

        /*
        #region Liaison Binding
        public ObservableCollection<Equipe> ListEquipes { get => listEquipes; set => listEquipes = value; }
        public ObservableCollection<Joueur> ListJoueurs { get => listJoueurs; set => listJoueurs = value; }
        public Equipe SelectedEquipe
        {
            get => selectedEquipe;
            set
            {
                if (selectedEquipe != value &&
                    selectedEquipe != null)
                {
                    selectedEquipe = value;
                    ListJoueurs = new ObservableCollection<Joueur>(daoJoueur.SelectByEquipe(selectedEquipe.Id));

                    OnPropertyChanged("SelectedEquipe");
                    OnPropertyChanged("ListJoueurs");
                }
            }
        }
        public Joueur SelectedJoueur
        {
            get => selectedJoueur;
            set
            {
                if (selectedJoueur != value &&
                    selectedJoueur != null)
                {
                    MessageBox.Show("alo");
                    selectedJoueur = value;
                    Nom = selectedJoueur.Nom;
                    DateNaiss = selectedJoueur.DateNaissance;
                    DateEntree = selectedJoueur.DateEntree;
                    Pays = selectedJoueur.Pays;
                    Poste = selectedJoueur.Poste;

                    OnPropertyChanged("SelectedJoueur");
                    OnPropertyChanged("Nom");
                    OnPropertyChanged("DateNaiss");
                    OnPropertyChanged("DateEntree");
                    OnPropertyChanged("Pays");
                    OnPropertyChanged("Poste");
                }
            }
        }
        /*public Joueur SelectedJoueur
        {
            get => selectedJoueur;
            set
            {
                if (activeFromage != value)
                {
                    activeFromage = value;
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Origin");
                    OnPropertyChanged("Creation");
                    OnPropertyChanged("Image");
                    OnPropertyChanged("ImageSource");
                }
            }
        }#1#
        public string Nom
        {
            get => selectedJoueur.Nom;
            set
            {
                if (selectedJoueur.Nom != value)
                {
                    selectedJoueur.Nom = value;
                    OnPropertyChanged("Nom");
                }
            }
        }
        public DateTime DateNaiss
        {
            get => selectedJoueur.DateNaissance;
            set
            {
                if (selectedJoueur.DateNaissance != value)
                {
                    selectedJoueur.DateNaissance = value;
                    OnPropertyChanged("DateNaiss");
                }
            }
        }
        public DateTime DateEntree
        {
            get => selectedJoueur.DateEntree;
            set
            {
                if (selectedJoueur.DateEntree != value)
                {
                    selectedJoueur.DateNaissance = value;
                    OnPropertyChanged("DateEntree");
                }
            }
        }
        public Pays Pays
        {
            get => selectedJoueur.Pays;
            set
            {
                if (selectedJoueur.Pays != value)
                {
                    selectedJoueur.Pays = value;
                    OnPropertyChanged("Pays");
                }
            }
        }
        public Poste Poste
        {
            get => selectedJoueur.Poste;
            set
            {
                if (selectedJoueur.Poste != value)
                {
                    selectedJoueur.Poste = value;
                    OnPropertyChanged("Poste");
                }
            }
        }
        #endregion

        #region Commande (boutons)
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateJoueur(), () => true);
                }
                return this.updateCommand;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(() => DeleteJoueur(), () => true);
                }
                return this.deleteCommand;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new RelayCommand(() => AddJoueur(), () => true);
                }
                return this.addCommand;
            }
        }

        #endregion

        #region Action
        private void UpdateJoueur()
        {
            if (IsSelected())
            {
                this.daoJoueur.update(this.selectedJoueur, this.selectedEquipe);
                MessageBox.Show("Le joueur à bien été mis à jour");
            }
        }
        private void DeleteJoueur()
        {
            if (IsSelected())
            {
                this.daoJoueur.delete(selectedJoueur);
                MessageBox.Show("Le joueur à bien été supprimé");
            }
        }
        private void AddJoueur()
        {
            MessageBox.Show("ba non");
        }
        #endregion

        #region Autre méthode
        private bool IsSelected()
        {
            if (SelectedJoueur.Nom != "")
                return true;
            else
            {
                MessageBox.Show("Il faut selectionner un fromage");
                return false;
            }
        }
        #endregion*/
    }
}