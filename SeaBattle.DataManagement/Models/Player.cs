using System;
using System.Collections.Generic;

namespace SeaBattle.DataManagement.Models;

public partial class Player
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AppLog> AppLogs { get; } = new List<AppLog>();

    public virtual ICollection<SeabattleGame> SeabattleGameIdPlayerTurnNavigations { get; } = new List<SeabattleGame>();

    public virtual ICollection<SeabattleGame> SeabattleGameIdPlayerWinNavigations { get; } = new List<SeabattleGame>();

    public virtual ICollection<Session> SessionIdPlayerHostNavigations { get; } = new List<Session>();

    public virtual ICollection<Session> SessionIdPlayerJoinNavigations { get; } = new List<Session>();

    public virtual ICollection<Shoot> Shoots { get; } = new List<Shoot>();
}
