using System;
using System.Collections.Generic;

namespace SeaBattle.DataManagement.Models;

public partial class SeabattleGame
{
    public long Id { get; set; }

    public long? IdPlayerTurn { get; set; }

    public long? IdPlayerWin { get; set; }

    public long IdSession { get; set; }

    public string GameMessage { get; set; } = null!;

    public DateTime? StartGame { get; set; }

    public DateTime? EndGame { get; set; }

    public virtual Player? IdPlayerTurnNavigation { get; set; }

    public virtual Player? IdPlayerWinNavigation { get; set; }

    public virtual Session IdSessionNavigation { get; set; } = null!;

    public virtual Shoot? Shoot { get; set; }
}
