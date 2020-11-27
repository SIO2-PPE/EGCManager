using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Salle : IHydrate
    {
        private int _id;
        private Site _site;
        private Theme _theme;

        public Salle(int id, Site site, Theme theme)
        {
            _id = id;
            _site = site;
            _theme = theme;
        }
        public Salle(int id = 0)
        {
            _id = id;
            _site = new Site();
            _theme = new Theme();
        }

        public int Id { get => _id; set => _id = value; }
        public Site Site { get => _site; set { _site = value; _site.LstSalle.Add(this); } }
        public Theme Theme { get => _theme; set => _theme = value; }
        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _site = val["site"];
            _theme = val["theme"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("site", _site);
            val.Add("theme", _theme);
            return val;
        }
    }
}
