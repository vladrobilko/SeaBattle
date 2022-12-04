using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattleApi.Models;

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

        public void Start(string nameSession)
        {
            if (_sessionRepository.IsSessionReadyToStartGame(nameSession))
            {
                var gameSession = _sessionRepository.GetSessionModel(nameSession);
                var game = new SeaBattleGameModel
                    (new PlayerModel(new FillerRandom(), gameSession.SessionName),
                    new PlayerModel(new FillerRandom(), gameSession.JoinPlayerName),
                    gameSession.SessionName);
                game.Start();
                //_seaBattleGameService. - тут будем добалвть уже начатую игру 
            }
            else
            {
                throw new Exception("The game can't start");
            }
        }

    }
}
