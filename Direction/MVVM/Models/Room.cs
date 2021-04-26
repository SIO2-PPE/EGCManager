using System;
using System.Collections.Generic;
using System.Text;

namespace Direction.Models
{
    public class Room
    {
        private string theme;
        private int nbOfGame;

        public Room(string theme, int nbOfGame)
        {
            this.theme = theme;
            this.nbOfGame = nbOfGame;
        }

        public string Theme { get => theme; set => theme = value; }
        public int NbOfGame { get => nbOfGame; set => nbOfGame = value; }
    }
}
