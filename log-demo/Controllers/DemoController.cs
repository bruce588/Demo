using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace log_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger _logger;

        //預設已經將ILogger 放進DI容器中了
        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }
        // GET: api/Demo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string route = this.RouteData.Routers.ToString();
            _logger.LogTrace($"【Trace message】");
            _logger.LogDebug($"【Debug message】");
            _logger.LogInformation($"【Information message】");
            _logger.LogWarning($"【Warning message】");
            _logger.LogError($"【Error message】");
            _logger.LogCritical($"【Critical message】");
            return new string[] { "value1", "value2" };
        }

        // GET: api/Demo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Demo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Demo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
