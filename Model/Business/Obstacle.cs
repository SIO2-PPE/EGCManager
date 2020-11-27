using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Business
{
    public class Obstacle : IHydrate
    {
        private int _id;
        private string _nom;
        private string _type;
        private string _description;
        private string _photo;

        public Obstacle(string nom, string type, string description, string photo, int id = 0)
        {
            _id = id;
            _nom = nom;
            _type = type;
            _description = description;
            _photo = photo;
        }
        public Obstacle()
        {
            _id = 0;
            _nom = "";
            _type = "";
            _description = "";
            _photo = "";
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Type { get => _type; set => _type = value; }
        public string Description { get => _description; set => _description = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public void Hydrate(Dictionary<string, dynamic> val)
        {
            _id = val["id"];
            _nom = val["nom"];
            _type = val["type"];
            _description = val["description"];
            _photo = val["photo"];
        }

        public Dictionary<string, dynamic> ToArray()
        {
            Dictionary<string, dynamic> val = new Dictionary<string, dynamic>();
            val.Add("id", _id);
            val.Add("nom", _nom);
            val.Add("type", _type);
            val.Add("description", _description);
            val.Add("photo", _photo);
            return val;
        }
    }
}
