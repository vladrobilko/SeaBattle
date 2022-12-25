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
            gameAreaClientModel.ClientPlayArea = playerModel.GetPlayArea().ConvertToArrayStringForClient();
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

        public GameClientStateModel GetGameModel(InfoPlayerClientModel infoPlayerClientModel)
        {
            return _seaBattleGameRepository
                .GetGameStateModelByNameSession(infoPlayerClientModel.SessionName)
                .ConvertToGameClientModel(infoPlayerClientModel.PlayerName);
        }

        private void StartGame(IPlayer player1, IPlayer player2, string nameSession)
        {
            _seaBattleGameRepository.ResaveGameStateModel(
                new GameStateModel(player1, player2, nameSession, player2.Name, true, GameStateMessage.WhoShoot(player2.Name)));
            var game = new SeaBattleGame(player1, player2);//первый ходит player2
            game.Start();


        }

        public void Shoot(ShootPlayerClientModel shootPlayerClientModel)
        {
            _seaBattleGameRepository.ResaveValidShoot(shootPlayerClientModel.ConvertToShootModel());
        }
    }
}
