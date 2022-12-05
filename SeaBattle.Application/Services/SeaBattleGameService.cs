using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services
{
    public class SeaBattleGameService : ISeaBattleGameService
    {
        private readonly ISeaBattleGameRepository _seaBattleGameRepository;

        private readonly ISessionRepository _sessionRepository;

        public SeaBattleGameService(ISeaBattleGameRepository seaBattleGameService, ISessionRepository sessionRepository)
        {
            _seaBattleGameRepository = seaBattleGameService;
            _sessionRepository = sessionRepository;
        }

        public void StartGame(string nameSession)
        {
            if (_sessionRepository.IsSessionReadyToStartGame(nameSession))
            {
                var gameSession = _sessionRepository.GetSessionModel(nameSession);
                var game = new SeaBattleGameModel
                    (new PlayerModel(new FillerRandom(), gameSession.SessionName),
                    new PlayerModel(new FillerRandom(), gameSession.JoinPlayerName),
                    gameSession.SessionName);
                game.Start();

            }
            else
            {
                throw new Exception("The game can't start");
            }
        }

    }
}
