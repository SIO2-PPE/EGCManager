using Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Data
{
    class DaoPartie
    {
        private Dbal dbal;
        private DaoSalle daoSalle;
        private DaoObstacle daoObstacle;
        private DaoJoueur daoJoueur;

        public DaoPartie(Dbal dbal)
        {
            this.dbal = dbal;
            this.daoSalle = new DaoSalle(dbal);
            this.daoObstacle = new DaoObstacle(dbal);
            this.daoJoueur = new DaoJoueur(dbal);
        }
        public List<Partie> ListReserv(Salle salle, DateTime date)
        {
            DataTable tab = this.dbal.SelectByField("Partie",
                "date > " + date.ToString("'yyyy-MM-dd H:m:s'") + " AND " +
                "date < " + date.AddDays(1).ToString("'yyyy-MM-dd'") + " AND " +
                "salle = " + salle.Id
            );
            List<Partie> lstP = new List<Partie>();
            foreach (DataRow row in tab.Rows)
            {
                lstP.Add(new Partie(
                    (int)row["id"],
                    (DateTime)row["date"]
                ));
            }
            return lstP;
        }
        /// <summary>
        /// Attention, la date doit déja être attribué
        /// </summary>
        public void Create(Partie p)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("date", p.Date.ToString("'yyyy-MM-dd'"));
            val.Add("salle", p.Salle.Id.ToString());
            this.dbal.Insert("partie", val);
            DataRow dbP = this.dbal.SelectByField("partie","date = " + p.Date.ToString("'yyyy-MM-dd'")).Rows[0];
            p.Id = (int)dbP["id"];
            foreach (Joueur j in p.LstJoueur)
            {
                this.daoJoueur.AddJoueurToPartie(j, p);
            }
            for (int i = 0; i < p.LstObstacle.Count; i++)
            {
                this.daoObstacle.AddObstacleToPartie(p.LstObstacle[i], p, i);
            }
        }
        public void Edit(Partie p)
        {

        }
        public Partie GetPartie(int id)
        {
            DataRow rowP = this.dbal.SelectById("partie", id);
            Partie partie = new Partie(
                (int)rowP["id"],
                (DateTime)rowP["date"],
                (DateTime)rowP["temps"],
                (bool)rowP["win"]
            );
            partie.Salle = this.daoSalle.GetSalle((int)rowP["salle"]);
            partie.LstJoueur = this.daoJoueur.GetJoueurToPartie(partie);
            return partie;
        }
    }
}
