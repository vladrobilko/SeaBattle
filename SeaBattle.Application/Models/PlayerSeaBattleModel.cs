using SeaBattle;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattleApi.Models
{
    public class PlayerSeaBattleStateModel : IPlayer
    {
        public string NamePlayer { get; private set; }

        private IFillerShips _filler;

        PlayArea _playArea;

        List<Ship> _ships;

        PlayArea _playAreaEnemyForInformation;

        ISeaBattleGameRepository _seaBattleGameRepository;

        public PlayerSeaBattleStateModel(IFillerShips filler, string name, ISeaBattleGameRepository seaBattleGameService)
        {
            _playArea = new PlayArea();
            _filler = filler;
            _playAreaEnemyForInformation = new PlayArea();
            _ships = ShipsCreator.CreatShips(new List<ShipConfige>()
            { new ShipConfige(1,4), new ShipConfige(2, 3), new ShipConfige(3, 2), new ShipConfige(4, 1) });
            NamePlayer = name;
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

        public Point GetNextValidShootTarget()
        {
            var shoot = _seaBattleGameRepository.GetLastShootModelOrNullByName(NamePlayer) ?? throw new NullReferenceException();
            if (_playAreaEnemyForInformation.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State == CellState.HasShooted)
                throw new NotFiniteNumberException();
            _playAreaEnemyForInformation.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State = CellState.HasShooted;
            return new Point(shoot.ShootCoordinateY, shoot.ShootCoordinateX);
        }

        public ShootResultType OnShoot(Point target)
        {
            var shootResultType = Shooter.Result(_ships, target);
            _playArea.Cells[target.Y, target.X].State = CellState.HasShooted;
            if (shootResultType == ShootResultType.Miss)
            {
                _playArea.Cells[target.Y, target.X].State = CellState.HasMiss;
            }
            else if (shootResultType == ShootResultType.Hit || shootResultType == ShootResultType.Kill)
            {
                _playArea.Cells[target.Y, target.X].State = CellState.HasHit;
            }
            return shootResultType;
        }
    }
}
