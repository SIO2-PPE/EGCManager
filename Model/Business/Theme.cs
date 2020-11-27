using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Theme : IHydrate
    {
        private int _id;
        private string _nom;
        
        public Theme(int id, string nom)
        {
            _id = id;
            _nom = nom;
        }
        public Theme()
        {
            _id = 0;
            _nom = "";
        }
        
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }


        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _nom = val["nom"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("nom", _nom);
            return val;
        }
    }
}
