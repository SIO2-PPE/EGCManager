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

        private DaoPartie _daoPartie;
        private DateTime _selectedDate;

        private string _annecySalle1Nom;
        private string _annecySalle1Stat;
        private string _annecySalle2Nom;
        private string _annecySalle2Stat;
        private string _annecySalle3Nom;
        private string _annecySalle3Stat;
        private string _annecySalle4Nom;
        private string _annecySalle4Stat;
        private string _thononSalle1Nom;
        private string _thononSalle1Stat;
        private string _thononSalle2Nom;
        private string _thononSalle2Stat;
        private string _bonnevilleSalle1Nom;
        private string _bonnevilleSalle1Stat;
        private string _chamonixSalle1Nom;
        private string _chamonixSalle1Stat;

        #endregion

        #region Constructeur
        public ViewModelStat(DaoPartie daoPartie)
        {
            // DAO
            _daoPartie = daoPartie;
            SelectedDate = DateTime.Now;

            
        }
        #endregion

        #region BINDING
        
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged("SelectedDate");
                
                List<Site> ls = new List<Site>();
                int i = 0;
                AnnecySalle1Nom      = ls[0].LstSalle[
                AnnecySalle1Stat     = ls[1].LstSalle[
                AnnecySalle2Nom      = ls[2].LstSalle[
                AnnecySalle2Stat     = ls[3].LstSalle[
                AnnecySalle3Nom      = ls[4].LstSalle[
                AnnecySalle3Stat     = ls[5].LstSalle[
                AnnecySalle4Nom      = ls[6].LstSalle[
                AnnecySalle4Stat     = ls[7].LstSalle[
                ThononSalle1Nom      = ls[8].LstSalle[
                ThononSalle1Stat     = ls[9].LstSalle[
                ThononSalle2Nom      = ls[10].LstSalle[
                ThononSalle2Stat     = ls[11].LstSalle[
                BonnevilleSalle1Nom  = ls[12].LstSalle[
                BonnevilleSalle1Stat = ls[13].LstSalle[
                ChamonixSalle1Nom    = ls[14].LstSalle[
                ChamonixSalle1Stat   = ls[15].LstSalle[
            }
        }

        public string AnnecySalle1Nom
        {
            get => _annecySalle1Nom;
            set
            {
                _annecySalle1Nom = value;
                OnPropertyChanged("AnnecySalle1Nom");
            }
        }

        public string AnnecySalle1Stat
        {
            get => _annecySalle1Stat;
            set
            {
                _annecySalle1Stat = value;
                OnPropertyChanged("AnnecySalle1Stat");
            }
        }

        public string AnnecySalle2Nom
        {
            get => _annecySalle2Nom;
            set
            {
                _annecySalle2Nom = value;
                OnPropertyChanged("AnnecySalle2Nom");
            }
        }

        public string AnnecySalle2Stat
        {
            get => _annecySalle2Stat;
            set
            {
                _annecySalle2Stat = value;
                OnPropertyChanged("AnnecySalle2Stat");
            }
        }

        public string AnnecySalle3Nom
        {
            get => _annecySalle3Nom;
            set
            {
                _annecySalle3Nom = value;
                OnPropertyChanged("AnnecySalle3Nom");
            }
        }

        public string AnnecySalle3Stat
        {
            get => _annecySalle3Stat;
            set
            {
                _annecySalle3Stat = value;
                OnPropertyChanged("AnnecySalle3Stat");
            }
        }

        public string AnnecySalle4Nom
        {
            get => _annecySalle4Nom;
            set
            {
                _annecySalle4Nom = value;
                OnPropertyChanged("AnnecySalle4Nom");
            }
        }

        public string AnnecySalle4Stat
        {
            get => _annecySalle4Stat;
            set
            {
                _annecySalle4Stat = value;
                OnPropertyChanged("AnnecySalle4Stat");
            }
        }

        public string ThononSalle1Nom
        {
            get => _thononSalle1Nom;
            set
            {
                _thononSalle1Nom = value;
                OnPropertyChanged("ThononSalle1Nom");
            }
        }

        public string ThononSalle1Stat
        {
            get => _thononSalle1Stat;
            set
            {
                _thononSalle1Stat = value;
                OnPropertyChanged("ThononSalle1Stat");
            }
        }

        public string ThononSalle2Nom
        {
            get => _thononSalle2Nom;
            set
            {
                _thononSalle2Nom = value;
                OnPropertyChanged("ThononSalle2Nom");
            }
        }

        public string ThononSalle2Stat
        {
            get => _thononSalle2Stat;
            set
            {
                _thononSalle2Stat = value;
                OnPropertyChanged("ThononSalle2Stat");
            }
        }

        public string BonnevilleSalle1Nom
        {
            get => _bonnevilleSalle1Nom;
            set
            {
                _bonnevilleSalle1Nom = value;
                OnPropertyChanged("BonnevilleSalle1Nom");
            }
        }

        public string BonnevilleSalle1Stat
        {
            get => _bonnevilleSalle1Stat;
            set
            {
                _bonnevilleSalle1Stat = value;
                OnPropertyChanged("BonnevilleSalle1Stat");
            }
        }

        public string ChamonixSalle1Nom
        {
            get => _chamonixSalle1Nom;
            set
            {
                _chamonixSalle1Nom = value;
                OnPropertyChanged("ChamonixSalle1Nom");
            }
        }

        public string ChamonixSalle1Stat
        {
            get => _chamonixSalle1Stat;
            set
            {
                _chamonixSalle1Stat = value;
                OnPropertyChanged("ChamonixSalle1Stat");
            }
        }

        #endregion
    }
}