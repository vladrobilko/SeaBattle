using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Repository.Converters;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services
{
    public class SeaBattleGameService : ISeaBattleGameService
    {
        private readonly ISeaBattleGameRepository _seaBattleGameRepository;

        private readonly ISessionRepository _sessionRepository;

        SeaBattleGameStateChanger _seaBattleGameChanger;

        public SeaBattleGameService(ISeaBattleGameRepository seaBattleGameService, ISessionRepository sessionRepository)
        {
            _seaBattleGameRepository = seaBattleGameService;
            _sessionRepository = sessionRepository;
            _seaBattleGameChanger = new SeaBattleGameStateChanger();
        }
        public GameAreaClientModel GetPlayArea(InfoPlayerClientModel infoPlayerClientModel)
        {
            var playerModel = new PlayerSeaBattleStateModel(new FillerRandom(), infoPlayerClientModel.PlayerName, _seaBattleGameRepository);
            var gameAreaClientModel = new GameAreaClientModel();
            playerModel.FillShips();
            _seaBattleGameRepository.ResaveLastPlayerStateModel(playerModel);
            gameAreaClientModel.ClientPlayArea = playerModel.GetPlayArea().ConvertToArrayStringForClient();
            return gameAreaClientModel;
        }

        public GameClientStateModel GetGameModel(InfoPlayerClientModel infoPlayerClientModel)
        {
            return _seaBattleGameRepository
                .GetGameStateModelOrThrowExceptionByNameSession(infoPlayerClientModel.SessionName)
                .ConvertToGameClientModel(infoPlayerClientModel.PlayerName);
        }

        public void ReadyToStartGame(InfoPlayerClientModel infoPlayerClientModel)
        {
            _seaBattleGameRepository.SaveConfirmedPlayerStateModel(infoPlayerClientModel.PlayerName);
            TryToStartGame(infoPlayerClientModel.SessionName);
        }

        private void TryToStartGame(string nameSession)
        {
            var startSession = _sessionRepository.GetStartSessionByNameOrNull(nameSession);
            if (startSession != null)
            {
                var player1 = _seaBattleGameRepository.GetConfirmedPlayerStateModelByName(startSession.NameHostPlayer);
                var player2 = _seaBattleGameRepository.GetConfirmedPlayerStateModelByName(startSession.NameJoinPlayer);
                if (player1 != null && player2 != null)
                {
                    StartGame(player1, player2, nameSession);
                }
            }
        }

        private void StartGame(IPlayer player1, IPlayer player2, string nameSession)
        {
            var gameState = new GameStateModel(
                    player1,
                    player2,
                    player2.NamePlayer,//первый ходит второй игрой, который подключился
                    true,
                    GameStateMessage.WhoShoot(player2.NamePlayer));
            _seaBattleGameRepository.ResaveGameStateDtoModel(gameState, nameSession);
        }

        public void Shoot(ShootPlayerClientModel shootPlayerClientModel)
        {
            _seaBattleGameRepository.ResaveValidShoot(shootPlayerClientModel.ConvertToShootModel());
            var lastGameModel = _seaBattleGameRepository.GetGameStateModelOrThrowExceptionByNameSession(shootPlayerClientModel.NameSession);
            var changeGameModel = _seaBattleGameChanger.ChangeGameState(lastGameModel);
            _seaBattleGameRepository.ResaveGameStateDtoModel(changeGameModel,shootPlayerClientModel.NameSession);
        }
    }
}
