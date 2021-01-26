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
        public IDictionary<string, string> result { get; set; } = new Dictionary<string, string>();        
        public List<BDataStructure>? board { get; set; } = new List<BDataStructure>();

    }
}
