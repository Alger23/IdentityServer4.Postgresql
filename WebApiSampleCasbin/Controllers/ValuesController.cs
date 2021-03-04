using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSampleCasbin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "1", "1" };
        }

        [Authorize("read")]
        [HttpGet("read")]
        public IEnumerable<string> GetRead()
        {
            return new[] { "read", "read" };
        }

        [Authorize("manage")]
        [HttpGet("manage")]
        public IEnumerable<string> GetManage()
        {
            return new[] { "manage1", "manage2" };
        }
    }
}
