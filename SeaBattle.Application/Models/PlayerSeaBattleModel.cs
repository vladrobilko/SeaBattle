using SeaBattle;
using SeaBattle.Application.Services;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattleApi.Models
{
    public class PlayerSeaBattleStateModel : IPlayer
    {
        public string NamePlayer { get; set; }

        private IFillerShips _filler;

        public PlayArea PlayArea { get; set; }

        public List<Ship> Ships { get; set; }

        public PlayArea EnemyPlayArea { get; set; }

        private ISeaBattleGameRepository _seaBattleGameRepository;

        public PlayerSeaBattleStateModel(ISeaBattleGameRepository seaBattleGameService, IFillerShips filler, string name)
        {
            PlayArea = new PlayArea();
            _filler = filler;
            EnemyPlayArea = new PlayArea();
            Ships = ShipsCreator.CreatShips();
            NamePlayer = name;
            _seaBattleGameRepository = seaBattleGameService;
        }

        public PlayerSeaBattleStateModel(ISeaBattleGameRepository seaBattleGameService)
        {
            _seaBattleGameRepository = seaBattleGameService;
        }

        public void FillShips()
        {
            _filler.FillShips(PlayArea?.Cells, Ships);
        }

        public PlayArea GetPlayArea()
        {
            return new PlayArea(PlayArea);
        }

        public Point GetNextValidShootTarget()
        {
            var shoot = _seaBattleGameRepository.GetLastShootModelOrNullByName(NamePlayer) ?? throw new NullReferenceException();
            if (EnemyPlayArea.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State == CellState.HasShooted)
                throw new NotFiniteNumberException();
            EnemyPlayArea.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State = CellState.HasShooted;
            return new Point(shoot.ShootCoordinateY, shoot.ShootCoordinateX);
        }

        public ShootResultType OnShoot(Point target)
        {
            var shootResultType = Shooter.Result(Ships, target);
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
