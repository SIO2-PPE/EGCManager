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
    class viewModelApp : viewModelBase
    {
        private DaoHoraire vmdaoHoraire;
        private DaoJoueur vmdaoJoueur;
        private DaoObstacle vmdaoObstacle;
        private DaoPartie vmdaoPartie;
        private DaoSalle vmdaoSalle;
        private DaoSite vmdaoSite;
        
        private ObservableCollection<Site> listSite;
        
        public Site selectedsite;

       // public ObservableCollection<Partie> ListPlannnings { get => listPlannning; set => listPlannning = value; }
        public ObservableCollection<Site> ListSites { get => listSite; set { 
                listSite = value; if (listSite.First() != null) { SelectedSite = listSite.First(); }
            } }


        public Site SelectedSite
        {
            get => selectedsite;
            set
            {

                if (value != null && value != selectedsite)
                {
                    selectedsite = value;
                    listSite.Clear();
                    OnPropertyChanged("SelectedSite");
                }
            }
        }

        public viewModelApp(/*DaoHoraire thedaohoraire,*/DaoSite thedaosite)
        {
         //   vmdaoHoraire = thedaohoraire;
            vmdaoSite = thedaosite;


            listSite = new ObservableCollection<Site>(thedaosite.GetAllSite());
            selectedsite = ListSites.First();

            // listPlannning = new ObservableCollection<Partie>(thedaohoraire.GetPlanning());   afficher les horaire

        }
        
        




    }
}
