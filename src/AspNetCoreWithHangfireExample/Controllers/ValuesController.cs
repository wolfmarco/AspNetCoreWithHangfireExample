using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithHangfireExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly SingletonService _singletonService;
        private readonly ScopedService _scopedService;
        private readonly TransientService _transientService;

        public ValuesController(SingletonService singletonService, ScopedService scopedService, TransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _singletonService.Invoke();
            _singletonService.Invoke();

            _scopedService.Invoke();
            _scopedService.Invoke();

            _transientService.Invoke();
            _transientService.Invoke();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
