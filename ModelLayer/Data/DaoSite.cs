using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoSite
    {
        private Dbal dbal;

        public DaoSite(Dbal dbal)
        {
            this.dbal = dbal;
        }
        public Site GetSite(int id)
        {
            DataRow row = this.dbal.SelectById("site", id);
            return new Site(
                (string)row["ville"],
                (string)row["adresse"],
                (int)row["id"]
            );
        }
    }
}
