using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class PreferredSuburb
{
    public int PrefSubId { get; set; }

    public int? NurseCode { get; set; }

    public int SuburbId { get; set; }

    public virtual Nurse? NurseCodeNavigation { get; set; }

    public virtual Suburb Suburb { get; set; } = null!;
}
