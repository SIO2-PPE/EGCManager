using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Avis
    {
        private int id;
        private Joueur createur;
        private string commentaire;
        private DateTime creation;

        public Avis(Joueur createur, string commentaire, DateTime creation, int id = 0)
        {
            this.id = id;
            this.createur = createur;
            this.commentaire = commentaire;
            this.creation = creation;
        }
        public Avis()
        {
            this.id = 0;
            this.createur = new Joueur();
            this.commentaire = "";
            this.creation = new DateTime();
        }
        /// <summary>
        /// id = 0 ; creation = Now
        /// </summary>
        public Avis(Joueur createur, string commentaire)
        {
            this.id = 0;
            this.createur = createur;
            this.commentaire = commentaire;
            this.creation = DateTime.Now;
        }

        public int Id { get => id; set => id = value; }
        public Joueur Createur { get => createur; set => createur = value; }
        public string Commentaire { get => commentaire; set => commentaire = value; }
        public DateTime Creation { get => creation; set => creation = value; }
    }
}
