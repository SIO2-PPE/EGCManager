using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model.Business;
using Model.Data;
using Direction.Models;

namespace Direction.ViewModels
{
    public class DashboardViewModel : AbstractViewModel
    {
        private DateTime _selectedDate;
        private ObservableCollection<City> _cityList;
        private DaoSite _daoSite;
        private DaoPartie _daoPartie;

        public DashboardViewModel(DaoPartie daoPartie, DaoSite daoSite)
        {
            _daoPartie = daoPartie;
            _daoSite = daoSite;
            SelectedDate = DateTime.Now;
        }

        public ObservableCollection<City> CityList
        {
            get => _cityList;
            set
            {
                _cityList = value;
                OnPropertyChanged("ListSite");
            }
        }

        public DateTime SelectedDate
        { 
            get => _selectedDate; 
            set
            {
                _selectedDate = value;
                OnPropertyChanged("SelectedDate");

                ObservableCollection<City> newCityList = new ObservableCollection<City>();
                foreach (Site site in _daoSite.GetAllSite())
                {
                    City newCity = new City(site.Ville);
                    foreach (Salle salle in site.LstSalle)
                    {
                        Room newRoom = new Room(
                            salle.ToString(),
                            _daoPartie.NbPartie(salle, value)
                        );
                        newCity.Rooms.Add(newRoom);
                    }
                    newCityList.Add(newCity);
                }
                CityList = newCityList;
            }
        }
    }
}
