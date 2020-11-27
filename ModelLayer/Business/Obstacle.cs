using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Obstacle
    {
        private int id;
        private string nom;
        private string type;
        private string description;
        private string photo;

        public Obstacle(string nom, string type, string description, string photo, int id = 0)
        {
            this.id = id;
            this.nom = nom;
            this.type = type;
            this.description = description;
            this.photo = photo;
        }
        public Obstacle()
        {
            this.id = 0;
            this.nom = "";
            this.type = "";
            this.description = "";
            this.photo = "";
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public string Photo { get => photo; set => photo = value; }
    }
}
