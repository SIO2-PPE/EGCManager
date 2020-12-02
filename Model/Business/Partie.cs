using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Business
{
    public class Partie : IHydrate
    {
        private int _id;
        private DateTime _date;
        private DateTime _temps;
        private bool _win;

        private Horaire _horaire;
        private Salle _salle;
        private List<Joueur> _lstJoueur;
        private List<Obstacle> _lstObstacle; // L'indice correspond à la position (0 à 11)

        public Partie(DataRow row, Horaire horaire, Salle salle)
        {
            Hydrate(row);
            _salle = salle;
            _horaire = horaire;
        }
        public Partie(DataRow row)
        {
            Hydrate(row);
        }
        
        #region Getter and Setter

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

        public DateTime Temps
        {
            get => _temps;
            set => _temps = value;
        }

        public bool Win
        {
            get => _win;
            set => _win = value;
        }

        public Salle Salle
        {
            get => _salle;
            set => _salle = value;
        }

        public List<Joueur> LstJoueur
        {
            get => _lstJoueur;
            set => _lstJoueur = value;
        }

        public List<Obstacle> LstObstacle
        {
            get => _lstObstacle;
            set => _lstObstacle = value;
        }

        #endregion
        
        public void Hydrate(DataRow row)
        {
            _id = (int)row["id"];
            _date = (DateTime)row["date"];
            _temps = (DateTime)row["temps"];
            _win = (bool)row["win"];
        }
        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("date", _date);
            val.Add("temps", _temps);
            val.Add("win", _win);
            val.Add("salle", _salle.Id);
            return val;
        }
    }
}
