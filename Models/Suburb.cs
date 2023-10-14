using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class Suburb
{
    public int SuburbId { get; set; }

    public string SuburbName { get; set; } = null!;

    public string? PostalCode { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<PreferredSuburb> PreferredSuburbs { get; set; } = new List<PreferredSuburb>();
}
