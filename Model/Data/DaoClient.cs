using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoClient
    {
        private Dbal _dbal;
        private DaoFacture _daoFacture;
        public DaoClient(Dbal dbal)
        {
            _dbal = dbal;
            _daoFacture = new DaoFacture(dbal);
        }

        public void NouveauClient(Client c)
        {
            _dbal.Insert("client", c.ToArray());
        }
        public Client SearchClient(string prenom, string nom, string email)
        {
            return new Client(_dbal.Select("client",
                "prenom = '" + prenom + "' AND " +
                "nom = '" + nom + "' AND " +
                "email = '" + email + "'"
                ).Rows[0]);
        }
        public void EditClient(Client c)
        {
            _dbal.Update("client", c.ToArray(), "id = " + c.Id);
        }
    }
}
