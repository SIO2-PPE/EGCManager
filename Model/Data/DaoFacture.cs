using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoFacture
    {
        private Dbal _dbal;

        public DaoFacture(Dbal dbal)
        {
            _dbal = dbal;
        }
        
        /*public List<Facture> GetForClient(Client client)
        {
            DataTable tab = _dbal.Select("facture", "client = " + client.Id);
            List<Facture> lst = new List<Facture>();
            foreach (DataRow row in tab.Rows)
            {
                lst.Add(new Facture(row, client));
            }
            return lst;
        }*/
    }
}
