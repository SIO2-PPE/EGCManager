using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Joueur
    {
        private int id;
        private string pseudo;
        private string email;

        private List<Avis> lstAvis;

        public Joueur(string pseudo, string email, int id = 0)
        {
            this.id = id;
            this.pseudo = pseudo;
            this.email = email;
            this.lstAvis = new List<Avis>();
        }

        public Joueur()
        {
            this.id = 0;
            this.pseudo = "";
            this.email = "";
            this.lstAvis = new List<Avis>();
        }

        public int Id { get => id; set => id = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Email { get => email; set => email = value; }
        public List<Avis> LstAvis { get => lstAvis; set => lstAvis = value; }

        public Avis NouvelleAvis(string msg)
        {
            Avis a = new Avis(this, msg);
            lstAvis.Add(a);
            return a;
        }
    }
}
