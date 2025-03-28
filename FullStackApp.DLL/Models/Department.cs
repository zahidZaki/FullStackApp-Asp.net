using System;
using System.Collections.Generic;

namespace FullStackApp.DLL.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? BlockNo { get; set; }

    public string? RoomNo { get; set; }
}
