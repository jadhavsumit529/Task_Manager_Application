using System;
using System.Collections.Generic;

namespace mynewproject.Models;

public partial class Task
{
    public int Tid { get; set; }

    public int Pid { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string? Description { get; set; }

    public string? Priority { get; set; }

    public DateTime Deadline { get; set; }

    public int Progress { get; set; }

    public string Status { get; set; } = null!;

    public string? Comment { get; set; }

    public virtual Project PidNavigation { get; set; } = null!;

    public virtual ICollection<Pte> Ptes { get; set; } = new List<Pte>();
}
