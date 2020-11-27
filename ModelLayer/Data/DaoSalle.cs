using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model.Business;

namespace Model.Data
{
    class DaoSalle
    {
        private Dbal dbal;
        private DaoSite daoSite;
        private DaoTheme daoTheme;

        public DaoSalle(Dbal dbal)
        {
            this.dbal = dbal;
            this.daoSite = new DaoSite(dbal);
            this.daoTheme = new DaoTheme(dbal);
        }
        public Salle GetSalle(int id)
        {
            DataRow row = this.dbal.SelectById("salle", id);
            Salle s = new Salle((int)row["id"]);
            s.Site = this.daoSite.GetSite((int)row["site"]);
            s.Theme = this.daoTheme.GetThemeActuel(s);
            return s;
        }
    }
}
