using Model.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Model.Data
{
    public class DaoTheme
    {
        private Dbal _dbal;

        public DaoTheme(Dbal dbal)
        {
            this._dbal = dbal;
        }
        public Theme GetThemeActuel(Salle s)
        {
            DataRow rowTs = this._dbal.Select("theme_salle",
                "salle = " + s.Id + " AND " +
                "dateDebut < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND " +
                "dateFin > '" + DateTime.Now.ToString("yyyy-MM-dd") + "'"
            ).Rows[0];
            DataRow row = this._dbal.SelectById("theme", (int)rowTs["theme"]);
            return new Theme(row);
        }

        public List<Theme> GetAllTheme()
        {
            DataTable tab = _dbal.Select("theme");
            List<Theme> lstT = new List<Theme>();
            foreach (DataRow row in tab.Rows)
            {
                lstT.Add(new Theme(row));
            }
            return lstT;
        }
    }
}
