using System;
using System.Collections.Generic;

namespace mynewproject.Models;

public partial class Employee
{
    public int Empid { get; set; }

    public string? Name { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public long? Phone { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<Pte> Ptes { get; set; } = new List<Pte>();

    public static implicit operator Employee(string v)
    {
        throw new NotImplementedException();
    }
}
