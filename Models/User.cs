using System;
using System.Collections.Generic;

namespace Helping_Hands_2._0.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ContactNo { get; set; }

    public string UserType { get; set; } = null!;

    public string? IsActive { get; set; }
}
