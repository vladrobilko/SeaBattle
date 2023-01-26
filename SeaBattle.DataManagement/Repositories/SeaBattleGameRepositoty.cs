using SeaBattle.Application.Converters;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Converters;
using SeaBattle.DataManagement.Models;
using SeaBattleApi.Models;

namespace SeaBattle.DataManagement.Repositories
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        private readonly SeabattleContext _context;

        public SeaBattleGameRepositoty(SeabattleContext context)
        {
            _context = context;
        }

        public void SaveOrResavePlayerStateModel(IPlayer playerModel)
        {
            var player = GetPlayerFromDbByName(playerModel.NamePlayer);
            var textModel = playerModel.GetPlayArea().ConvertToString();
            var playAreaInDb = GetPlayAreaFromDbByIdPlayerOrNull(player.Id);

            var ships = playerModel.Ships;

            if (playAreaInDb != null)
            {
                ChangePlayerStateModelInDb(playAreaInDb, ships, textModel);
            }

            else
            {
                CreatePlayerStateModelInDb(ships, player.Id, textModel);
            }
        }

        private void ChangePlayerStateModelInDb(PlayareaDto playAreaInDb, List<Ship> shipsFromDomain, string gameModel)
        {
            playAreaInDb.Playarea1 = gameModel;
            _context.Playareas.Attach(playAreaInDb);
            _context.Entry(playAreaInDb).Property(r => r.Playarea1).IsModified = true;
            _context.SaveChanges();

            var listShipsInDto = _context.Ships.Where(p => p.IdPlayarea == playAreaInDb.Id);

            foreach (var ship in listShipsInDto)
            {
                _context.Ships.Remove(ship);
            }
            _context.SaveChanges();

            foreach (var ship in shipsFromDomain)
            {
                AddShipsInDb(ship, null, playAreaInDb.Id);
            }
        }

        private void CreatePlayerStateModelInDb(List<Ship> ships, long idPlayer, string playArea)
        {
            var newPlayArea = new PlayareaDto() { IdPlayer = idPlayer, Playarea1 = playArea };
            _context.Playareas.Add(newPlayArea);
            _context.SaveChanges();

            foreach (var ship in ships)
            {
                AddShipsInDb(ship, idPlayer, null);
            }
        }

        private void AddShipsInDb(Ship ship, long? idPlayer = null, long? idPlaeArea = null)
        {
            var idPlayAreaForPlayer = idPlaeArea ?? _context.Playareas.First(p => p.IdPlayer == idPlayer).Id;
            var shipDto = new ShipDto();
            shipDto.IdPlayarea = idPlayAreaForPlayer;
            shipDto.Length = ship.Length;
            shipDto.DecksJson = ship._decks.ConvertToJson();
            _context.Ships.Add(shipDto);
            _context.SaveChanges();
        }

        public PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByNameOrNull(string name)
        {
            var player = GetPlayerFromDbByName(name);
            var session = GetSessionFromDbById(player.Id);
            var playAreaModel = GetPlayAreaFromDbByIdPlayerOrNull(player.Id);

            if (playAreaModel.ConfirmedPlayarea == null)
            {
                return null;
            }

            var playarea = GetPlayAreaFromDbByIdPlayerOrNull(player.Id).Playarea1.ConvertToPlayArea();
            var enemyPlayArea = GetPlayAreaFromDbByIdPlayerOrNull(session.IdPlayerJoin).Playarea1.ConvertToPlayArea();

            if (playarea == null)
            {
                return null;
            }

            var playerStateModel = new PlayerSeaBattleStateModel(new SeaBattleGameRepositoty(_context));
            playerStateModel.NamePlayer = name;
            playerStateModel.PlayArea = playarea;
            playerStateModel.Ships = GetShipsFromDbByPlayareaId(playAreaModel.Id).ConvertToListShip();
            playerStateModel.PlayAreaEnemyForInformation = enemyPlayArea;

            return playerStateModel;
        }

        public GameState GetGameStateModelByNameSession(string nameSession)
        {
            Task.Delay(1000).Wait();

            var session = GetSessionFromDbByName(nameSession);
            var gameStateDto = GetSeaBatllegameFromDbByIdSessionOrNull(session.Id);
            var playerHost = GetPlayerFromDbById(session.IdPlayerHost);
            var playerJoin = GetPlayerFromDbById(session.IdPlayerJoin);
            var playerHostModel = GetConfirmedPlayerStateModelByNameOrNull(playerHost.Name);
            var playerJoinModel = GetConfirmedPlayerStateModelByNameOrNull(playerJoin.Name);
            var namePlayerTurn = GetPlayerFromDbById(gameStateDto.IdPlayerTurn).Name;

            var gameMessage = gameStateDto.GameMessage;

            var gameOn = gameStateDto.EndGame == null;

            return new GameState(playerHostModel, playerJoinModel, namePlayerTurn, gameOn, gameMessage);
        }

        public void ReadyToStartGame(string namePlayer)
        {
            var player = GetPlayerFromDbByName(namePlayer);
            var playAreaInDb = GetPlayAreaFromDbByIdPlayerOrNull(player.Id);

            playAreaInDb.ConfirmedPlayarea = DateTime.UtcNow;

            _context.Playareas.Attach(playAreaInDb);
            _context.Entry(playAreaInDb).Property(r => r.ConfirmedPlayarea).IsModified = true;
            _context.SaveChanges();
        }

        public void ResaveGameStateModel(GameState gameStateModel, string NameSession)
        {
            var playerTurn = GetPlayerFromDbByName(gameStateModel.NamePlayerTurn);
            var session = GetSessionFromDbByName(NameSession);
            var lastGameStateFromDto = GetSeaBatllegameFromDbByIdSessionOrNull(session.Id);

            var gameMessage = gameStateModel.GameMessage;

            if (lastGameStateFromDto == null)
            {
                CreateSeabattleGameInDb(playerTurn.Id, session.Id, gameMessage);
            }

            else if (lastGameStateFromDto != null && gameStateModel.IsGameOn)
            {
                SaveOrResavePlayerStateModel(gameStateModel.Player1);
                SaveOrResavePlayerStateModel(gameStateModel.Player2);
                ChangeSeabattleGameInDb(lastGameStateFromDto, playerTurn.Id, gameMessage);
            }

            else if (lastGameStateFromDto != null && !gameStateModel.IsGameOn)
            {
                SaveOrResavePlayerStateModel(gameStateModel.Player1);
                SaveOrResavePlayerStateModel(gameStateModel.Player2);
                EndSeabattleGameInDb(lastGameStateFromDto, gameMessage);
            }
        }

        private void ChangeSeabattleGameInDb(SeabattleGameDto lastGameStateFromDto, long playerTurnId, string gameMessage)
        {
            lastGameStateFromDto.IdPlayerTurn = playerTurnId;
            lastGameStateFromDto.GameMessage = gameMessage;
            _context.SeabattleGames.Attach(lastGameStateFromDto);
            _context.Entry(lastGameStateFromDto).Property(r => r.IdPlayerTurn).IsModified = true;
            _context.Entry(lastGameStateFromDto).Property(r => r.GameMessage).IsModified = true;
            _context.SaveChanges();
        }

        private void CreateSeabattleGameInDb(long playerTurnId, long sessionId, string gameMessage)
        {
            var newGameStateIntoDto = new SeabattleGameDto();
            newGameStateIntoDto.IdPlayerTurn = playerTurnId;
            newGameStateIntoDto.IdSession = sessionId;
            newGameStateIntoDto.GameMessage = gameMessage;
            newGameStateIntoDto.StartGame = DateTime.UtcNow;
            _context.SeabattleGames.Add(newGameStateIntoDto);
            _context.SaveChanges();
        }

        private void EndSeabattleGameInDb(SeabattleGameDto lastGameStateFromDto, string gameMessage)
        {
            lastGameStateFromDto.IdPlayerTurn = null;
            lastGameStateFromDto.GameMessage = gameMessage;
            lastGameStateFromDto.EndGame = DateTime.UtcNow;
            _context.SeabattleGames.Attach(lastGameStateFromDto);
            _context.Entry(lastGameStateFromDto).Property(r => r.IdPlayerTurn).IsModified = true;
            _context.Entry(lastGameStateFromDto).Property(r => r.GameMessage).IsModified = true;
            _context.Entry(lastGameStateFromDto).Property(r => r.EndGame).IsModified = true;
            _context.SaveChanges();
        }

        public void ResaveValidShoot(ShootModel shootModel)
        {
            var session = GetSessionFromDbByName(shootModel.NameSession);
            var gameStateDto = GetSeaBatllegameFromDbByIdSessionOrNull(session.Id);
            var player = GetPlayerFromDbByName(shootModel.NamePlayer);

            var shootInDb = _context.Shoots.FirstOrDefault(p => p.IdSeabattleGame == gameStateDto.Id);

            if (shootInDb == null && gameStateDto.IdPlayerTurn == player.Id)
            {
                CreateShootInDb(player.Id, gameStateDto.Id, shootModel.ShootCoordinateY, shootModel.ShootCoordinateX);
            }

            else if (shootInDb != null && gameStateDto.IdPlayerTurn == player.Id)
            {
                ChangeShootInDb(shootInDb, player.Id, shootModel.ShootCoordinateY, shootModel.ShootCoordinateX);
            }
        }

        private void CreateShootInDb(long playerId, long gameId, long coordinateY, long coordinateX)
        {
            var shootIntoDto = new ShootDto();
            shootIntoDto.IdPlayerShoot = playerId;
            shootIntoDto.IdSeabattleGame = gameId;
            shootIntoDto.ShootCoordinateY = coordinateY;
            shootIntoDto.ShootCoordinateX = coordinateX;
            shootIntoDto.TimeShoot = DateTime.UtcNow;
            _context.Shoots.Add(shootIntoDto);
            _context.SaveChanges();
        }

        private void ChangeShootInDb(ShootDto shootInDb, long playerId, long coordinateY, long coordinateX)
        {
            shootInDb.IdPlayerShoot = playerId;
            shootInDb.ShootCoordinateY = coordinateY;
            shootInDb.ShootCoordinateX = coordinateX;
            shootInDb.TimeShoot = DateTime.UtcNow;
            _context.Shoots.Attach(shootInDb);
            _context.Entry(shootInDb).Property(r => r.IdPlayerShoot).IsModified = true;
            _context.Entry(shootInDb).Property(r => r.ShootCoordinateY).IsModified = true;
            _context.Entry(shootInDb).Property(r => r.ShootCoordinateX).IsModified = true;
            _context.Entry(shootInDb).Property(r => r.TimeShoot).IsModified = true;
            _context.SaveChanges();
        }

        public ShootModel GetLastShootModelOrNullByName(string namePlayer)
        {
            var player = GetPlayerFromDbByName(namePlayer);
            var session = GetSessionFromDbById(player.Id);
            var gameDb = GetSeaBatllegameFromDbByIdSessionOrNull(session.Id);

            var shootDb = _context.Shoots.FirstOrDefault(p => p.IdSeabattleGame == gameDb.Id)
                ?? throw new NotImplementedException();

            var playerShoot = GetPlayerFromDbById(shootDb.IdPlayerShoot);

            return new ShootModel(
                Convert.ToInt32(shootDb.ShootCoordinateY),
                Convert.ToInt32(shootDb.ShootCoordinateX),
                playerShoot.Name,
                session.Name);
        }

        private List<ShipDto> GetShipsFromDbByPlayareaId(long idPlayarea)
        {
            return _context.Ships.Where(p => p.IdPlayarea == idPlayarea).ToList();
        }

        private PlayerDto GetPlayerFromDbByName(string namePlayer)
        {
            return _context.Players.FirstOrDefault(p => p.Name == namePlayer)
                ?? throw new NotImplementedException();
        }

        private PlayerDto GetPlayerFromDbById(long? idPlayer)
        {
            return _context.Players.FirstOrDefault(p => p.Id == idPlayer)
                ?? throw new NotImplementedException();
        }

        private SessionDto GetSessionFromDbByName(string nameSession)
        {
            return _context.Sessions.FirstOrDefault(p => p.Name == nameSession)
                ?? throw new NotImplementedException();
        }

        private SessionDto GetSessionFromDbById(long playerId)
        {
            return _context.Sessions.FirstOrDefault(p => p.IdPlayerHost == playerId || p.IdPlayerJoin == playerId)
                ?? throw new NotImplementedException();
        }

        private PlayareaDto GetPlayAreaFromDbByIdPlayerOrNull(long? id)
        {
            return _context.Playareas.FirstOrDefault(p => p.IdPlayer == id);
        }

        private SeabattleGameDto GetSeaBatllegameFromDbByIdSessionOrNull(long id)
        {
            return _context.SeabattleGames.FirstOrDefault(p => p.IdSession == id);
        }
    }
}
