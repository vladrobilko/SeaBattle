using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository.Repositories
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
