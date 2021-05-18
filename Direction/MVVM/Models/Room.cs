namespace Direction.Models
{
    public class Room
    {
        private string _theme;
        private int _nbOfGame;

        public Room(string theme, int nbOfGame)
        {
            _theme = theme;
            _nbOfGame = nbOfGame;
        }

        public string Theme { get => _theme; set => _theme = value; }
        public int NbOfGame { get => _nbOfGame; set => _nbOfGame = value; }
    }
}
