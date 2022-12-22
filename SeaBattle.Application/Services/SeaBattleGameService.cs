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

        public SeaBattleGameService(ISeaBattleGameRepository seaBattleGameService, ISessionRepository sessionRepository)
        {
            _seaBattleGameRepository = seaBattleGameService;
            _sessionRepository = sessionRepository;
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

        public void ReadyToStartGame(InfoPlayerClientModel infoPlayerClientModel)
        {
            _seaBattleGameRepository.SaveConfirmedPlayerModel(infoPlayerClientModel.PlayerName);
            TryToStartGame(infoPlayerClientModel.SessionName);
        }

        private void TryToStartGame(string nameSession)
        {
            var session = _sessionRepository.GetStartSessionByName(nameSession);
            var player1 = _seaBattleGameRepository.GetConfirmedPlayerModelByName(session.HostPlayerName);
            var player2 = _seaBattleGameRepository.GetConfirmedPlayerModelByName(session.JoinPlayerName);
            if (player1 != null && player2 != null)
            {
                StartGame(player1, player2, nameSession);
            }
        }

        private void StartGame(IPlayer player1, IPlayer player2, string nameSession)
        {
            var gameSession = _sessionRepository.GetStartSessionByName(nameSession);
            var game = new SeaBattleGameModel(player1, player2, gameSession.SessionName);
            game.Start();
            _seaBattleGameRepository.SaveGameModel(game);


        }

        public GameClientModel GetGameModel(string nameSession, string nameClient)
        {
            var gameModel = _seaBattleGameRepository.GetLastGameModelByNameSession(nameSession);

            return gameModel.ConvertToGameClientModel(nameClient);
        }
    }
}
