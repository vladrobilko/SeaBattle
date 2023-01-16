using System;
using System.Collections.Generic;

namespace SeaBattle.DataManagement.Models;

public partial class Shoot
{
    public long Id { get; set; }

    public long IdSeabattleGame { get; set; }

    public long IdPlayerShoot { get; set; }

    public long ShootCoordinateY { get; set; }

    public long ShootCoordinateX { get; set; }

    public DateTime TimeShoot { get; set; }

    public virtual Player IdPlayerShootNavigation { get; set; } = null!;

    public virtual SeabattleGame IdSeabattleGameNavigation { get; set; } = null!;
}
