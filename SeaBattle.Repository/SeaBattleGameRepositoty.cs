using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Repository.Models;
using SeaBattle.Repository.Services;

namespace SeaBattle.Repository
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        private readonly List<SeaBattleGameDtoModel> _startedGames;

        public SeaBattleGameRepositoty()
        {
            _startedGames = new List<SeaBattleGameDtoModel>();
        }

        public void AddGame()
        {
            throw new NotImplementedException();
        }
    }
}
