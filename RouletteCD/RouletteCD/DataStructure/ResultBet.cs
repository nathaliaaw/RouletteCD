
using System;

namespace RouletteCD.DataStructure
{
    [Serializable]
    public class ResultBet
    {
        public string? userIdBet { get; set; }
        public int? moneyEarning { get; set; }
        public int? numberWinner { get; set; }
        public string ?message { get; set; }
    }
}
