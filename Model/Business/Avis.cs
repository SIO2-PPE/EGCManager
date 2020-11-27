using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Avis : IHydrate
    {
        private int _id;
        private Joueur _createur;
        private string _commentaire;
        private DateTime _creation;

        public Avis(Joueur createur, string commentaire, DateTime creation, int id = 0)
        {
            _id = id;
            _createur = createur;
            _commentaire = commentaire;
            _creation = creation;
        }
        public Avis()
        {
            _id = 0;
            _createur = new Joueur();
            _commentaire = "";
            _creation = new DateTime();
        }
        /// <summary>
        /// id = 0 ; creation = Now
        /// </summary>
        public Avis(Joueur createur, string commentaire)
        {
            _id = 0;
            _createur = createur;
            _commentaire = commentaire;
            _creation = DateTime.Now;
        }

        public int Id { get => _id; set => _id = value; }
        public Joueur Createur { get => _createur; set => _createur = value; }
        public string Commentaire { get => _commentaire; set => _commentaire = value; }
        public DateTime Creation { get => _creation; set => _creation = value; }

        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _createur = val["createur"];
            _commentaire = val["commentaire"];
            _creation = val["creation"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("createur", _createur);
            val.Add("commentaire", _commentaire);
            val.Add("creation", _creation);
            return val;
        }
    }
}
