using SeaBattle;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattleApi.Models
{
    public class PlayerSeaBattleStateModel : IPlayer
    {
        public string NamePlayer { get; set; }

        private IFillerShips _filler;

        public PlayArea PlayArea { get; set; }

        List<Ship> _ships;

        public PlayArea PlayAreaEnemyForInformation { get; set; }

        ISeaBattleGameRepository _seaBattleGameRepository;

        public PlayerSeaBattleStateModel(IFillerShips filler, string name, ISeaBattleGameRepository seaBattleGameService)
        {
            PlayArea = new PlayArea();
            _filler = filler;
            PlayAreaEnemyForInformation = new PlayArea();
            _ships = ShipsCreator.CreatShips(new List<ShipConfige>()
            { new ShipConfige(1,4), new ShipConfige(2, 3), new ShipConfige(3, 2), new ShipConfige(4, 1) });
            NamePlayer = name;
            _seaBattleGameRepository = seaBattleGameService;
        }

        public PlayerSeaBattleStateModel()
        {

        }

        public void FillShips()
        {
            _filler.FillShips(PlayArea?.Cells, _ships);
        }

        public PlayArea GetPlayArea()
        {
            return new PlayArea(PlayArea);
        }

        public Point GetNextValidShootTarget()
        {
            var shoot = _seaBattleGameRepository.GetLastShootModelOrNullByName(NamePlayer) ?? throw new NullReferenceException();
            if (PlayAreaEnemyForInformation.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State == CellState.HasShooted)
                throw new NotFiniteNumberException();
            PlayAreaEnemyForInformation.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State = CellState.HasShooted;
            return new Point(shoot.ShootCoordinateY, shoot.ShootCoordinateX);
        }

        public ShootResultType OnShoot(Point target)
        {
            var shootResultType = Shooter.Result(_ships, target);
            PlayArea.Cells[target.Y, target.X].State = CellState.HasShooted;
            if (shootResultType == ShootResultType.Miss)
            {
                PlayArea.Cells[target.Y, target.X].State = CellState.HasMiss;
            }
            else if (shootResultType == ShootResultType.Hit || shootResultType == ShootResultType.Kill)
            {
                PlayArea.Cells[target.Y, target.X].State = CellState.HasHit;
            }
            return shootResultType;
        }
    }
}
