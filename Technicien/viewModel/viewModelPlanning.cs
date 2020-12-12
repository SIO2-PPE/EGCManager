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
    class viewModelPlanning : viewModelBase
    {
        //DAO
        //private DaoHoraire _daoHoraire;
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        //LISTS
        private ObservableCollection<Partie> _listPlannings;
        private ObservableCollection<Site> _listSites;
        private ObservableCollection<Salle> _listSalles;
        //SELECTIONS
        private Partie _selectedPlanning;
        private DateTime _datePlanning;
        private Site _selectedSite;
        private Salle _selectedSalle;


        public viewModelPlanning(/*DaoHoraire daoHoraire,*/ DaoSite daoSite, DaoSalle daoSalle)
        {
            //_daoHoraire = daoHoraire;
            _daoSalle = daoSalle;
            _daoSite = daoSite;
            
            _listSalles = new ObservableCollection<Salle>();
            ListSites = new ObservableCollection<Site>(_daoSite.GetAllSite());
            
            DatePlanning = DateTime.Now;
        }

        public ObservableCollection<Partie> ListPlannings
        {
            get => _listPlannings;
            set => _listPlannings = value;
        }

        public ObservableCollection<Site> ListSites
        {
            get => _listSites;
            set { _listSites = value;
                SelectedSite = _listSites.First();
            }
        }

        public ObservableCollection<Salle> ListSalles
        {
            get => _listSalles;
            set { _listSalles = value;
                SelectedSalle = _listSalles.First();
            }
        }

        public Partie SelectedPlanning
        {
            get => _selectedPlanning;
            set => _selectedPlanning = value;
        }

        public DateTime DatePlanning
        {
            get => _datePlanning;
            set => _datePlanning = value;
        }

        public Site SelectedSite
        {
            get => _selectedSite;
            set
            {
                _selectedSite = value;
                RefreshListSalle();
                SelectedSalle = ListSalles.First();
                OnPropertyChanged("SelectedSite");
                OnPropertyChanged("ListSalles");
                OnPropertyChanged("SelectedSalle");
            }
        }

        public Salle SelectedSalle
        {
            get => _selectedSalle;
            set
            {
                _selectedSalle = value;
                OnPropertyChanged("SelectedSalle");
            }
        }
        
        private void RefreshListSalle()
        {
            _listSalles.Clear();
            foreach (Salle salle in _daoSalle.GetBySite(_selectedSite))
            {
                ListSalles.Add(salle);
            }
        }
    }
}