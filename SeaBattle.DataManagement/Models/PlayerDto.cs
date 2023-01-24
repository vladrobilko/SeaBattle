using System;
using System.Collections.Generic;

namespace SeaBattle.DataManagement.Models;

public partial class PlayerDto
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AppLog> AppLogs { get; } = new List<AppLog>();

    public virtual ICollection<SeabattleGameDto> SeabattleGameIdPlayerTurnNavigations { get; } = new List<SeabattleGameDto>();

    public virtual ICollection<SeabattleGameDto> SeabattleGameIdPlayerWinNavigations { get; } = new List<SeabattleGameDto>();

    public virtual ICollection<SessionDto> SessionIdPlayerHostNavigations { get; } = new List<SessionDto>();

    public virtual ICollection<SessionDto> SessionIdPlayerJoinNavigations { get; } = new List<SessionDto>();

    public virtual ICollection<ShootDto> Shoots { get; } = new List<ShootDto>();
}
