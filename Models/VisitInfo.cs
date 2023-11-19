using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class VisitInfo
{ 
    public int VisitId { get; set; }

    public int? ContractNo { get; set; }

    public DateTime VisitDate { get; set; }

    public string ApproxArrivalTime { get; set; } = null!;

    public string? VisitArrivalTime { get; set; }

    public string? VisitDepartTime { get; set; }

    public string? WoundProgress { get; set; }

    public string? Notes { get; set; }

    public virtual CareContract? ContractNoNavigation { get; set; }
}
