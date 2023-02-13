using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattle.Application.Models
{
    public class PlayerSeaBattleStateModel : IPlayer
    {
        public string? NamePlayer { get; set; }

        private readonly IFillerShips? _filler;

        public PlayArea? PlayArea { get; set; }

        public List<Ship>? Ships { get; set; }

        public PlayArea? EnemyPlayArea { get; set; }

        private readonly ISeaBattleGameRepository? _seaBattleGameRepository;

        public PlayerSeaBattleStateModel(ISeaBattleGameRepository battleGameRepository, IFillerShips? filler, string? name)
        {
            PlayArea = new PlayArea();
            _filler = filler;
            EnemyPlayArea = new PlayArea();
            Ships = ShipsCreator.CreateShipsForDefaultGame();
            NamePlayer = name;
            _seaBattleGameRepository = battleGameRepository;
        }

        public PlayerSeaBattleStateModel(ISeaBattleGameRepository seaBattleGameService)
        {
            _seaBattleGameRepository = seaBattleGameService;
        }

        public void FillShips()
        {
            _filler?.FillShips(PlayArea?.Cells, Ships);
        }

        public PlayArea GetPlayArea()
        {
            return new PlayArea(PlayArea);
        }

        public Point GetNextValidShootTarget()
        {
            var shoot = _seaBattleGameRepository.ReadLastShootModelByName(NamePlayer) ?? throw new NullReferenceException();
            if (EnemyPlayArea?.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State == CellState.HasShot)
                throw new NotFiniteNumberException();
            EnemyPlayArea!.Cells[shoot.ShootCoordinateY, shoot.ShootCoordinateX].State = CellState.HasShot;
            return new Point(shoot.ShootCoordinateY, shoot.ShootCoordinateX);
        }

        public ShootResultType OnShoot(Point target)
        {
            var shootResultType = Shooter.Result(Ships, target);
            PlayArea!.Cells[target.Y, target.X].State = CellState.HasShot;
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
