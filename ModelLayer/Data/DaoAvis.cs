using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoAvis
    {
        private Dbal dbal;

        public DaoAvis(Dbal dbal)
        {
            this.dbal = dbal;
        }
        public void Insert(Avis avis)
        {
            this.dbal.Insert("Avis (commentaire, creation) VALUES ("
                + "'" + avis.Commentaire + "',"
                + avis.Creation.ToString("'yyyy-MM-dd'")
            + ")");
        }
        public void Update(Avis avis)
        {
            this.dbal.Update("Avis SET "
                + "commentaire = '" + avis.Commentaire + "'"
                + "creation = " + avis.Creation.ToString("'yyyy-MM-dd'")
                + " WHERE id = " + avis.Id
            );
        }
        public void Delete(Avis avis)
        {
            this.dbal.Delete("Avis WHERE id = " + avis.Id);
        }
        public List<Avis> SelectAll()
        {
            List<Avis> lst = new List<Avis>();
            DataTable tab = this.dbal.SelectAll("Avis");
            return lst;
        }
        public Avis SelectById(int id)
        {
            DataRow row = this.dbal.SelectById("Avis", id);
            return new Avis();
        }
        public Avis SelectByName(string nom)
        {
            DataRow row = this.dbal.SelectByField("Avis", "nom = '" + nom + "'").Rows[0];
            return new Avis();
        }
    }
}
