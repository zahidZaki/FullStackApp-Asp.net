﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Utils.DTOs
{
    public class TeacherDTO
    {
        public string Name { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public DateOnly HireDate { get; set; }
    }
}
