using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoAvis
    {
        private Dbal _dbal;
        private DaoJoueur _daoJoueur;
        public DaoAvis(Dbal dbal)
        {
            _dbal = dbal;
            _daoJoueur = new DaoJoueur(dbal);
        }
        public DaoAvis(Dbal dbal, DaoJoueur daoJoueur)
        {
            _dbal = dbal;
            _daoJoueur = daoJoueur;
        }
        /*public void Insert(Avis avis)
        {
            _dbal.Insert("avis", avis.ToArray());
        }
        public void Update(Avis avis)
        {
            _dbal.Update("avis", avis.ToArray(), "id = " + avis.Id);
        }
        public void Delete(Avis avis)
        {
            _dbal.Delete("Avis", "id = " + avis.Id);
        }
        public List<Avis> GetAll()
        {
            DataTable tab = _dbal.Select("avis");
            List<Avis> lst = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Avis(row, _daoJoueur.GetJoueurById((int)row["joueur"])));
            }
            return lst;
        }
        public List<Avis> GetForJoueur(Joueur joueur)
        {
            DataTable tab = _dbal.Select("avis","joueur = " + joueur.Id);
            List<Avis> lst = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Avis(row, joueur));
            }
            return lst;
        }*/
        public List<Avis> GetByJoueurId(int id)
        {
            DataTable tab = _dbal.Select("avis","joueur = " + id);
            List<Avis> lst = new List<Avis>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Avis(row));
            }
            return lst;
        }
    }
}
