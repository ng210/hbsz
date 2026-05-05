using System.Collections.Generic;

namespace CardGame.Model
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards;
        public int Score { get; set; }
        public int[] Ip4Address { get; set; }
    }
}
