using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Theme
    {
        private int id;
        private string nom;
        
        public Theme(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }
        public Theme()
        {
            this.id = 0;
            this.nom = "";
        }
        
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
