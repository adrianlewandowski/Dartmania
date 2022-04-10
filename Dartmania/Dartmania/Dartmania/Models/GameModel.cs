using System;
using System.Collections.Generic;
using System.Text;

namespace Dartmania.Models
{
    public class GameModel
    {
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public List<int> ThrowsPlayer1 { get; set; }
        public List<int> ThrowsPlayer2 { get; set; }

        public GameModel()
        {
            Score1 = 501;
            Score2 = 501;
            ThrowsPlayer1 = new List<int> { };
            ThrowsPlayer2 = new List<int> { };
        }
    }

}
