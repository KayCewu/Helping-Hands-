using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Email { get; set; }

    public string IsActive { get; set; } = null!;

    public virtual ICollection<Nurse> Nurses { get; set; } = new List<Nurse>();
}
