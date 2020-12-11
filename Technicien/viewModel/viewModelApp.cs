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
        private ObservableCollection<Salle> listSalle;

       
        public Site selectedsite;
        public Salle selectedsalle;

       // public ObservableCollection<Partie> ListPlannnings { get => listPlannning; set => listPlannning = value; }
        public ObservableCollection<Site> ListSites { get => listSite; set { 
                listSite = value; if (listSite.First() != null) { SelectedSite = listSite.First(); }
            } }
        public ObservableCollection<Salle> ListSalles {
                get => listSalle; set {
                    listSalle = value; if (listSalle.First() != null) { SelectedSalle = listSalle.First(); }
                }
            }


        public Site SelectedSite
        {
            get => selectedsite;
            set
            {

                if (value != null && value != selectedsite)
                {
                    selectedsite = value;
                    listSite.Clear();
                    foreach (Site site in vmdaoSite.GetAllSite())
                    {
                        foreach (Salle salle in ListSalles)
                        {
                            if (salle.Site.Id == site.Id) salle = salle;
                        }
                        ListSalles.Add(salle);
                    }
                    OnPropertyChanged("SelectedSalle");
                }
            }
        }

        public Salle SelectedSalle
        {
            get => selectedsalle;
            set
            {

                if (value != null && value != selectedsalle)
                {
                    selectedsalle = value;
                    listSalle.Clear();
                    OnPropertyChanged("SelectedSalle");
                }
            }
        }

        public viewModelApp(/*DaoHoraire thedaohoraire,*/DaoSite thedaosite,DaoSalle thedaosalle)
        {
         //   vmdaoHoraire = thedaohoraire;
            vmdaoSite = thedaosite;
            vmdaoSalle = thedaosalle;

            listSite = new ObservableCollection<Site>(thedaosite.GetAllSite());
            listSalle = new ObservableCollection<Salle>(thedaosalle.GetBySite(SelectedSite));

            selectedsite = ListSites.First();
            selectedsalle = ListSalles.First();

            // listPlannning = new ObservableCollection<Partie>(thedaohoraire.GetPlanning());   afficher les horaire

        }
        
        




    }
}
