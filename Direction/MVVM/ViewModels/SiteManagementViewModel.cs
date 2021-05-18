using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Direction.ViewModels
{
    public class SiteManagementViewModel : AbstractViewModel
    {
        #region Attributs

        // DAO
        private readonly DaoSite _daoSite;
        private readonly DaoSalle _daoSalle;
        private readonly DaoHoraire _daoHoraire;
        private readonly DaoTheme _daoTheme;
        private readonly DaoObstacle _daoObstacle;

        // LISTES
        private ObservableCollection<Site> _listSites;
        private ObservableCollection<Salle> _listSalles;

        // SELECTIONS
        private Site _selectedSite;
        private Salle _selectedSalle;
        private Horaire _selectedHoraire;
        private Horaire _selectedHoraireSite;
        private Obstacle _selectedObstacle;
        private DateTime _dateNewDate;
        private Theme _themeActif;
        private Theme _selectedTheme;
        private string _nameNewTheme;
        private string _nameNewObstacle;
        private string _errorTheme;
        private string _errorObstacle;
        private string _errorHoraire;

        // COMMANDES
        private ICommand _addHoraireCommand;
        private ICommand _assigneHoraireCommand;
        private ICommand _dissosHoraireCommand;
        private ICommand _assigneToSalleCommand;
        private ICommand _deleteThemeCommand;
        private ICommand _addThemeCommand;
        private ICommand _addObstacleCommand;
        private ICommand _removeObstacleCommand;

        #endregion

        #region Constructeur

        public SiteManagementViewModel(DaoSite daoSite, DaoSalle daoSalle, DaoHoraire daoHoraire, DaoTheme daoTheme,
            DaoObstacle daoObstacle)
        {
            // DAO
            _daoSite = daoSite;
            _daoSalle = daoSalle;
            _daoHoraire = daoHoraire;
            _daoTheme = daoTheme;
            _daoObstacle = daoObstacle;
            // LISTES
            _listSalles = new ObservableCollection<Salle>();
            ListThemes = new ObservableCollection<Theme>(_daoTheme.GetAllTheme());
            ListSites = new ObservableCollection<Site>(_daoSite.GetAllSite());
            ListHoraires = new ObservableCollection<Horaire>(_daoHoraire.GetAllHoraires());
            ListObstacles = new ObservableCollection<Obstacle>(_daoObstacle.GetAllObstacle());
            // SELECTIONS
            _selectedSite = _listSites.First();
            _selectedSalle = _listSalles.First();
            _selectedObstacle = ListObstacles.First();
            _selectedHoraire = new Horaire();
            _selectedHoraireSite = new Horaire();
            _dateNewDate = new DateTime();
            _nameNewTheme = "";
            _nameNewObstacle = "";
        }

        #endregion

        #region BINDING LISTES

        public ObservableCollection<Site> ListSites
        {
            get => _listSites;
            set
            {
                _listSites = value;
                if (_listSites.First() != null) SelectedSite = _listSites.First();
            }
        }

        public ObservableCollection<Salle> ListSalles
        {
            get => _listSalles;
            set
            {
                _listSalles = value;
                if (_listSalles.First() != null) SelectedSalle = _listSalles.First();
            }
        }

        public ObservableCollection<Horaire> ListHoraires { get; set; }

        public ObservableCollection<Horaire> ListHorairesSite { get; set; }

        public ObservableCollection<Theme> ListThemes { get; set; }

        public ObservableCollection<Obstacle> ListObstacles { get; set; }

        #endregion

        #region BINDING SELECTIONS

        public Site SelectedSite
        {
            get => _selectedSite;
            set
            {
                if (value != null &&
                    value != _selectedSite)
                {
                    _selectedSite = value;
                    RefreshListSalle();
                    SelectedSalle = ListSalles.First();
                    ListHorairesSite = new ObservableCollection<Horaire>(_daoHoraire.GetHorairesForSite(_selectedSite));
                    OnPropertyChanged();
                    OnPropertyChanged("ListSalles");
                    OnPropertyChanged("ListHorairesSite");
                }
            }
        }

        public Salle SelectedSalle
        {
            get => _selectedSalle;
            set
            {
                if (value != null &&
                    value != _selectedSalle)
                {
                    _selectedSalle = value;
                    ThemeActif = _selectedSalle.Theme;
                    OnPropertyChanged();
                }
            }
        }

        public Horaire SelectedHoraire
        {
            get => _selectedHoraire;
            set
            {
                if (value != null &&
                    value != _selectedHoraire)
                {
                    _selectedHoraire = value;

                    OnPropertyChanged();
                }
            }
        }

        public Horaire SelectedHoraireSite
        {
            get => _selectedHoraireSite;
            set
            {
                if (value != null &&
                    value != _selectedHoraireSite)
                {
                    _selectedHoraireSite = value;

                    OnPropertyChanged();
                }
            }
        }

        public DateTime DateNewDate
        {
            get => _dateNewDate;
            set
            {
                if (value != null &&
                    value != _dateNewDate)
                {
                    _dateNewDate = value;

                    OnPropertyChanged();
                }
            }
        }

        public Theme ThemeActif
        {
            get => _themeActif;
            set
            {
                if (value != null &&
                    value != _themeActif)
                {
                    _themeActif = value;

                    OnPropertyChanged();
                }
            }
        }

        public Theme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (value != null &&
                    value != _selectedTheme)
                {
                    _selectedTheme = value;

                    OnPropertyChanged();
                }
            }
        }

        public Obstacle SelectedObstacle
        {
            get => _selectedObstacle;
            set
            {
                if (value != null &&
                    value != _selectedObstacle)
                {
                    _selectedObstacle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NameNewTheme
        {
            get => _nameNewTheme;
            set
            {
                if (value != null &&
                    value != _nameNewTheme)
                {
                    _nameNewTheme = value;

                    OnPropertyChanged();
                }
            }
        }

        public string NameNewObstacle
        {
            get => _nameNewObstacle;
            set
            {
                if (value != null &&
                    value != _nameNewObstacle)
                {
                    _nameNewObstacle = value;

                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commande (boutons)

        public ICommand AddHoraireCommand
        {
            get
            {
                if (_addHoraireCommand == null) _addHoraireCommand = new RelayCommand(() => AddHoraire(), () => true);

                return _addHoraireCommand;
            }
        }

        public ICommand AssigneHoraireCommand
        {
            get
            {
                if (_assigneHoraireCommand == null)
                    _assigneHoraireCommand = new RelayCommand(() => AssigneHoraire(), () => true);

                return _assigneHoraireCommand;
            }
        }

        public ICommand DissosHoraireCommand
        {
            get
            {
                if (_dissosHoraireCommand == null)
                    _dissosHoraireCommand = new RelayCommand(() => DissosHoraire(), () => true);

                return _dissosHoraireCommand;
            }
        }

        public ICommand AssigneToSalleCommand
        {
            get
            {
                if (_assigneToSalleCommand == null)
                    _assigneToSalleCommand = new RelayCommand(() => AssigneToSalle(), () => true);

                return _assigneToSalleCommand;
            }
        }

        public ICommand DeleteThemeCommand
        {
            get
            {
                if (_deleteThemeCommand == null)
                    _deleteThemeCommand = new RelayCommand(() => DeleteTheme(), () => true);

                return _deleteThemeCommand;
            }
        }

        public ICommand AddThemeCommand
        {
            get
            {
                if (_addThemeCommand == null) _addThemeCommand = new RelayCommand(() => AddTheme(), () => true);

                return _addThemeCommand;
            }
        }

        public ICommand AddObstacleCommand
        {
            get
            {
                if (_addObstacleCommand == null)
                    _addObstacleCommand = new RelayCommand(() => AddObstacle(), () => true);

                return _addObstacleCommand;
            }
        }

        public ICommand RemoveObstacleCommand
        {
            get
            {
                if (_removeObstacleCommand == null)
                    _removeObstacleCommand = new RelayCommand(() => RemoveObstacle(), () => true);

                return _removeObstacleCommand;
            }
        }

        public string ErrorTheme
        {
            get => _errorTheme;
            set
            {
                _errorTheme = value;
                OnPropertyChanged("ErrorTheme");
            }
        }

        public string ErrorObstacle
        {
            get => _errorObstacle;
            set
            {
                _errorObstacle = value;
                OnPropertyChanged("ErrorObstacle");
            }
        }

        public string ErrorHoraire
        {
            get => _errorHoraire;
            set
            {
                _errorHoraire = value;
                OnPropertyChanged("ErrorHoraire");
            }
        }

        #endregion

        #region Action

        private void AddHoraire()
        {
            if (!_daoHoraire.Exist(DateNewDate.TimeOfDay))
            {
                var horaire = new Horaire(DateNewDate.TimeOfDay);
                _daoHoraire.New(ref horaire);
                ListHoraires.Add(horaire);
                SelectedHoraire = horaire;
                ErrorHoraire = "";
            }
            else ErrorHoraire = "Cet horaire existe déjà";
        }

        private void AssigneHoraire()
        {
            if (IsNotNull(SelectedHoraire, "Il faut sélectionner un horaire"))
            {
                _daoHoraire.AssigneToSite(SelectedHoraire, SelectedSite);
                ListHorairesSite.Add(SelectedHoraire);
            }
        }

        private void DissosHoraire()
        {
            if (IsNotNull(SelectedHoraireSite, "Il faut sélectionner un horaire"))
            {
                _daoHoraire.DissosToSite(SelectedHoraireSite, SelectedSite);
                ListHorairesSite.Remove(SelectedHoraireSite);
            }
        }

        private void AssigneToSalle()
        {
            if (IsNotNull(SelectedTheme, "Il faut sélectionner un thème"))
            {
                _daoTheme.AssgneToSalle(SelectedTheme, ref _selectedSalle);
                var activeSalle = _selectedSalle;
                var index = ListSalles.IndexOf(_selectedSalle);
                RefreshListSalle();
                SelectedSalle = ListSalles[index];
                ErrorTheme = "";
            }
        }

        private void DeleteTheme()
        {
            if (_daoTheme.IsNotUse(SelectedTheme))
            {
                _daoTheme.Delete(SelectedTheme);
                ListThemes.Remove(SelectedTheme);
            }
            else
            {
                ErrorTheme = "Ce thème est attribué à une salle ou l'a été";
            }
        }

        private void AddTheme()
        {
            if (NameNewTheme != "")
            {
                ListThemes.Add(_daoTheme.New(new Theme(NameNewTheme)));
                SelectedTheme = ListThemes.Last();
                NameNewTheme = "";
                ErrorTheme = "";
            }
            else
            {
                ErrorTheme = "Nom du thème obligatoire";
            }
        }

        private void AddObstacle()
        {
            if (NameNewObstacle != "")
            {
                ListObstacles.Add(_daoObstacle.New(new Obstacle(NameNewObstacle)));
                SelectedObstacle = ListObstacles.Last();
                NameNewObstacle = "";
                ErrorObstacle = "";
            }
            else
            {
                ErrorObstacle = "Nom de l'obstacle obligatoire";
            }
        }

        private void RemoveObstacle()
        {
            if (_daoObstacle.IsNotUse(SelectedObstacle))
            {
                _daoObstacle.Delete(SelectedObstacle);
                ListObstacles.Remove(SelectedObstacle);
                ErrorObstacle = "";
            }
            else
            {
                ErrorObstacle = "Cet obstacle est utilisé";
            }
        }

        #endregion

        #region Autre methode

        private bool IsNotNull(dynamic val, string msg, bool isnot = true)
        {
            bool r = val != null;
            r = r == isnot;
            if (!r) MessageBox.Show(msg);
            return r;
        }

        private void RefreshListSalle()
        {
            _listSalles.Clear();
            foreach (var salle in _daoSalle.GetBySite(_selectedSite))
            {
                foreach (var theme in ListThemes)
                    if (salle.Theme.Id == theme.Id)
                        salle.Theme = theme;

                ListSalles.Add(salle);
            }
        }

        #endregion
    }
}