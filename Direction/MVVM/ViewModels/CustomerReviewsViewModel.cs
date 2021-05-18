using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Model.Business;
using Model.Data;

namespace Direction.ViewModels
{
    public class CustomerReviewsViewModel : AbstractViewModel
    {
        #region Attributs

        // DAO
        private readonly DaoTheme _daoTheme;
        private readonly DaoAvis _daoAvis;

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

        public CustomerReviewsViewModel(DaoTheme daoTheme, DaoAvis daoAvis)
        {
            // DAO
            _daoTheme = daoTheme;
            _daoAvis = daoAvis;
            // AFFICHAGE
            FullAvis = "";
            PseudoJoueur = "Joueur : ";
            DateAvis = "Date : ";
            // LISTES
            _listAvis = new ObservableCollection<Avis>();
            ListThemes = new ObservableCollection<Theme>(_daoTheme.GetAllTheme());
        }

        #endregion

        #region BINDING LISTES

        public ObservableCollection<Theme> ListThemes
        {
            get => _listThemes;
            set
            {
                _listThemes = value;
                /*if (_listThemes.First() != null) */
                SelectedTheme = _listThemes.First();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Avis> ListAvis
        {
            get => _listAvis;
            set
            {
                _listAvis = value;

                OnPropertyChanged();
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
                    foreach (var avis in _daoAvis.GetForTheme(SelectedTheme)) _listAvis.Add(avis);

                    try
                    {
                        SelectedAvis = _listAvis.First();
                    }
                    catch
                    {
                    }

                    OnPropertyChanged();
                    OnPropertyChanged("ListAvis");
                }
            }
        }

        public Avis SelectedAvis
        {
            get => _selectedAvis;
            set
            {
                if (value != null)
                {
                    _selectedAvis = value;
                    FullAvis = _selectedAvis.Commentaire;
                    PseudoJoueur = "Joueur : " + _selectedAvis.Joueur.Pseudo;
                    DateAvis = "Date : " + _selectedAvis.Date.ToString("d");
                    OnPropertyChanged();
                }
                else
                {
                    FullAvis = "";
                    PseudoJoueur = "Joueur :";
                    DateAvis = "Date : ";
                }
            }
        }

        #endregion

        #region BINDING AFFICHAGE

        public string FullAvis
        {
            get => _fullAvis;
            set
            {
                _fullAvis = value;
                OnPropertyChanged();
            }
        }

        public string PseudoJoueur
        {
            get => _pseudoJoueur;
            set
            {
                _pseudoJoueur = value;
                OnPropertyChanged();
            }
        }

        public string DateAvis
        {
            get => _dateAvis;
            set
            {
                _dateAvis = value;
                OnPropertyChanged();
            }
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