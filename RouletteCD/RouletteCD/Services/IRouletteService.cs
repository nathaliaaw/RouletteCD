using System.Collections.Generic;
using RouletteCD.DataStructure;
using RouletteCD.Models;

namespace RouletteCD.Services
{
    public interface IRouletteService:IService
    {
        public Roulette create();

        public Roulette Find(string Id);

        public Roulette openRoulette(string idRoulette);
        public Roulette closeRoulette(string idRoulette);

        public Roulette betValues(string Id, BDataStructure request);

        public List<Roulette> GetAll();
    }
}
