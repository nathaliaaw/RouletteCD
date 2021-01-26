using System;
using System.ComponentModel.DataAnnotations;

namespace RouletteCD.DataStructure
{
    [Serializable]
    public class BDataStructure
    {
        [Range(0, 38)]
        public int? numberBet { get; set; }
        [Range(0.5d, maximum: 10000)]
        public int? moneyBet { get; set; }
        public string? colorBet { get; set; }
        public string? UserId { get; set; }
        
    }
}
