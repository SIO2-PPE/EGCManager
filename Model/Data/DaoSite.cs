using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoSite
    {
        private Dbal _dbal;

        public DaoSite(Dbal dbal)
        {
            this._dbal = dbal;
        }
        public Site GetSite(int id)
        {
            DataRow row = this._dbal.SelectById("site", id);
            return new Site(
                (string)row["ville"],
                (string)row["adresse"],
                (int)row["id"]
            );
        }
    }
}
