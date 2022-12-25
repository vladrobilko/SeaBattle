using SeaBattle;
using SeaBattle.Application;
using SeaBattle.Application.Services;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using System.ComponentModel.DataAnnotations;

namespace SeaBattleApi.Models
{
    public class PlayerSeaBattleStateModel : IPlayer
    {
        public string NamePlayer { get; private set; }

        public string NameSession { get; private set; }

        private IFillerShips _filler;

        PlayArea _playArea;

        PlayArea _playAreaEnemyForInformation;

        List<Ship> _ships;

        ISeaBattleGameRepository _seaBattleGameRepository;

        public PlayerSeaBattleStateModel(IFillerShips filler, string name, string sessionName, ISeaBattleGameRepository seaBattleGameService)
        {
            _playArea = new PlayArea();
            _playAreaEnemyForInformation = new PlayArea();
            _filler = filler;
            _ships = ShipsCreator.CreatShips(new List<ShipConfige>()
            { new ShipConfige(1,4), new ShipConfige(2, 3), new ShipConfige(3, 2), new ShipConfige(4, 1) });
            NamePlayer = name;
            NameSession = sessionName;
            _seaBattleGameRepository = seaBattleGameService;
        }

        public void FillShips()
        {
            _filler.FillShips(_playArea?.Cells, _ships);
        }

        public PlayArea GetPlayArea()
        {
            return new PlayArea(_playArea);
        }

        public ShootResultType OnShoot(Point target)
        {
            ShootResultType shootResultType = Shooter.Result(_ships, target);
            _playArea.Cells[target.Y, target.X].State = CellState.HasShooted;
            if (shootResultType == ShootResultType.Miss)
            {
                _playArea.Cells[target.Y, target.X].State = CellState.HasMiss;
                _seaBattleGameRepository.ChangeGameStateModel(
                    nameSession: NameSession, namePlayerTurn: NamePlayer, gameMessage: GameStateMessage.WhoShoot(NamePlayer));
            }
            else if (shootResultType == ShootResultType.Hit || shootResultType == ShootResultType.Kill)
            {
                _playArea.Cells[target.Y, target.X].State = CellState.HasHit;
            }
            return shootResultType;
        }

        public Point GetNextShootTarget()
        {
            var shoot = _seaBattleGameRepository.GetLastShootModelOrNullByNameSession(NameSession);
            throw new NotFiniteNumberException();
            while (shoot == null && shoot?.NamePlayer != NamePlayer)
            {
                Task.Delay(2000).Wait();
                shoot = _seaBattleGameRepository.GetLastShootModelOrNullByNameSession(NameSession);
            }
            while (_playAreaEnemyForInformation.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State == CellState.HasShooted)
            {
                _seaBattleGameRepository.ChangeGameStateModel(nameSession: NameSession,
                    gameMessage: GameStateMessage.WhoShootSameCellAndWhoShoot(NamePlayer));
                Task.Delay(2000).Wait();
                shoot = _seaBattleGameRepository.GetLastShootModelOrNullByNameSession(NameSession);
            }
            _playAreaEnemyForInformation.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State = CellState.HasShooted;
            return new Point(shoot.ShootCoordinateY, shoot.ShootCoordinateX);
        }
    }
}
