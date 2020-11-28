using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoJoueur
    {
        private Dbal _dbal;

        public DaoJoueur(Dbal dbal)
        {
            _dbal = dbal;
        }
        public void AddJoueurToPartie(Joueur j, Partie p)
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("joueur", j.Id);
            val.Add("partie", p.Id);
            _dbal.Insert("joueur_partie", val);
        }
        public List<Joueur> GetJoueurToPartie(Partie p)
        {
            List<Joueur> lst = new List<Joueur>();
            DataTable tab = _dbal.SelectByField("joueur_partie", "partie = " + p.Id);
            foreach (DataRow rowJp in tab.Rows)
            {
                DataRow row = _dbal.SelectById("joueur", (int)rowJp["joueur"]);
                lst.Add(new Joueur(
                    (string)row["pseudo"],
                    (string)row["email"],
                    (int)row["id"]
                ));
            }
            return lst;
        }
        public List<Joueur> GetAllJoueur()
        {
            List<Joueur> lst = new List<Joueur>();
            DataTable tab = _dbal.SelectAll("joueur");
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Joueur(
                    (string)row["pseudo"],
                    (string)row["email"],
                    (int)row["id"]
                ));
            }
            return lst;
        }

        public Joueur GetJoueurById(int id)
        {
            DataRow row = _dbal.SelectById("joueur", id);
            return new Joueur();
        }
    }
}
