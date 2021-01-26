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

        //public Dictionary<string, double>? board  = new Dictionary<string, double>();
        public List<BDataStructure> ? board { get; set; } 


        //public Roulette()
        //{
        //    this.Init();
        //}
        //private void Init()
        //{
        //    for (int i = 0; i < board.Length; i++)
        //    {
        //        board[i] = new Dictionary<string, double>();
        //    }
        //}
    }
}
