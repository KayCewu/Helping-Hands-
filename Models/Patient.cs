using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string Surname { get; set; } = null!;

    public string PatientName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Idno { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string ResAddress { get; set; } = null!;

    public string? ChronicCondition { get; set; }

    public string EmergencyContact { get; set; } = null!;

    public string EmergencyNumber { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public virtual ICollection<CareContract> CareContracts { get; set; } = new List<CareContract>();
}
