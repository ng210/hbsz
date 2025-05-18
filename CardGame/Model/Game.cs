using System.Collections.Generic;

namespace CardGame.Model
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Player Host { get; set; }
        public int Round { get; set; }
    }
}
