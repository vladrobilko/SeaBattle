using SeaBattle.Application.Converters;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Converters;
using SeaBattle.DataManagement.Models;
using SeaBattleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SeaBattle.DataManagement.Repositories
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        private readonly SeabattleContext _context;

        public SeaBattleGameRepositoty(SeabattleContext context)
        {
            _context = context;
        }

        public void ReadyToStartGame(string namePlayer)
        {
            var player = _context.Players.FirstOrDefault(p => p.Name == namePlayer)
                ?? throw new NotImplementedException();

            var playAreaInDb = _context.Playareas.FirstOrDefault(p => p.IdPlayer == player.Id);

            playAreaInDb.ConfirmedPlayarea = DateTime.UtcNow; 

            _context.Playareas.Attach(playAreaInDb);
            _context.Entry(playAreaInDb).Property(r => r.ConfirmedPlayarea).IsModified = true;
            _context.SaveChanges();
        }

        public void SaveOrResavePlayerStateModel(IPlayer playerModel)
        {
            var player = _context.Players.FirstOrDefault(p => p.Name == playerModel.NamePlayer)
                ?? throw new NotImplementedException();

            var textModel = playerModel.GetPlayArea().ConvertToString();

            var playArea = new Playarea() { IdPlayer = player.Id, Playarea1 = textModel };

            var playAreaInDb = _context.Playareas.FirstOrDefault(p => p.IdPlayer == player.Id);

            if (playAreaInDb != null)
            {
                playAreaInDb.Playarea1 = textModel;
                _context.Playareas.Attach(playAreaInDb);
                _context.Entry(playAreaInDb).Property(r => r.Playarea1).IsModified= true;
                _context.SaveChanges();
                return;
            }
            _context.Playareas.Add(playArea);
            _context.SaveChanges();
        }

        public PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByNameOrNull(string name)
        {
            var player = _context.Players.FirstOrDefault(p => p.Name == name)
                ?? throw new NotImplementedException();

            var session = _context.Sessions.FirstOrDefault(p => p.IdPlayerHost == player.Id || p.IdPlayerJoin == player.Id)
                ?? throw new NotImplementedException();

            var playAreaModel = _context.Playareas.FirstOrDefault(p => p.IdPlayer == player.Id);

            if(playAreaModel.ConfirmedPlayarea == null)
            {
                return null;
            }
            var playarea = _context.Playareas.FirstOrDefault(p => p.IdPlayer == player.Id)?.Playarea1.ConvertToPlayArea();

            var enemyPlayArea = _context.Playareas.FirstOrDefault(p => p.IdPlayer == session.IdPlayerJoin)?.Playarea1.ConvertToPlayArea();

            if (playarea == null)
            {
                return null;
            }

            var playerStateModel = new PlayerSeaBattleStateModel()
            {
                NamePlayer = name,
                PlayArea = playarea,
                PlayAreaEnemyForInformation = enemyPlayArea
            };

            return playerStateModel;
        }

        public GameState GetGameStateModelByNameSession(string nameSession)
        {
            var session = _context.Sessions.FirstOrDefault(p => p.Name == nameSession)
                ?? throw new NotImplementedException();

            var gameStateDto = _context.SeabattleGames.FirstOrDefault(p => p.IdSession == session.Id)
                ?? throw new NotImplementedException();

            var playerHost = _context.Players.FirstOrDefault(p => p.Id == session.IdPlayerHost)
                ?? throw new NotImplementedException();

            var playerJoin = _context.Players.FirstOrDefault(p => p.Id == session.IdPlayerJoin)
                ?? throw new NotImplementedException();

            var playerHostModel = GetConfirmedPlayerStateModelByNameOrNull(playerHost.Name);

            var playerJoinModel = GetConfirmedPlayerStateModelByNameOrNull(playerJoin.Name);

            var namePlayerTurn = _context.Players.FirstOrDefault(p => p.Id == gameStateDto.IdPlayerTurn)?.Name;

            var gameMessage = gameStateDto.GameMessage;

            var gameOn = gameStateDto.EndGame == null;

            return new GameState(playerHostModel, playerJoinModel, namePlayerTurn, gameOn, gameMessage);
        }

        public void ResaveGameStateModel(GameState gameStateModel, string NameSession)
        {
            var playerTurn = _context.Players.FirstOrDefault(p => p.Name == gameStateModel.NamePlayerTurn)
                ?? throw new NotImplementedException();

            var session = _context.Sessions.FirstOrDefault(p => p.Name == NameSession)
                ?? throw new NotImplementedException();

            var gameMessage = gameStateModel.GameMessage;

            var lastGameStateFromDto = _context.SeabattleGames.FirstOrDefault(p => p.IdSession == session.Id);

            var newGameStateIntoDto = new SeabattleGame();

            if (lastGameStateFromDto == null)//создание игры (отдельный метод)
            {
                newGameStateIntoDto.IdPlayerTurn = playerTurn.Id;
                newGameStateIntoDto.IdSession = session.Id;
                newGameStateIntoDto.GameMessage = gameMessage;
                newGameStateIntoDto.StartGame = DateTime.UtcNow;
                _context.SeabattleGames.Add(newGameStateIntoDto);
                _context.SaveChanges();
                return;
            }
            else if (lastGameStateFromDto != null && gameStateModel.IsGameOn) // изменить игру чтобы дальше играть
            {
                newGameStateIntoDto.IdPlayerTurn = playerTurn.Id;
                newGameStateIntoDto.GameMessage = gameMessage;
                SaveOrResavePlayerStateModel(gameStateModel.Player1);
                SaveOrResavePlayerStateModel(gameStateModel.Player2);
                _context.SeabattleGames.Attach(newGameStateIntoDto);
                _context.Entry(newGameStateIntoDto).Property(r => r.IdSession).IsModified = true;
                _context.SaveChanges();
            }

            else if (lastGameStateFromDto != null && !gameStateModel.IsGameOn) // конец игры (кто выиграл и дату окончания)
            {
                newGameStateIntoDto.IdPlayerTurn = null;
                newGameStateIntoDto.GameMessage = gameMessage;
                SaveOrResavePlayerStateModel(gameStateModel.Player1);
                SaveOrResavePlayerStateModel(gameStateModel.Player2);
                newGameStateIntoDto.EndGame = DateTime.UtcNow;
                _context.SeabattleGames.Attach(newGameStateIntoDto);
                _context.Entry(newGameStateIntoDto).Property(r => r.IdSession).IsModified = true;
                _context.SaveChanges();
                //учитывать если игра даст что она закнчилась надо сохранить конец игры
                return;
            }
        }




        public ShootModel GetLastShootModelOrNullByName(string namePlayer)
        {
            throw new NotImplementedException();
        }

        public void ResaveValidShoot(ShootModel shootModel)
        {
            throw new NotImplementedException();
        }
    }
}
