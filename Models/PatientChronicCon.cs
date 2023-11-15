using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class PatientChronicCon
{
    public string Id { get; set; } = null!;

    public int UserId { get; set; }

    public string ChronicCondition { get; set; } = null!;
}
