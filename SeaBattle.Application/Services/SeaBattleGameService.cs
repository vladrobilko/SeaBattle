using SeaBattle.Application.Services.Interfaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattle.Application.Services
{
    public class SeaBattleGameService : ISeaBattleGameService
    {
        private readonly ISeaBattleGameRepository _seaBattleGameService;

        private readonly ISessionRepository _sessionRepository;

        public SeaBattleGameService(ISeaBattleGameRepository seaBattleGameService)
        {
            _seaBattleGameService = seaBattleGameService;
        }

        public void StartGame(string nameSession)
        {
            if (_sessionRepository.IsSessionReadyToStartGame(nameSession))
            {
                //_seaBattleGameService. - тут будем добалвть уже начатую игру 
            }
        }
    }
}
