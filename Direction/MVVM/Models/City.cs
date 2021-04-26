using System;
using System.Collections.Generic;
using System.Text;

namespace Direction.Models
{
    public class City
    {
        private string name;
        private List<Room> rooms;

        public City(string name)
        {
            this.name = name;
            this.rooms = new List<Room>();
        }

        public string Name { get => name; set => name = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }
    }
}
