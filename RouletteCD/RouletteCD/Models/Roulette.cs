using RouletteCD.DataStructure;
using System;
using System.Collections.Generic;

namespace RouletteCD.Models
{
    [Serializable]
    public class Roulette
    {
        public string idRoulette { get; set; }
        public bool IsOpen { get; set; } = false;
        public DateTime? openedAt { get; set; }
        public DateTime? closedAt { get; set; }                
        public List<ResultBet>? result { get; set; } = new List<ResultBet>();
        public List<BDataStructure>? board { get; set; } = new List<BDataStructure>();

    }
}
