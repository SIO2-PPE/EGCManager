using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Model.Business;
using Model.Data;

namespace Direction.ViewModels
{
    public class DashboardViewModel
    {
        private DaoSite _daoSite;
        private ObservableCollection<Site> _listSite;

        public DashboardViewModel(DaoPartie daoPartie, DaoSite daoSite)
        {
            _daoSite = daoSite;
            _listSite = new ObservableCollection<Site>(daoSite.GetAllSite());
            
            
        }

        public ObservableCollection<Site> ListSite
        {
            get => _listSite;
            set
            {
                _listSite = value;
            }
        }
    }
}
