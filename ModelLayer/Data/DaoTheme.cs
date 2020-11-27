using Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Data
{
    class DaoTheme
    {
        private Dbal dbal;

        public DaoTheme(Dbal dbal)
        {
            this.dbal = dbal;
        }
        public Theme GetThemeActuel(Salle s)
        {
            DataRow rowTS = this.dbal.SelectByField("theme_salle",
                "salle = " + s.Id + " AND " +
                "dateDebut < " + DateTime.Now.ToString("'yyyy-MM-dd'") + " AND " +
                "dateFin > " + DateTime.Now.ToString("'yyyy-MM-dd'")
            ).Rows[0];
            DataRow row = this.dbal.SelectById("theme", (int)rowTS["theme"]);
            return new Theme(
                (int)row["id"],
                (string)row["nom"]
            );
        }
    }
}
