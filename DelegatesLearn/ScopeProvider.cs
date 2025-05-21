using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeOfDI
{
    // Scoped: ek hi scope mein ek hi object return karta hai
    class ScopeProvider
    {
        private readonly SampleService _instance;

        public ScopeProvider()
        {
            _instance = new SampleService(); // scope ke dauran same object rahega
        }

        public SampleService GetSample() => _instance;
    }
}
