using System;
using System.Collections.Generic;
using System.Linq;
using RouletteCD.Models;
using EasyCaching.Core;
using System.Threading.Tasks;

namespace RouletteCD.InterfaceCache
{
    public class RouletteCache:IRouletteCache
    {
        private IEasyCachingProviderFactory cachingProviderFactory;

        private IEasyCachingProvider cachingProvider;

        private const string KEYREDIS = "KEYTABLEROULETE";

        public RouletteCache(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this.cachingProviderFactory = cachingProviderFactory;
            this.cachingProvider = this.cachingProviderFactory.GetCachingProvider("roulette");

        }

        public Roulette GetById(string Id)
        {
            var item = this.cachingProvider.Get<Roulette>(KEYREDIS + Id);
            if (!item.HasValue)
            {
                return null;
            }
            return item.Value;
        }

        public List<Roulette> GetAll()
        {
            var rouletes = this.cachingProvider.GetByPrefix<Roulette>(KEYREDIS);
            if (rouletes.Values.Count == 0)
            {
                return new List<Roulette>();
            }
            return new List<Roulette>(rouletes.Select(x => x.Value.Value));
        }

        public Roulette Update(string Id, Roulette roulette)
        {
            roulette.idRoulette = Id;
            return Save(roulette);
        }

        public Roulette Save(Roulette roulette)
        {
            cachingProvider.Set(KEYREDIS + roulette.idRoulette, roulette, TimeSpan.FromDays(365));
            return roulette;
        }
    }
}
