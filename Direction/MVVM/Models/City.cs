using System.Collections.Generic;

namespace Direction.Models
{
    public class City
    {
        private string _name;
        private List<Room> _rooms;

        public City(string name)
        {
            _name = name;
            _rooms = new List<Room>();
        }

        public string Name { get => _name; set => _name = value; }
        public List<Room> Rooms { get => _rooms; set => _rooms = value; }
    }
}
