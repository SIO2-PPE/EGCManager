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
        private DaoHoraire _daoHoraire;
        private DaoSite _daoSite;
        private DaoSalle _daoSalle;
        private DaoPartie _daoPartie;
        
        //LISTS
        private ObservableCollection<Partie> _listPlanning;
        private ObservableCollection<Site> _listSites;
        private ObservableCollection<Salle> _listSalles;
        
        //SELECTIONS
        private Partie _selectedPlanning;
        private DateTime _datePlanning;
        private Site _selectedSite;
        private Salle _selectedSalle;


        public viewModelPlanning(DaoSite daoSite, DaoSalle daoSalle,DaoPartie daoPartie,DaoHoraire daoHoraire)
        {
            _daoHoraire = daoHoraire;
            _daoPartie = daoPartie;
            _daoSalle = daoSalle;
            _daoSite = daoSite;


            _listPlanning = new ObservableCollection<Partie>();
            _listSalles = new ObservableCollection<Salle>();
            ListSites = new ObservableCollection<Site>(_daoSite.GetAllSite());
            DatePlanning = DateTime.Now;
        }

        public ObservableCollection<Partie> ListPlanning
        {
            get => _listPlanning;
            set
            {
                _listPlanning = value;
                
            }
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
                
            }
        }

        

        public DateTime DatePlanning
        {
            get => _datePlanning;
            set
            {
               
                _datePlanning = value;
                RefreshListPlanning();
                OnPropertyChanged("DatePlanning");

            } 
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
                RefreshListPlanning();
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

        private void RefreshListPlanning()
        {
            _listPlanning.Clear();
            foreach (Partie partie in _daoHoraire.GetPlanning(_datePlanning, _selectedSalle,_selectedSite))
            {
                ListPlanning.Add(partie);
            }
           
            OnPropertyChanged("ListPlanning");
            
        }
        
    }
}