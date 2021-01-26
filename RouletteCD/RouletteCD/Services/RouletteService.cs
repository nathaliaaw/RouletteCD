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
                OpenedAt = null,
                ClosedAt = null
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

            if (roulette.OpenedAt != null)
            {
                throw new NotAllowedOpenException();
            }
            roulette.OpenedAt = DateTime.Now;
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
            if (roulette.ClosedAt != null)
            {
                throw new NotAllowedClosedException();
            }
            roulette.ClosedAt = DateTime.Now;
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
            roulette.board.Add("numberBet", request.numberBet.ToString());
            roulette.board.Add("moneyBet", request.moneyBet.ToString());
            roulette.board.Add("colorBet", request.colorBet);
            roulette.board.Add("UserId", request.UserId);

            return rouletteRepository.Update(roulette.idRoulette, roulette);
        }

        public List<Roulette> GetAll()
        {
            return rouletteRepository.GetAll();
        }
    }
}
