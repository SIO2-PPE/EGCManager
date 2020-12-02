using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Reservation : IHydrate
    {
        private int _id;
        private int _montant;
        private DateTime _date;
        private Client _client;
        private Partie _partie;

        public Reservation(int id,int montant, DateTime date, Client client, Partie partie)
        {
            _id = id;
            _montant = montant;
            _date = date;
            _client = client;
            _partie = partie;
        }
        public Reservation()
        {
            _id = 0;
            _montant = 0;
            _date = new DateTime();
            _client = new Client();
            _partie = new Partie();
        }
        public Reservation(Client client, int montant)
        {
            _id = 0;
            _montant = montant;
            _date = DateTime.Now;
            _client = client;
            _partie = new Partie();
        }

        public int Montant { get => _montant; set => _montant = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public Client Client { get => _client; set => _client = value; }
        public Partie Partie { get => _partie; set => _partie = value; }
        public int Id { get => _id; set => _id = value; }
        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _montant = val["montant"];
            _date = val["date"];
            _client = val["client"];
            _partie = val["partie"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("montant", _montant);
            val.Add("date", _date);
            val.Add("client", _client);
            val.Add("partie", _partie);
            return val;
        }
    }
}
