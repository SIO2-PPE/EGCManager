﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoJoueur
    {
        private Dbal dbal;

        public DaoJoueur(Dbal dbal)
        {
            this.dbal = dbal;
        }
        public void AddJoueurToPartie(Joueur j, Partie p)
        {
            Dictionary<string, string> val = new Dictionary<string, string>();
            val.Add("joueur", j.Id.ToString());
            val.Add("partie", p.Id.ToString());
            this.dbal.Insert("joueur_partie", val);
        }
        public List<Joueur> GetJoueurToPartie(Partie p)
        {
            List<Joueur> lst = new List<Joueur>();
            DataTable tab = this.dbal.SelectByField("joueur_partie", "partie = " + p.Id);
            foreach (DataRow rowJP in tab.Rows)
            {
                DataRow row = this.dbal.SelectById("joueur", (int)rowJP["joueur"]);
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
            DataTable tab = this.dbal.SelectAll("joueur");
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
    }
}
