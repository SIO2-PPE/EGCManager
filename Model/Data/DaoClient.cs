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

        public List<Client> GetAllClient()
        {
            DataTable tab = _dbal.Select("client");
            List<Client> lst = new List<Client>();
            foreach (DataRow row in tab.Rows)
            {
                Client client = new Client(row);
                client.LstFacture = _daoFacture.GetForClient(client);
                lst.Add(client);
            }
            return lst;
        }
    }
}
