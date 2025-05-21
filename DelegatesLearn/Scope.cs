using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeOfDI
{
    // Scope class – per-scope provider holder
    class Scope
    {
        public TransientProvider TransientProvider { get; } = new TransientProvider();
        public ScopeProvider ScopeProvider { get; } = new ScopeProvider();
        public SingletonProvider SingletonProvider { get; } = new SingletonProvider();
    }
}
