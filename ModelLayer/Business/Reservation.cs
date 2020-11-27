using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Reservation
    {
        private int montant;
        private DateTime date;
        private Client client;
        private Partie partie;

        public Reservation(int montant, DateTime date, Client client, Partie partie)
        {
            this.montant = montant;
            this.date = date;
            this.client = client;
            this.partie = partie;
        }
        public Reservation()
        {
            this.montant = 0;
            this.date = new DateTime();
            this.client = new Client();
            this.partie = new Partie();
        }
        public Reservation(Client client, int montant)
        {
            this.montant = montant;
            this.date = DateTime.Now;
            this.client = client;
            this.partie = new Partie();
        }

        public int Montant { get => montant; set => montant = value; }
        public DateTime Date { get => date; set => date = value; }
        public Client Client { get => client; set => client = value; }
        public Partie Partie { get => partie; set => partie = value; }
    }
}
