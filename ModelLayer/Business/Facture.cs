using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Facture
    {
        private int id;
        private DateTime date;
        private double montant;
        private int nbCredit;
        private Client client;

        public Facture(double montant, int nbCredit, Client client, DateTime date, int id = 0)
        {
            this.id = id;
            this.date = date;
            this.montant = montant;
            this.client = client;
        }
        public Facture()
        {
            this.id = 0;
            this.date = new DateTime();
            this.montant = 0;
            this.nbCredit = 0;
            this.client = new Client();
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Montant { get => montant; set => montant = value; }
        public int NbCredit { get => nbCredit; set => nbCredit = value; }
        internal Client Client { get => client; set => client = value; }
    }
}