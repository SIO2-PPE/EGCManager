using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Facture : IHydrate
    {
        private int _id;
        private DateTime _date;
        private double _montant;
        private int _nbCredit;
        private Client _client;

        public Facture(double montant, int nbCredit, Client client, DateTime date, int id = 0)
        {
            _id = id;
            _date = date;
            _montant = montant;
            _client = client;
        }
        public Facture()
        {
            _id = 0;
            _date = new DateTime();
            _montant = 0;
            _nbCredit = 0;
            _client = new Client();
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public double Montant
        {
            get => _montant;
            set => _montant = value;
        }

        public int NbCredit
        {
            get => _nbCredit;
            set => _nbCredit = value;
        }

        public Client Client
        {
            get => _client;
            set => _client = value;
        }

        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _date = val["date"];
            _montant = val["montant"];
            _nbCredit = val["nbCredit"];
            _client = val["client"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("date", _date);
            val.Add("montant", _montant);
            val.Add("nbCredit", _nbCredit);
            val.Add("client", _client);
            return val;
        }
    }
}