using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class ChronicCondition
{
    public int ChronicId { get; set; }

    public string ConditionName { get; set; } = null!;

    public string? ConditionDescription { get; set; }
}
