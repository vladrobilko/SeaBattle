using System;
using System.Collections.Generic;

namespace SeaBattle.DataManagement.Models;

public partial class Playarea
{
    public long Id { get; set; }

    public long IdPlayer { get; set; }

    public string? Playarea1 { get; set; }

    public DateTime? ConfirmedPlayarea { get; set; }

    public virtual ICollection<Ship> Ships { get; } = new List<Ship>();
}
