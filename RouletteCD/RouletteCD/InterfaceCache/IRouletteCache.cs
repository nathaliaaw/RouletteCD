using System.Collections.Generic;
using RouletteCD.Models;

namespace RouletteCD.InterfaceCache
{
    public interface IRouletteCache:ICache
    {
        public Roulette GetById(string Id);

        public List<Roulette> GetAll();

        public Roulette Update(string idRoulette, Roulette roulette);

        public Roulette Save(Roulette roulette);
    }
}
