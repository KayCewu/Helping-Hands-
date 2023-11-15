using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class Nurse
{
    public int NurseCode { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Idno { get; set; } = null!;

    public int Manager { get; set; }

    public string IsActive { get; set; } = null!;

    public string? Email { get; set; }

    public virtual Manager ManagerNavigation { get; set; } = null!;

    public virtual ICollection<PreferredSuburb> PreferredSuburbs { get; set; } = new List<PreferredSuburb>();
}
