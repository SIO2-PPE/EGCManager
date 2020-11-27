using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Salle
    {
        private int id;
        private Site site;
        private Theme theme;

        public Salle(int id, Site site, Theme theme)
        {
            this.id = id;
            this.site = site;
            this.theme = theme;
        }
        public Salle(int id = 0)
        {
            this.id = id;
            this.site = new Site();
            this.theme = new Theme();
        }

        public int Id { get => id; set => id = value; }
        public Site Site { get => site; set { site = value; site.LstSalle.Add(this); } }
        public Theme Theme { get => theme; set => theme = value; }
    }
}
