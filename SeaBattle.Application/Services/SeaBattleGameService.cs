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
            var playerModel = new PlayerSeaBattleStateModel(new FillerRandom(), infoPlayerClientModel.PlayerName, infoPlayerClientModel.SessionName);
            var gameAreaClientModel = new GameAreaClientModel();
            playerModel.FillShips();
            _seaBattleGameRepository.ResaveLastPlayerStateModel(playerModel);
            gameAreaClientModel.ClientPlayArea = playerModel
                                                        .GetPlayArea()
                                                        .ConvertToArrayStringForClient();

            return gameAreaClientModel;
        }

        public void ReadyToStartGame(InfoPlayerClientModel infoPlayerClientModel)
        {
            _seaBattleGameRepository.SaveConfirmedPlayerStateModel(infoPlayerClientModel.PlayerName);
            TryToStartGame(infoPlayerClientModel.SessionName);
        }

        private void TryToStartGame(string nameSession)
        {
            var startSession = _sessionRepository.GetStartSessionByName(nameSession);
            if (startSession != null)
            {
                var player1 = _seaBattleGameRepository.GetConfirmedPlayerStateModelByName(startSession.HostPlayerName);
                var player2 = _seaBattleGameRepository.GetConfirmedPlayerStateModelByName(startSession.JoinPlayerName);
                if (player1 != null && player2 != null)
                {
                    StartGame(player1, player2, nameSession);
                }
            }
        }

        private void StartGame(IPlayer player1, IPlayer player2, string nameSession)
        {
            _seaBattleGameRepository.ResaveGameStateModel(new GameStateModel()
            {
                Player1 = player1,
                Player2 = player2,
                NameSession = nameSession,
                IsGameOn = true,
                NamePlayerTurn = player1.Name,
                GameMessage = GameStateMessage.WhoShoot(player1.Name),
            });
            //var game = new SeaBattleGame(player1, player2);//первый ходит player2
            //game.Start();


        }

        public GameClientStateModel GetGameModel(string nameSession, string nameClient)
        {
            return _seaBattleGameRepository.GetGameStateModelByNameSession(nameSession).ConvertToGameClientModel(nameClient);
        }
    }
}
