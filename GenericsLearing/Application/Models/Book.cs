﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLearing.Application.Models
{
    internal class Book : Product
    {
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
            

    }
}
