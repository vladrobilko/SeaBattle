using System;
using System.Collections.Generic;

namespace SeaBattle.DataManagement.Models;

public partial class AppLog
{
    public long Id { get; set; }

    public long IdPlayer { get; set; }

    public string Path { get; set; } = null!;

    public string? Error { get; set; }

    public string Information { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual Player IdPlayerNavigation { get; set; } = null!;
}
