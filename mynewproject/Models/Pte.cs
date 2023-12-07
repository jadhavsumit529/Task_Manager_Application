using System;
using System.Collections.Generic;

namespace mynewproject.Models;

public partial class Pte
{
    public int Id { get; set; }

    public int? Empid { get; set; }

    public int Pid { get; set; }

    public int Tid { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual Project PidNavigation { get; set; } = null!;

    public virtual Task TidNavigation { get; set; } = null!;
}
