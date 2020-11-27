using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Partie
    {
        private int id;
        private DateTime date;
        private DateTime temps;
        private bool win;
        private Salle salle;
        private List<Joueur> lstJoueur;
        private List<Obstacle> lstObstacle; // L'indice correspond à la position (0 à 11)

        public Partie(DateTime debut, DateTime fin, bool win, Salle salle, List<Joueur> lstJoueur, List<Obstacle> lstObstacle, int id = 0)
        {
            this.id = id;
            this.date = debut;
            this.temps = fin;
            this.win = win;
            this.salle = salle;
            this.lstJoueur = lstJoueur;
            this.lstObstacle = lstObstacle;
        }
        public Partie(int id = 0, DateTime date = new DateTime())
        {
            this.id = id;
            this.date = date;
            this.temps = new DateTime();
            this.win = false;
            this.salle = new Salle();
            this.lstJoueur = new List<Joueur>();
            this.lstObstacle = new List<Obstacle>();
        }
        public Partie(DateTime debut, Salle salle, List<Obstacle> obstacles)
        {
            this.id = 0;
            this.date = debut;
            this.temps = new DateTime();
            this.win = false;
            this.salle = salle;
            this.lstJoueur = new List<Joueur>();
            this.lstObstacle = obstacles;
        }
        public Partie(int id, DateTime date, DateTime temps, bool win)
        {
            this.id = id;
            this.date = date;
            this.temps = temps;
            this.win = win;
            this.salle = new Salle();
            this.lstJoueur = new List<Joueur>();
            this.lstObstacle = new List<Obstacle>();
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Temps { get => temps; set => temps = value; }
        public bool Win { get => win; set => win = value; }
        public Salle Salle { get => salle; set => salle = value; }
        public List<Joueur> LstJoueur { get => lstJoueur; set => lstJoueur = value; }
        public List<Obstacle> LstObstacle { get => lstObstacle; set => lstObstacle = value; }
    }
}
