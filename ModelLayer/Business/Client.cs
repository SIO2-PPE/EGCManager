using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string photo;
        private string email;
        private DateTime naissance;
        private int credit;
        private string adresse;
        private List<Facture> lstFacture;
        private List<Reservation> lstReservation;

        public Client(string nom, string prenom, string photo, string email, DateTime naissance, int credit, string adresse, int id = 0)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.photo = photo;
            this.email = email;
            this.naissance = naissance;
            this.credit = credit;
            this.adresse = adresse;
            this.lstFacture = new List<Facture>();
            this.lstReservation = new List<Reservation>();
        }
        public Client()
        {
            this.id = 0;
            this.nom = "";
            this.prenom = "";
            this.photo = "";
            this.email = "";
            this.naissance = new DateTime();
            this.credit = 0;
            this.adresse = "";
            this.lstFacture = new List<Facture>();
            this.lstReservation = new List<Reservation>();
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Naissance { get => naissance; set => naissance = value; }
        public int Credit { get => credit; set => credit = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public List<Facture> LstFacture { get => lstFacture; set => lstFacture = value; }
        public List<Reservation> LstReservation { get => lstReservation; set => lstReservation = value; }

        public Facture NouvelleFacture(double montant, int nbCredit, DateTime date)
        {
            Facture f = new Facture(montant, nbCredit, this, date);
            this.credit += f.NbCredit;
            this.LstFacture.Add(f);
            return f;

        }
        public Reservation NouvelleReservation(int montant, DateTime dateReservation, DateTime datePartie, Salle salle, int nbJoueur, List<Obstacle> lstObstacle)
        {
            Reservation r = new Reservation();
            if (montant <= this.credit)
            {
                r.Client = this;
                r.Date = dateReservation;
                r.Montant = montant;
                r.Partie = new Partie(datePartie, salle, lstObstacle);
                this.lstReservation.Add(r);
            }
            return r;
        }
    }
}
