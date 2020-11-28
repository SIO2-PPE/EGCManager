using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Site : IHydrate
    {
        private int _id;
        private string _ville;
        private string _adresse;
        private List<Salle> _lstSalle;

        public Site(DataRow row, List<Salle> lstSalle)
        {
            Hydrate(row);
            _lstSalle = lstSalle;
        }

        #region Getter and Setter

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Ville
        {
            get => _ville;
            set => _ville = value;
        }

        public string Adresse
        {
            get => _adresse;
            set => _adresse = value;
        }

        public List<Salle> LstSalle
        {
            get => _lstSalle;
            set => _lstSalle = value;
        }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _ville = (string)row["ville"];
            _adresse = (string)row["adresse"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("ville", _ville);
            val.Add("adresse", _adresse);
            return val;
        }
    }
}
