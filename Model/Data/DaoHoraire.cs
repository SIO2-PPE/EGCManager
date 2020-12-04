using System;
using System.Collections.Generic;
using System.Data;
using Model.Business;

namespace Model.Data
{
    public class DaoHoraire
    {
        private Dbal _dbal;
        private DaoPartie _daoPartie;

        public DaoHoraire(Dbal dbal)
        {
            _dbal = dbal;
            _daoPartie = new DaoPartie(dbal);
        }
        
        /// <returns>
        /// Retourne un dictionnaire avec comme clé un horraire et comme valeur
        /// sois une Partie (qui correspond à l'horraire)
        /// sois null si l'horraire n'est pas réserver
        /// </returns>
        public Dictionary<Horaire, Partie> GetPlanning(DateTime jour, Salle salle)
        {
            Dictionary<Horaire, Partie> dic = new Dictionary<Horaire, Partie>();
            DataTable tab = _dbal.SelectOrderBy("horaire", "heure");
            foreach (DataRow row in tab.Rows)
            {
                dic.Add(new Horaire(row), _daoPartie.GetPartieForHoraire((int)row["id"],jour,salle));
            }
            return dic;
        }
    }
}