using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithHangfireExample
{
    public class SingletonService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SingletonService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        internal void Invoke()
        {
            var scopedService = _httpContextAccessor.HttpContext.RequestServices.GetService<ScopedService>();
        }
    }
}
