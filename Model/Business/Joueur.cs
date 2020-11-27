using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Joueur : IHydrate
    {
        private int _id;
        private string _pseudo;
        private string _email;

        private List<Avis> _lstAvis;

        public Joueur(string pseudo, string email, int id = 0)
        {
            _id = id;
            _pseudo = pseudo;
            _email = email;
            _lstAvis = new List<Avis>();
        }

        public Joueur()
        {
            _id = 0;
            _pseudo = "";
            _email = "";
            _lstAvis = new List<Avis>();
        }

        public int Id { get => _id; set => _id = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        public string Email { get => _email; set => _email = value; }
        public List<Avis> LstAvis { get => _lstAvis; set => _lstAvis = value; }

        public Avis NouvelleAvis(string msg)
        {
            Avis a = new Avis(this, msg);
            _lstAvis.Add(a);
            return a;
        }

        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _pseudo = val["pseudo"];
            _email = val["email"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("pseudo", _pseudo);
            val.Add("email", _email);
            return val;
        }
    }
}
