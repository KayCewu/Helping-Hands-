using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class CareContract
{
    public int CareContractId { get; set; }

    public DateTime ContractDate { get; set; }

    public string? ContractStatus { get; set; }

    public string ContractAddress { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int? AssignedNurse { get; set; }

    public int PatientNo { get; set; }

    public string WoundDescription { get; set; } = null!;

    public virtual Patient PatientNoNavigation { get; set; } = null!;

    public virtual ICollection<VisitInfo> VisitInfos { get; set; } = new List<VisitInfo>();
}
