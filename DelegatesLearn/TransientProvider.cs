using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeOfDI
{
    // Transient: har bar naya object return karta hai
    class TransientProvider
    {
        public SampleService GetSample() => new SampleService();
    }
}
