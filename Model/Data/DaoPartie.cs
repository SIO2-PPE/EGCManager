using Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Data
{
    class DaoPartie
    {
        private Dbal _dbal;
        private DaoSalle _daoSalle;
        private DaoObstacle _daoObstacle;
        private DaoJoueur _daoJoueur;

        public DaoPartie(Dbal dbal)
        {
            this._dbal = dbal;
            this._daoSalle = new DaoSalle(dbal);
            this._daoObstacle = new DaoObstacle(dbal);
            this._daoJoueur = new DaoJoueur(dbal);
        }
        public List<Partie> ListReserv(Salle salle, DateTime date)
        {
            DataTable tab = this._dbal.SelectByField("Partie",
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
            this._dbal.Insert("partie", val);
            DataRow dbP = this._dbal.SelectByField("partie","date = " + p.Date.ToString("'yyyy-MM-dd'")).Rows[0];
            p.Id = (int)dbP["id"];
            foreach (Joueur j in p.LstJoueur)
            {
                this._daoJoueur.AddJoueurToPartie(j, p);
            }
            for (int i = 0; i < p.LstObstacle.Count; i++)
            {
                this._daoObstacle.AddObstacleToPartie(p.LstObstacle[i], p, i);
            }
        }
        public void Edit(Partie p)
        {

        }
        public Partie GetPartie(int id)
        {
            DataRow rowP = this._dbal.SelectById("partie", id);
            Partie partie = new Partie(
                (int)rowP["id"],
                (DateTime)rowP["date"],
                (DateTime)rowP["temps"],
                (bool)rowP["win"]
            );
            partie.Salle = this._daoSalle.GetSalle((int)rowP["salle"]);
            partie.LstJoueur = this._daoJoueur.GetJoueurToPartie(partie);
            return partie;
        }
    }
}
