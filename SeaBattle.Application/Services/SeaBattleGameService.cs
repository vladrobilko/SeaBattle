﻿using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Interfaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services
{
    public class SeaBattleGameService : ISeaBattleGameService
    {
        private readonly ISeaBattleGameRepository _seaBattleGameRepository;

        private readonly ISessionRepository _sessionRepository;

        private readonly SeaBattleGameStateChanger _seaBattleGameChanger;

        public SeaBattleGameService(ISeaBattleGameRepository seaBattleGameService, ISessionRepository sessionRepository)
        {
            _seaBattleGameRepository = seaBattleGameService;
            _sessionRepository = sessionRepository;
            _seaBattleGameChanger = new SeaBattleGameStateChanger();
        }

        public GameAreaClientModel GetPlayArea(InfoPlayerClientModel infoPlayerClientModel)
        {
            var playerStateModel = new PlayerSeaBattleStateModel(
                _seaBattleGameRepository,
                new FillerRandom(),
                infoPlayerClientModel.PlayerName);

            playerStateModel.FillShips();
            _seaBattleGameRepository.CreateOrUpdatePlayerStateModel(playerStateModel);

            var gameAreaClientModel = new GameAreaClientModel
            {
                ClientPlayArea = playerStateModel.GetPlayArea().ToStringsForClient()
            };

            return gameAreaClientModel;
        }

        public GameClientStateModel GetGameModel(InfoPlayerClientModel? infoPlayerClientModel)
        {
            return _seaBattleGameRepository
                .ReadGameStateModelByNameSession(infoPlayerClientModel!.SessionName)
                .ToGameClientModel(infoPlayerClientModel.PlayerName);
        }

        public void ReadyToStartGame(InfoPlayerClientModel? infoPlayerClientModel)
        {
            _seaBattleGameRepository.UpdatePlayareaToReadyForGame(infoPlayerClientModel!.PlayerName);
            TryToStartGame(infoPlayerClientModel.SessionName);
        }

        private void TryToStartGame(string? nameSession)
        {
            var startSession = _sessionRepository.ReadStartSessionByName(nameSession);

            if (startSession != null)
            {
                var player1 = _seaBattleGameRepository.ReadConfirmedPlayerStateModelByName(startSession.NameHostPlayer);

                var player2 = _seaBattleGameRepository.ReadConfirmedPlayerStateModelByName(startSession.NameJoinPlayer);

                if (player1 != null && player2 != null)
                {
                    StartGame(player1, player2, nameSession);
                }
            }
        }

        private void StartGame(IPlayer player1, IPlayer player2, string? nameSession)
        {
            var gameState = new GameState(
                    player1,
                    player2,
                    player2.NamePlayer,
                    true,
                    GameStateMessage.WhoShoot(player2.NamePlayer));

            _seaBattleGameRepository.UpdateGameStateModel(gameState, nameSession);

            Task.Run(() => _seaBattleGameRepository.EndGameIfPlayerNotShot(nameSession));
        }

        public void Shoot(ShootClientModel? shootPlayerClientModel)
        {
            _seaBattleGameRepository.CreateOrUpdateValidShoot(shootPlayerClientModel!.ToShootModel());

            var lastGameModel = _seaBattleGameRepository.ReadGameStateModelByNameSession(shootPlayerClientModel?.NameSession);

            var changeGameModel = _seaBattleGameChanger.ChangeGameState(lastGameModel);

            _seaBattleGameRepository.UpdateGameStateModel(changeGameModel, shootPlayerClientModel?.NameSession);

            Task.Run(() => _seaBattleGameRepository.EndGameIfPlayerNotShot(shootPlayerClientModel!.NameSession));
        }
    }
}
