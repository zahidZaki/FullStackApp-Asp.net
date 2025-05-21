using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeOfDI
{
    // Sample service with a unique ID
    class SampleService
    {
        public Guid ID { get; } = Guid.NewGuid();
    }
}
