using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityAbbrev { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public virtual ICollection<Suburb> Suburbs { get; set; } = new List<Suburb>();
}
