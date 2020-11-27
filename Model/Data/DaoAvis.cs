﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoAvis
    {
        private Dbal _dbal;
        private DaoJoueur _daoJoueur;
        public DaoAvis(Dbal dbal)
        {
            this._dbal = dbal;
            this._daoJoueur = new DaoJoueur(dbal);
        }
        public void Insert(Avis avis)
        {
            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
            values.Add("commentaire", avis.Commentaire);
            values.Add("creation", avis.Creation);
            this._dbal.Insert("avis", values);
        }
        public void Update(Avis avis)
        {
            Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();
            values.Add("commentaire", avis.Commentaire);
            values.Add("creation", avis.Creation);
            this._dbal.Update("avis", values, "id = " + avis.Id);
        }
        public void Delete(Avis avis)
        {
            this._dbal.Delete("Avis", "id = " + avis.Id);
        }
        public List<Avis> SelectAll()
        {
            DataTable tab = this._dbal.SelectAll("avis");
            List<Avis> lst = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Avis(
                    this._daoJoueur.GetJoueurById((int)row[""])
                    ));
            }
            return lst;
        }
        public Avis SelectById(int id)
        {
            DataRow row = this._dbal.SelectById("avis", id);
            return new Avis();
        }
        public Avis SelectByName(string nom)
        {
            DataRow row = this._dbal.SelectByField("Avis", "nom = '" + nom + "'").Rows[0];
            return new Avis();
        }
    }
}