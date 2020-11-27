using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Site : IHydrate
    {
        private int _id;
        private string _ville;
        private string _adresse;
        private List<Salle> _lstSalle;

        public Site(string ville, string adresse, int id = 0)
        {
            _id = id;
            _ville = ville;
            _adresse = adresse;
            _lstSalle = new List<Salle>();

        }
        public Site()
        {
            _id = 0;
            _ville = "";
            _adresse = "";
            _lstSalle = new List<Salle>();
        }

        public int Id { get => _id; set => _id = value; }
        public string Ville { get => _ville; set => _ville = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public List<Salle> LstSalle { get => _lstSalle; set => _lstSalle = value; }

        public Salle NouvelleSalle(Theme th)
        {
            Salle s = new Salle(0, this, th);
            _lstSalle.Add(s);
            return s; 
        }

        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _ville = val["ville"];
            _adresse = val["adresse"];
            _lstSalle = val["lstSalle"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("ville", _ville);
            val.Add("adresse", _adresse);
            val.Add("lstSalle", _lstSalle);
            return val;
        }
    }
}
