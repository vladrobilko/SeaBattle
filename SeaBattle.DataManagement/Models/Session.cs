using System;
using System.Collections.Generic;

namespace SeaBattle.DataManagement.Models;

public partial class Session
{
    public long Id { get; set; }

    public long IdPlayerHost { get; set; }

    public long? IdPlayerJoin { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? StartSession { get; set; }

    public DateTime? EndSession { get; set; }

    public virtual Player IdPlayerHostNavigation { get; set; } = null!;

    public virtual Player? IdPlayerJoinNavigation { get; set; }

    public virtual SeabattleGame? SeabattleGame { get; set; }
}
