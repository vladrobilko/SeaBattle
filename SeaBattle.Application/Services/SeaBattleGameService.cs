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

        private readonly IPlayerRepository _playerRepository;

        public SeaBattleGameService(ISeaBattleGameRepository seaBattleGameService,
            ISessionRepository sessionRepository, IPlayerRepository playerRepository)
        {
            _seaBattleGameRepository = seaBattleGameService;
            _sessionRepository = sessionRepository;
            _playerRepository = playerRepository;
        }

        public void StartGame(string nameSession, string hostName)
        {
            //if (!_sessionRepository.IsSessionReadyToStartGame(nameSession))
                //throw new Exception("The game can't start");

            var gameSession = _sessionRepository.GetStartSessionByName(nameSession);
            var game = new SeaBattleGameModel
                (new PlayerModel(new FillerRandom(), gameSession.SessionName),
                new PlayerModel(new FillerRandom(), gameSession.JoinPlayerName),
                gameSession.SessionName);
            game.Start();


        }

    }
}
