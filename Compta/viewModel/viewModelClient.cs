using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Model.Business;
using Model.Data;
using Compta.viewModel;

namespace Compta.viewModel
{
    class viewModelClient : viewModelBase
    {
        private DaoClient vmDaoClient;
        private DaoFacture vmDaoFacture;
        private Client selectedClient = new Client();
        private Client activeClient = new Client();
        private Facture selectedFacture = new Facture();
        private Facture activeFacture = new Facture();
        private ICommand updateCommand;
        private ICommand createCommand;


        #region Constructeur
        public viewModelClient(DaoFacture thedaofacture, DaoClient thedaoclient)
        {
            vmDaoFacture = thedaofacture;
            vmDaoClient = thedaoclient;
        }
        #endregion

        #region Liaison Binding
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                if (selectedClient != value)
                {
                    selectedClient = value;
                    OnPropertyChanged("SelectedClient");
                    if (selectedClient != null)
                    {
                        ActiveClient = selectedClient;
                    }
                }
            }
        }
        public Client ActiveClient
        {
            get => activeClient;
            set
            {
                if (activeClient != value)
                {
                    activeClient = value;
                    OnPropertyChanged("id");
                    OnPropertyChanged("nom");
                    OnPropertyChanged("prenom");
                    OnPropertyChanged("email");
                    OnPropertyChanged("date_naissance");
                    OnPropertyChanged("telephone");
                    OnPropertyChanged("credit");
                    OnPropertyChanged("adresse");
                }
            }
        }
        public Facture SelectedFacture
        {
            get => selectedFacture;
            set
            {
                if (selectedFacture != value)
                {
                    selectedFacture = value;
                    OnPropertyChanged("SelectedFacture");
                    if (selectedFacture != null)
                    {
                        activeFacture = selectedFacture;
                    }
                }
            }
        }
        public Facture ActiveFacture
        {
            get => activeFacture;
            set
            {
                if (activeFacture != value)
                {
                    activeFacture = value;
                    OnPropertyChanged("id");
                    OnPropertyChanged("id_client");
                    OnPropertyChanged("date_heure");
                    OnPropertyChanged("montant");
                }
            }
        }
        public string nom_client
        {
            get => activeClient.Nom;
            set
            {
                if (activeClient.Nom != value)
                {
                    activeClient.Nom = value;
                    OnPropertyChanged("nom");
                }
            }
        }
        public string prenom_client
        {
            get => activeClient.Prenom;
            set
            {
                if (activeClient.Prenom != value)
                {
                    activeClient.Prenom = value;
                    OnPropertyChanged("prenom");
                }
            }
        }
        public string email_client
        {
            get => activeClient.Email;
            set
            {
                if (activeClient.Email != value)
                {
                    activeClient.Email = value;
                    OnPropertyChanged("email");
                }
            }
        }
        public DateTime date_naissance_client
        {
            get => activeClient.Naissance;
            set
            {
                if (activeClient.Naissance != value)
                {
                    activeClient.Naissance = value;
                    OnPropertyChanged("nom");
                }
            }
        }
        public string telephone_client
        {
            get => activeClient.Tel;
            set
            {
                if (activeClient.Tel != value)
                {
                    activeClient.Tel = value;
                    OnPropertyChanged("telephone");
                }
            }
        }
        public int crédit_client
        {
            get => activeClient.Credit;
            set
            {
                if (activeClient.Credit != value)
                {
                    activeClient.Credit = value;
                    OnPropertyChanged("credit");
                }
            }
        }
        public string adresse_client
        {
            get => activeClient.Adresse;
            set
            {
                if (activeClient.Adresse != value)
                {
                    activeClient.Adresse = value;
                    OnPropertyChanged("adresse");
                }
            }
        }
        public int id_facturation
        {
            get => activeFacture.Id;
            set
            {
                if (activeFacture.Id != value)
                {
                    activeFacture.Id = value;
                    OnPropertyChanged("id");
                }
            }
        }
        public Client id_client_facturation
        {
            get => activeFacture.Client;
            set
            {
                if (activeFacture.Client != value)
                {
                    activeFacture.Client = value;
                    OnPropertyChanged("id_client");
                }
            }
        }
        public DateTime date_heure_facturation
        {
            get => activeFacture.Date;
            set
            {
                if (activeFacture.Date != value)
                {
                    activeFacture.Date = value;
                    OnPropertyChanged("date_heure");
                }
            }
        }
        public double montant_facturation
        {
            get => activeFacture.Montant;
            set
            {
                if (activeFacture.Montant != value)
                {
                    activeFacture.Montant = value;
                    OnPropertyChanged("montant");
                }
            }
        }
        #endregion

        #region Commande (boutons)
        public ICommand UpdateCommandClient
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateClient(), () => true);
                }
                return this.updateCommand;
            }
        }

        public ICommand CreateCommandClient
        {
            get
            {
                if (this.createCommand == null)
                {
                    this.createCommand = new RelayCommand(() => CreateClient(), () => true);
                }
                return this.createCommand;
            }
        }
        #endregion
        private void CreateClient()
        {
            Client newc = new Client();
            newc.Nom = "Nouveau Client";
        }
        #region Action
        private void UpdateClient()
        {
            this.vmDaoClient.EditClient(this.activeClient);
            MessageBox.Show("Le fromage à bien été mis à jour");
        }
    }
}
#endregion