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

        public DateTime? OpenedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        public List<ResultBet>? Result { get; set; }

        public IDictionary<string,string> board { get; set; } = new Dictionary<string, string>();
        

    }
}
