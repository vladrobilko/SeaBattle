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

        public void CreateOrUpdatePlayerStateModel(IPlayer playerModel)
        {
            var player = ReadPlayerByName(playerModel.NamePlayer);
            var textModel = PlayAreaConverter.ToString(playerModel.GetPlayArea());
            var playAreaInDb = ReadPlayareaByIdPlayer(player.Id);

            var ships = playerModel.Ships;

            if (playAreaInDb != null)
            {
                UpdatePlayerStateModel(playAreaInDb, ships, textModel);
            }

            else
            {
                CreatePlayerStateModel(ships, player.Id, textModel);
            }
        }

        private void UpdatePlayerStateModel(PlayareaDto playAreaInDb, List<Ship> shipsFromDomain, string gameModel)
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
                CreateShips(ship, null, playAreaInDb.Id);
            }
        }

        private void CreatePlayerStateModel(List<Ship> ships, long idPlayer, string playArea)
        {
            var newPlayArea = new PlayareaDto() { IdPlayer = idPlayer, Playarea1 = playArea };
            _context.Playareas.Add(newPlayArea);
            _context.SaveChanges();

            foreach (var ship in ships)
            {
                CreateShips(ship, idPlayer, null);
            }
        }

        private void CreateShips(Ship ship, long? idPlayer = null, long? idPlaeArea = null)
        {
            var idPlayAreaForPlayer = idPlaeArea ?? _context.Playareas.First(p => p.IdPlayer == idPlayer).Id;
            var shipDto = new ShipDto();
            shipDto.IdPlayarea = idPlayAreaForPlayer;
            shipDto.Length = ship.Length;
            shipDto.DecksJson = ship._decks.ToJson();
            _context.Ships.Add(shipDto);
            _context.SaveChanges();
        }

        public PlayerSeaBattleStateModel ReadConfirmedPlayerStateModelByName(string name)
        {
            var player = ReadPlayerByName(name);
            var session = ReadSessionById(player.Id);
            var playAreaModel = ReadPlayareaByIdPlayer(player.Id);

            if (playAreaModel.ConfirmedPlayarea == null)
            {
                return null;
            }

            var playarea = ReadPlayareaByIdPlayer(player.Id).Playarea1.ToPlayArea();
            var enemyPlayArea = ReadPlayareaByIdPlayer(session.IdPlayerJoin).Playarea1.ToPlayArea();

            if (playarea == null)
            {
                return null;
            }

            var playerStateModel = new PlayerSeaBattleStateModel(new SeaBattleGameRepositoty(_context));
            playerStateModel.NamePlayer = name;
            playerStateModel.PlayArea = playarea;
            playerStateModel.Ships = ReadShipsByPlayareaId(playAreaModel.Id).ToShips();
            playerStateModel.EnemyPlayArea = enemyPlayArea;

            return playerStateModel;
        }

        public GameState ReadGameStateModelByNameSession(string nameSession)
        {
            var session = ReadSessionByName(nameSession);
            var gameStateDto = ReadSeaBatllegameByIdSession(session.Id);
            var playerHost = ReadPlayerById(session.IdPlayerHost);
            var playerJoin = ReadPlayerById(session.IdPlayerJoin);
            var playerHostModel = ReadConfirmedPlayerStateModelByName(playerHost.Name);
            var playerJoinModel = ReadConfirmedPlayerStateModelByName(playerJoin.Name);
            var namePlayerTurn = ReadPlayerById(gameStateDto.IdPlayerTurn).Name;

            var gameMessage = gameStateDto.GameMessage;

            var gameOn = gameStateDto.EndGame == null;

            return new GameState(playerHostModel, playerJoinModel, namePlayerTurn, gameOn, gameMessage);
        }

        public void UpdatePlayareaToReadyForGame(string namePlayer)
        {
            var player = ReadPlayerByName(namePlayer);
            var playAreaInDb = ReadPlayareaByIdPlayer(player.Id);

            playAreaInDb.ConfirmedPlayarea = DateTime.UtcNow;

            _context.Playareas.Attach(playAreaInDb);
            _context.Entry(playAreaInDb).Property(r => r.ConfirmedPlayarea).IsModified = true;
            _context.SaveChanges();
        }

        public void UpdateGameStateModel(GameState gameStateModel, string NameSession)
        {
            var playerTurn = ReadPlayerByName(gameStateModel.NamePlayerTurn);
            var session = ReadSessionByName(NameSession);
            var lastGameStateFromDto = ReadSeaBatllegameByIdSession(session.Id);

            var gameMessage = gameStateModel.GameMessage;

            if (lastGameStateFromDto == null)
            {
                CreateSeabattleGame(playerTurn.Id, session.Id, gameMessage);
            }

            else if (lastGameStateFromDto != null && gameStateModel.IsGameOn)
            {
                CreateOrUpdatePlayerStateModel(gameStateModel.Player1);
                CreateOrUpdatePlayerStateModel(gameStateModel.Player2);
                UpdateSeabattleGame(lastGameStateFromDto, playerTurn.Id, gameMessage);
            }

            else if (lastGameStateFromDto != null && !gameStateModel.IsGameOn)
            {
                CreateOrUpdatePlayerStateModel(gameStateModel.Player1);
                CreateOrUpdatePlayerStateModel(gameStateModel.Player2);
                UpdateSeabattleGameForEndGame(lastGameStateFromDto, gameMessage);
            }
        }

        private void UpdateSeabattleGame(SeabattleGameDto lastGameStateFromDto, long playerTurnId, string gameMessage)
        {
            lastGameStateFromDto.IdPlayerTurn = playerTurnId;
            lastGameStateFromDto.GameMessage = gameMessage;
            _context.SeabattleGames.Attach(lastGameStateFromDto);
            _context.Entry(lastGameStateFromDto).Property(r => r.IdPlayerTurn).IsModified = true;
            _context.Entry(lastGameStateFromDto).Property(r => r.GameMessage).IsModified = true;
            _context.SaveChanges();
        }

        private void CreateSeabattleGame(long playerTurnId, long sessionId, string gameMessage)
        {
            var newGameStateIntoDto = new SeabattleGameDto();
            newGameStateIntoDto.IdPlayerTurn = playerTurnId;
            newGameStateIntoDto.IdSession = sessionId;
            newGameStateIntoDto.GameMessage = gameMessage;
            newGameStateIntoDto.StartGame = DateTime.UtcNow;
            _context.SeabattleGames.Add(newGameStateIntoDto);
            _context.SaveChanges();
        }

        private void UpdateSeabattleGameForEndGame(SeabattleGameDto lastGameStateFromDto, string gameMessage)
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

        public void CreateOrUpdateValidShoot(ShootModel shootModel)
        {
            var session = ReadSessionByName(shootModel.NameSession);
            var gameStateDto = ReadSeaBatllegameByIdSession(session.Id);
            var player = ReadPlayerByName(shootModel.NamePlayer);

            var shootInDb = _context.Shoots.FirstOrDefault(p => p.IdSeabattleGame == gameStateDto.Id);

            if (shootInDb == null && gameStateDto.IdPlayerTurn == player.Id)
            {
                CreateShoot(player.Id, gameStateDto.Id, shootModel.ShootCoordinateY, shootModel.ShootCoordinateX);
            }

            else if (shootInDb != null && gameStateDto.IdPlayerTurn == player.Id)
            {
                UpdateShoot(shootInDb, player.Id, shootModel.ShootCoordinateY, shootModel.ShootCoordinateX);
            }
        }

        private void CreateShoot(long playerId, long gameId, long coordinateY, long coordinateX)
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

        private void UpdateShoot(ShootDto shootInDb, long playerId, long coordinateY, long coordinateX)
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

        public ShootModel ReadLastShootModelByName(string namePlayer)
        {
            var player = ReadPlayerByName(namePlayer);
            var session = ReadSessionById(player.Id);
            var gameDb = ReadSeaBatllegameByIdSession(session.Id);

            var shootDb = _context.Shoots.FirstOrDefault(p => p.IdSeabattleGame == gameDb.Id)
                ?? throw new NotImplementedException();

            var playerShoot = ReadPlayerById(shootDb.IdPlayerShoot);

            return new ShootModel(
                Convert.ToInt32(shootDb.ShootCoordinateY),
                Convert.ToInt32(shootDb.ShootCoordinateX),
                playerShoot.Name,
                session.Name);
        }

        private List<ShipDto> ReadShipsByPlayareaId(long idPlayarea)
        {
            return _context.Ships.Where(p => p.IdPlayarea == idPlayarea).ToList();
        }

        private PlayerDto ReadPlayerByName(string namePlayer)
        {
            return _context.Players.FirstOrDefault(p => p.Name == namePlayer)
                ?? throw new NotImplementedException();
        }

        private PlayerDto ReadPlayerById(long? idPlayer)
        {
            return _context.Players.FirstOrDefault(p => p.Id == idPlayer)
                ?? throw new NotImplementedException();
        }

        private SessionDto ReadSessionByName(string nameSession)
        {
            return _context.Sessions.FirstOrDefault(p => p.Name == nameSession)
                ?? throw new NotImplementedException();
        }

        private SessionDto ReadSessionById(long playerId)
        {
            return _context.Sessions.FirstOrDefault(p => p.IdPlayerHost == playerId || p.IdPlayerJoin == playerId)
                ?? throw new NotImplementedException();
        }

        private PlayareaDto ReadPlayareaByIdPlayer(long? id)
        {
            return _context.Playareas.FirstOrDefault(p => p.IdPlayer == id);
        }

        private SeabattleGameDto ReadSeaBatllegameByIdSession(long id)
        {
            return _context.SeabattleGames.FirstOrDefault(p => p.IdSession == id);
        }
    }
}
