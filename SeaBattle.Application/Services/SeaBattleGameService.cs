using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
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

        public GameAreaClientModel GetPlayArea(InfoPlayerClientModel infoPlayerClientModel)
        {
            var playerModel = new PlayerModel(new FillerRandom(), infoPlayerClientModel.PlayerName);
            playerModel.Name = infoPlayerClientModel.PlayerName;
            var gameAreaClientModel = new GameAreaClientModel();
            playerModel.FillShips();
            _seaBattleGameRepository.SaveLastPlayerModel(playerModel);
            gameAreaClientModel.ClientPlayArea = playerModel.GetPlayArea().ConvertToArrayString();

            return gameAreaClientModel;
        }















        private void StartGame(string nameSession, string hostName)
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
