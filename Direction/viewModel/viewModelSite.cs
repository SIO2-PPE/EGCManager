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
        private ObservableCollection<Horaire> _listHoraires;
        private ObservableCollection<Horaire> _listHorairesSite;
        private ObservableCollection<Theme> _listThemes;
        // SELECTIONS
        private Site _selectedSite;
        private Salle _selectedSalle;
        private Horaire _selectedHoraire;
        private Horaire _selectedHoraireSite;
        private DateTime _dateNewDate;
        private Theme _selectedTheme;
        private string _nameNewTheme;
        // COMMANDES
        private ICommand _addHoraireCommand;
        private ICommand _assigneHoraireCommand;
        private ICommand _dissosHoraireCommand;
        private ICommand _assigneToSalleCommand;
        private ICommand _deleteThemeCommand;
        private ICommand _addThemeCommand;
        #endregion
        
        #region Constructeur
        public ViewModelSite(DaoSite daoSite, DaoSalle daoSalle)
        {
            // DAO
            _daoSite = daoSite;
            _daoSalle = daoSalle;
            // LISTES
            _listSites = new ObservableCollection<Site>();
            _listSalles = new ObservableCollection<Salle>();
            _listHoraires = new ObservableCollection<Horaire>();
            _listHorairesSite = new ObservableCollection<Horaire>();
            _listThemes = new ObservableCollection<Theme>();
            // SELECTIONS
            _selectedSite = new Site();
            _selectedSalle = new Salle();
            _selectedHoraire = new Horaire();
            _selectedHoraireSite = new Horaire();
            _dateNewDate = new DateTime();
            _selectedTheme = new Theme();
            _nameNewTheme = "";
        }
        #endregion
        
        #region Liaison Binding
        // LISTES
        public ObservableCollection<Site> ListSites { get => _listSites; set => _listSites = value; }
        public ObservableCollection<Salle> ListSalles { get => _listSalles; set => _listSalles = value; }
        public ObservableCollection<Horaire> ListHoraires { get => _listHoraires; set => _listHoraires = value; }
        public ObservableCollection<Horaire> ListHorairesSite { get => _listHorairesSite; set => _listHorairesSite = value; }
        public ObservableCollection<Theme> ListThemes { get => _listThemes; set => _listThemes = value; }
        // SELECTIONS
        public Site SelectedSite
        {
            get => _selectedSite;
            set => _selectedSite = value;
        }
        public Salle SelectedSalle
        {
            get => _selectedSalle;
            set => _selectedSalle = value;
        }
        public Horaire SelectedHoraire
        {
            get => _selectedHoraire;
            set => _selectedHoraire = value;
        }
        public Horaire SelectedHoraireSite
        {
            get => _selectedHoraireSite;
            set => _selectedHoraireSite = value;
        }
        public DateTime DateNewDate
        {
            get => _dateNewDate;
            set => _dateNewDate = value;
        }
        public Theme SelectedTheme
        {
            get => _selectedTheme;
            set => _selectedTheme = value;
        }
        public string NameNewTheme
        {
            get => _nameNewTheme;
            set => _nameNewTheme = value;
        }
        #endregion
        
        #region Commande (boutons)
        public ICommand AddHoraireCommand
        {
            get
            {
                if (_addHoraireCommand == null)
                {
                    _addHoraireCommand = new RelayCommand(() => AddHoraire(), () => true);
                }
                return _addHoraireCommand;
            }
        }
        public ICommand AssigneHoraireCommand
        {
            get
            {
                if (_assigneHoraireCommand == null)
                {
                    _assigneHoraireCommand = new RelayCommand(() => AssigneHoraire(), () => true);
                }
                return _assigneHoraireCommand;
            }
        }
        public ICommand DissosHoraireCommand
        {
            get
            {
                if (_dissosHoraireCommand == null)
                {
                    _dissosHoraireCommand = new RelayCommand(() => DissosHoraire(), () => true);
                }
                return _dissosHoraireCommand;
            }
        }
        public ICommand AssigneToSalleCommand
        {
            get
            {
                if (_assigneToSalleCommand == null)
                {
                    _assigneToSalleCommand = new RelayCommand(() => AssigneToSalle(), () => true);
                }
                return _assigneToSalleCommand;
            }
        }
        public ICommand DeleteThemeCommand
        {
            get
            {
                if (_deleteThemeCommand == null)
                {
                    _deleteThemeCommand = new RelayCommand(() => DeleteTheme(), () => true);
                }
                return _deleteThemeCommand;
            }
        }
        public ICommand AddThemeCommand
        {
            get
            {
                if (_addThemeCommand == null)
                {
                    _addThemeCommand = new RelayCommand(() => AddTheme(), () => true);
                }
                return _addThemeCommand;
            }
        }
        #endregion

        #region Action
        private void AddHoraire()
        {
            
        }
        private void AssigneHoraire()
        {
            
        }
        private void DissosHoraire()
        {
            
        }
        private void AssigneToSalle()
        {
            
        }
        private void DeleteTheme()
        {
            
        }
        private void AddTheme()
        {
            
        }
        #endregion
    }
}