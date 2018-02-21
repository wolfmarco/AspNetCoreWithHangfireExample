using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithHangfireExample
{
    public class TransientService
    {
        private readonly ScopedService _scopedService;

        public TransientService(ScopedService scopedService)
        {
            _scopedService = scopedService;
        }

        internal void Invoke()
        {
        }
    }
}
