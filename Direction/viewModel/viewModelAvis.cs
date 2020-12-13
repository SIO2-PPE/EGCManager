using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Direction.viewModel
{
    class ViewModelAvis : ViewModelBase
    {
        #region Attributs

        // DAO
        private DaoTheme _daoTheme;
        private DaoAvis _daoAvis;

        // LISTES
        private ObservableCollection<Theme> _listThemes;
        private ObservableCollection<Avis> _listAvis;

        // SELECTIONS
        private Theme _selectedTheme;
        private Avis _selectedAvis;
        
        // AFFICHAGE
        private string _fullAvis;
        private string _pseudoJoueur;
        private string _dateAvis;

        // COMMANDES

        #endregion

        #region Constructeur

        public ViewModelAvis(DaoTheme daoTheme, DaoAvis daoAvis)
        {
            // DAO
            _daoTheme = daoTheme;
            _daoAvis = daoAvis;
            // LISTES
            _listAvis = new ObservableCollection<Avis>();
            ListThemes = new ObservableCollection<Theme>(_daoTheme.GetAllTheme());
            // AFFICHAGE
            FullAvis = "";
            PseudoJoueur = "Joueur : ";
            DateAvis = "Date : ";
        }

        #endregion

        #region BINDING LISTES

        public ObservableCollection<Theme> ListThemes
        {
            get => _listThemes;
            set
            {
                _listThemes = value;
                /*if (_listThemes.First() != null) */SelectedTheme = _listThemes.First();
                OnPropertyChanged("ListThemes");
            }
        }

        #endregion

        #region BINDING SELECTIONS

        public Theme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (value != null &&
                    value != _selectedTheme)
                {
                    _selectedTheme = value;
                    _listAvis.Clear();
                    foreach (Avis avis in _daoAvis.GetForTheme(SelectedTheme))
                    {
                        _listAvis.Add(avis);
                    }

                    SelectedAvis = _listAvis.First();
                    OnPropertyChanged("SelectedTheme");
                    OnPropertyChanged("ListAvis");
                }
            }
        }

        public Avis SelectedAvis
        {
            get => _selectedAvis;
            set
            {
                _selectedAvis = value;
                
                OnPropertyChanged("SelectedAvis");
            }
        }

        #endregion

        #region BINDING AFFICHAGE

        public string FullAvis
        {
            get => _fullAvis;
            set => _fullAvis = value;
        }

        public string PseudoJoueur
        {
            get => _pseudoJoueur;
            set => _pseudoJoueur = value;
        }

        public string DateAvis
        {
            get => _dateAvis;
            set => _dateAvis = value;
        }

        #endregion

        #region Commande (boutons)

        
        
        #endregion

        #region Action

       
        
        #endregion

        #region Autre methode

        private bool IsNotNull(dynamic val, string msg, bool isnot = true)
        {
            bool r = val != null;
            r = r == isnot;
            if (!r) MessageBox.Show(msg);
            return r;
        }

        #endregion
    }
}