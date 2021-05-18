using System;
using System.Collections.ObjectModel;
using Direction.Models;
using Model.Data;

namespace Direction.ViewModels
{
    public class DashboardViewModel : AbstractViewModel
    {
        private DateTime _selectedDate;
        private ObservableCollection<City> _cityList;
        private readonly DaoSite _daoSite;
        private readonly DaoPartie _daoPartie;

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
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();

                var newCityList = new ObservableCollection<City>();
                foreach (var site in _daoSite.GetAllSite())
                {
                    var newCity = new City(site.Ville);
                    foreach (var salle in site.LstSalle)
                    {
                        var newRoom = new Room(
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