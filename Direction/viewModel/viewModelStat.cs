using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Model.Business;
using Model.Data;

namespace Direction.viewModel
{
    class ViewModelStat : ViewModelBase
    {
        #region Attributs

        // DAO
        private DaoPartie _daoPartie;

        private WrapPanel _statWrapPanel;

        private DateTime _selectedDate;

        private List<string> _listSalles;

        #endregion

        #region Constructeur

        public ViewModelStat(DaoPartie daoPartie, WrapPanel statWrapPanel, List<string> lstSalle)
        {
            // DAO
            _daoPartie = daoPartie;

            _statWrapPanel = statWrapPanel;
            _listSalles = lstSalle;
            SelectedDate = DateTime.Now;

            
        }

        #endregion

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged("SelectedDate");
            }
        }
    }
}