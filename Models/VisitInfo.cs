using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helping_Hands_2._0.Models;

public partial class VisitInfo
{ 
    public int VisitId { get; set; }

    public int ContractNo { get; set; }

    public DateTime VisitDate { get; set; }

    public string ApproxArrivalTime { get; set; } = null!;

    public string? VisitArrivalTime { get; set; }

    public string? VisitDepartTime { get; set; }

    public string? WoundProgress { get; set; }

    public string? Notes { get; set; }

    public virtual CareContract? ContractNoNavigation { get; set; }
    [NotMapped]
    public string PatientName { get; set; }
    [NotMapped]
    public string PatienSurname{ get; set; }
    [NotMapped]
    public string CellPhoneNumber { get; set; }
}
