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
    public class DemoZController : ControllerBase
    {
        private readonly ILogger _logger;

        //預設已經將ILogger 放進DI容器中了
        public DemoZController(ILogger<DemoZController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
             
            //不建議寫法:參數與字串混再一起
            _logger.LogTrace($"【Trace message,Lavel=0】");
            _logger.LogDebug($"【Debug message,Lavel=1】");
            _logger.LogInformation($"【Information message,Lavel=2】");
            _logger.LogWarning($"【Warning message,Lavel=3】");
            _logger.LogError($"【Error message,Lavel=4】");
            _logger.LogCritical($"【Critical message,Lavel=5】");
            return new string[] { "value1", "value2" };
        }
    }
}