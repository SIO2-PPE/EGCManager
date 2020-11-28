using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    public class DaoSalle
    {
        private Dbal _dbal;
        private DaoSite _daoSite;
        private DaoTheme _daoTheme;

        public DaoSalle(Dbal dbal)
        {
            this._dbal = dbal;
            this._daoSite = new DaoSite(dbal);
            this._daoTheme = new DaoTheme(dbal);
        }
        public Salle GetSalle(int id)
        {
            DataRow row = this._dbal.SelectById("salle", id);
            Salle s = new Salle((int)row["id"]);
            s.Site = this._daoSite.GetSite((int)row["site"]);
            s.Theme = this._daoTheme.GetThemeActuel(s);
            return s;
        }
    }
}
