using System;
using System.Collections.Generic;
using System.Data;

namespace Model.Business
{
    public class Horaire : IHydrate
    {
        private int _id;
        private DateTime _heure;

        public Horaire(DataRow row)
        {
            Hydrate(row);
        }

        #region Getter and Setter

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime Heure
        {
            get => _heure;
            set => _heure = value;
        }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _heure = (DateTime)row["heure"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> tab = new Dictionary<string, dynamic>();
            tab.Add("id", _id);
            tab.Add("heure", _heure);
            return tab;
        }
    }
}