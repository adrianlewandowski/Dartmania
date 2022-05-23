using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Dartmania.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageScore { get; set; }
        public int BestScore { get; set; }
    }
}
