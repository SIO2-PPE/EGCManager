using Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Data
{
    public class DaoPartie
    {
        private Dbal _dbal;
        private DaoSalle _daoSalle;
        private DaoObstacle _daoObstacle;
        private DaoJoueur _daoJoueur;

        public DaoPartie(Dbal dbal)
        {
            _dbal = dbal;
            _daoSalle = new DaoSalle(dbal);
            _daoObstacle = new DaoObstacle(dbal);
            _daoJoueur = new DaoJoueur(dbal);
        }
        
        /*public List<Partie> GetPartiesDuJour(Salle salle, DateTime date)
        {
            DataTable tab = _dbal.Select("Partie",
                "date > '" + date.ToString("yyyy-MM-dd H:m:s") + "' AND " +
                "date < '" + date.AddDays(1).ToString("yyyy-MM-dd") + "' AND " +
                "salle = " + salle.Id
            );
            List<Partie> lstP = new List<Partie>();
            foreach (DataRow row in tab.Rows)
            {
                lstP.Add(new Partie(row, _daoSalle.GetSalle((int)row["salle"])));
            }
            return lstP;
        }*/
        /// <summary>
        /// Attention, la date doit déja être attribué
        /// </summary>
        /*public void Create(Partie p)
        {
            _dbal.Insert("partie", p.ToArray());
            DataRow dbP = _dbal.Select("partie","date = '" + p.Date.ToString("yyyy-MM-dd") + "'").Rows[0];
            p.Id = (int)dbP["id"];
            foreach (Joueur j in p.LstJoueur)
            {
                _daoJoueur.AddJoueurToPartie(j, p);
            }
            for (int i = 0; i < p.LstObstacle.Count; i++)
            {
                _daoObstacle.AddObstacleToPartie(p.LstObstacle[i], p, i);
            }
        }
        public void Edit(Partie p)
        {

        }*/
        // public Partie GetPartie(int id)
        // {
        //     DataRow rowP = _dbal.SelectById("partie", id);
        //     Partie partie = new Partie(rowP, _daoSalle.GetSalle((int)rowP["salle"]));
        //     partie.LstJoueur = _daoJoueur.GetJoueurToPartie(partie);
        //     return partie;
        // }

        public Partie GetPartieForHoraire(int horaireId,DateTime jour, Salle salle)
        {
            return new Partie(_dbal.Select("partie",
                "salle = " + salle.Id +
                "date = '" + jour.ToString("yyyy-M-d") + "' and " +
                "horaire = " + horaireId
                ).Rows[0]);
        }
    }
}
