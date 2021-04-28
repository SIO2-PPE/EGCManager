using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Avis : IHydrate
    {
        private int _id;
        private string _commentaire;
        private int _note;
        private DateTime _date;
        private Joueur _joueur;

        public Avis(DataRow row)
        {
            Hydrate(row);
        }

        #region Getter and Setter

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Commentaire
        {
            get => _commentaire;
            set => _commentaire = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public Joueur Joueur
        {
            get => _joueur;
            set => _joueur = value;
        }
        public int Note { get => _note; set => _note = value; }

        #endregion

        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _commentaire = (string)row["commentaire"];
            _note = (int)row["note"];
            _date = (DateTime)row["date"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("commentaire", _commentaire);
            val.Add("note", _note);
            val.Add("date", _date);
            val.Add("joueur", _joueur.Id);
            return val;
        }

        public override string ToString()
        {
            return _joueur.Pseudo + " : " + _note;
        }
    }
}
