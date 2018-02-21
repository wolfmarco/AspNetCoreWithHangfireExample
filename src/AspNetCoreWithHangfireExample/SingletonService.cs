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
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SingletonService(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        internal void Invoke()
        {
            var scopedService = _httpContextAccessor.HttpContext.RequestServices.GetService<ScopedService>();
            var transientService = _httpContextAccessor.HttpContext.RequestServices.GetService<TransientService>();
            transientService.Invoke();
            transientService.Invoke();
        }
    }
}
