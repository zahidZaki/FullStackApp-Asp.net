using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeOfDI
{
    // Singleton: sab scopes ke liye ek hi shared object
    class SingletonProvider
    {
        private static readonly SampleService _instance = new SampleService(); // static means shared globally

        public SampleService GetSample() => _instance;
    }
}
