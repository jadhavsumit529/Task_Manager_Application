using System;
using System.Collections.Generic;

namespace mynewproject.Models;

public partial class Project
{
    public int Pid { get; set; }

    public string? Name { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime Deadline { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Pte> Ptes { get; set; } = new List<Pte>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
