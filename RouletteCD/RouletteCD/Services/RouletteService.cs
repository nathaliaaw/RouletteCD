using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteCD.Exceptions;
using RouletteCD.Models;
using RouletteCD.InterfaceCache;
using RouletteCD.DataStructure;

namespace RouletteCD.Services
{
    public class RouletteService : IRouletteService
    {
        private IRouletteCache rouletteRepository;

        public RouletteService(IRouletteCache rouletteRepository)
        {
            this.rouletteRepository = rouletteRepository;
        }

        public Roulette create()
        {
            Roulette roulette = new Roulette()
            {
                idRoulette = Guid.NewGuid().ToString(),
                IsOpen = false,
                openedAt = null,
                closedAt = null
            };
            rouletteRepository.Save(roulette);
            return roulette;
        }

        public Roulette Find(string Id)
        {
            return rouletteRepository.GetById(Id);
        }

        public Roulette openRoulette(string idRoulette)
        {
            Roulette roulette = rouletteRepository.GetById(idRoulette);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }

            if (roulette.openedAt != null)
            {
                throw new NotAllowedOpenException();
            }
            roulette.openedAt = DateTime.Now;
            roulette.IsOpen = true;
            return rouletteRepository.Update(idRoulette, roulette);
        }

        public Roulette Close(string Id)
        {
            Roulette roulette = rouletteRepository.GetById(Id);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }
            if (roulette.closedAt != null)
            {
                throw new NotAllowedClosedException();
            }
            roulette.closedAt = DateTime.Now;
            roulette.IsOpen = false;
            return rouletteRepository.Update(Id, roulette);
        }

        public Roulette betValues(string Id,  BDataStructure request)
        {
            if (request.moneyBet > 10000 || request.moneyBet < 1)
            {
                throw new CashOutRangeException();
            }
            Roulette roulette = rouletteRepository.GetById(Id);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }

            if (roulette.IsOpen == false)
            {
                throw new RouletteClosedException();
            }

            //List<BDataStructure> parts = new List<BDataStructure>();

            //parts.Add(new BDataStructure() { numberBet = request.numberBet, moneyBet=request.moneyBet, colorBet=request.colorBet,UserId=request.UserId});
            roulette.board.Add(request);

            return rouletteRepository.Update(roulette.idRoulette, roulette);
        }

        public List<Roulette> GetAll()
        {
            return rouletteRepository.GetAll();
        }
    }
}
