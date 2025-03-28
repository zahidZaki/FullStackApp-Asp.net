using System;
using System.Collections.Generic;

namespace FullStackApp.DLL.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly HireDate { get; set; }
}
