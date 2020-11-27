using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Site
    {
        private int id;
        private string ville;
        private string adresse;
        private List<Salle> lstSalle;

        public Site(string ville, string adresse, int id = 0)
        {
            this.id = id;
            this.ville = ville;
            this.adresse = adresse;
            this.lstSalle = new List<Salle>();

        }
        public Site()
        {
            this.id = 0;
            this.ville = "";
            this.adresse = "";
            this.lstSalle = new List<Salle>();
        }

        public int Id { get => id; set => id = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public List<Salle> LstSalle { get => lstSalle; set => lstSalle = value; }

        public Salle nouvelleSalle(Theme th)
        {
            Salle s = new Salle(0, this, th);
            this.lstSalle.Add(s);
            return s; 
        }
    }
}
