using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Client : IHydrate
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _photo;
        private string _email;
        private DateTime _naissance;
        private int _credit;
        private string _adresse;
        private List<Facture> _lstFacture;
        private List<Reservation> _lstReservation;

        public Client(string nom, string prenom, string photo, string email, DateTime naissance, int credit, string adresse, int id = 0)
        {
            _id = id;
            _nom = nom;
            _prenom = prenom;
            _photo = photo;
            _email = email;
            _naissance = naissance;
            _credit = credit;
            _adresse = adresse;
            _lstFacture = new List<Facture>();
            _lstReservation = new List<Reservation>();
        }
        public Client()
        {
            _id = 0;
            _nom = "";
            _prenom = "";
            _photo = "";
            _email = "";
            _naissance = new DateTime();
            _credit = 0;
            _adresse = "";
            _lstFacture = new List<Facture>();
            _lstReservation = new List<Reservation>();
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime Naissance { get => _naissance; set => _naissance = value; }
        public int Credit { get => _credit; set => _credit = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public List<Facture> LstFacture { get => _lstFacture; set => _lstFacture = value; }
        public List<Reservation> LstReservation { get => _lstReservation; set => _lstReservation = value; }

        public Facture NouvelleFacture(double montant, int nbCredit, DateTime date)
        {
            Facture f = new Facture(montant, nbCredit, this, date);
            _credit += f.NbCredit;
            _lstFacture.Add(f);
            return f;

        }
        public Reservation NouvelleReservation(int montant, DateTime dateReservation, DateTime datePartie, Salle salle, int nbJoueur, List<Obstacle> lstObstacle)
        {
            Reservation r = new Reservation();
            if (montant <= _credit)
            {
                r.Client = this;
                r.Date = dateReservation;
                r.Montant = montant;
                r.Partie = new Partie(datePartie, salle, lstObstacle);
                _lstReservation.Add(r);
            }
            return r;
        }

        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _nom = val["nom"];
            _prenom = val["prenom"];
            _photo = val["photo"];
            _email = val["email"];
            _naissance = val["naissance"];
            _credit = val["credit"];
            _adresse = val["adresse"];
            _lstFacture = val["lstFacture"];
            _lstReservation = val["lstReservation"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("nom", _nom);
            val.Add("prenom", _prenom);
            val.Add("photo", _photo);
            val.Add("email", _email);
            val.Add("naissance", _naissance);
            val.Add("credit", _credit);
            val.Add("adresse", _adresse);
            val.Add("lstFacture", _lstFacture);
            val.Add("lstReservation", _lstReservation);
            return val;
        }
    }
}
