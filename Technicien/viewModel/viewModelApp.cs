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
        //DAO
        private DaoHoraire vmdaoHoraire;
        private DaoJoueur vmdaoJoueur;
        private DaoObstacle vmdaoObstacle;
        private DaoPartie vmdaoPartie;
        private DaoSalle vmdaoSalle;
        private DaoSite vmdaoSite;
        //LISTE
        private ObservableCollection<Site> listSite;
        private ObservableCollection<Salle> listSalle;

        //SELECTION
        public Site selectedsite;
        public Salle selectedsalle;
        //COMMANDE
        public viewModelApp(/*DaoHoraire thedaohoraire,*/DaoSite thedaosite, DaoSalle thedaosalle)
        {
            //DAO
            //   vmdaoHoraire = thedaohoraire;
            vmdaoSite = thedaosite;
            vmdaoSalle = thedaosalle;
            //LISTE
            listSalle = new ObservableCollection<Salle>();
            listSite = new ObservableCollection<Site>(thedaosite.GetAllSite());
            selectedsite = listSite.First();
            //listSalle = new ObservableCollection<Salle>(thedaosalle.GetBySite(selectedsite));

            //selection

            selectedsalle = listSalle.First();

            // listPlannning = new ObservableCollection<Partie>(thedaohoraire.GetPlanning());   afficher les horaire

        }


        // public ObservableCollection<Partie> ListPlannnings { get => listPlannning; set => listPlannning = value; }
        public ObservableCollection<Site> ListSites
        {
            get => listSite; set
            {
                listSite = value; if (listSite.First() != null) { SelectedSite = listSite.First(); }
            }
        }
        public ObservableCollection<Salle> ListSalles
        {
            get => listSalle; set
            {
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
                    ListSalles.Clear();
                    foreach (Salle salle in vmdaoSalle.GetBySite(selectedsite))
                    {
                        ListSalles.Add(salle);
                    }

                }
                OnPropertyChanged("Site");
                OnPropertyChanged("ListSalles");
                OnPropertyChanged("Salle");
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
                OnPropertyChanged("Salle");
            }
        }
    }








}

