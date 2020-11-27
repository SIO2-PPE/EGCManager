using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Partie : IHydrate
    {
        private int _id;
        private DateTime _date;
        private DateTime _temps;
        private bool _win;
        private Salle _salle;
        private List<Joueur> _lstJoueur;
        private List<Obstacle> _lstObstacle; // L'indice correspond à la position (0 à 11)

        public Partie(DateTime debut, DateTime fin, bool win, Salle salle, List<Joueur> lstJoueur, List<Obstacle> lstObstacle, int id = 0)
        {
            _id = id;
            _date = debut;
            _temps = fin;
            _win = win;
            _salle = salle;
            _lstJoueur = lstJoueur;
            _lstObstacle = lstObstacle;
        }
        public Partie(int id = 0, DateTime date = new DateTime())
        {
            _id = id;
            _date = date;
            _temps = new DateTime();
            _win = false;
            _salle = new Salle();
            _lstJoueur = new List<Joueur>();
            _lstObstacle = new List<Obstacle>();
        }
        public Partie(DateTime debut, Salle salle, List<Obstacle> obstacles)
        {
            _id = 0;
            _date = debut;
            _temps = new DateTime();
            _win = false;
            _salle = salle;
            _lstJoueur = new List<Joueur>();
            _lstObstacle = obstacles;
        }
        public Partie(int id, DateTime date, DateTime temps, bool win)
        {
            _id = id;
            _date = date;
            _temps = temps;
            _win = win;
            _salle = new Salle();
            _lstJoueur = new List<Joueur>();
            _lstObstacle = new List<Obstacle>();
        }

        public int Id { get => _id; set => _id = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public DateTime Temps { get => _temps; set => _temps = value; }
        public bool Win { get => _win; set => _win = value; }
        public Salle Salle { get => _salle; set => _salle = value; }
        public List<Joueur> LstJoueur { get => _lstJoueur; set => _lstJoueur = value; }
        public List<Obstacle> LstObstacle { get => _lstObstacle; set => _lstObstacle = value; }
        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _date = val["date"];
            _temps = val["temps"];
            _win = val["win"];
            _salle = val["salle"];
            _lstJoueur = val["lstJoueur"];
            _lstObstacle = val["lstObstacle"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("date", _date);
            val.Add("temps", _temps);
            val.Add("win", _win);
            val.Add("salle", _salle);
            val.Add("lstJoueur", _lstJoueur);
            val.Add("lstObstacle", _lstObstacle);
            return val;
        }
    }
}
