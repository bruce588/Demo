using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace serilog_demo.Controlls
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
            //不建議寫法:參數與字串混再一起
            _logger.LogTrace($"【Trace message,Lavel=0】");
            _logger.LogDebug($"【Debug message,Lavel=1】");
            _logger.LogInformation($"【Information message,Lavel=2】");
            _logger.LogWarning($"【Warning message,Lavel=3】");
            _logger.LogError($"【Error message,Lavel=4】");
            _logger.LogCritical($"【Critical message,Lavel=5】");
            return new string[] { "value1", "value2" };
        }

        // GET: api/Demo/1
        [HttpGet("{logLevel:int}")]
        public IEnumerable<string> Get(int logLevel)
        {
            string logType = "";
            switch (logLevel)
            {
                case 0:
                    logType = "Trace";
                    _logger.LogTrace("【{logType} message,Lavel={logLevel}】", logType, logLevel);
                    break;
                case 1:
                    logType = "Debug";
                    _logger.LogDebug("【{logType} message,Lavel={logLevel}】", logType, logLevel);
                    break;
                case 2:
                    logType = "Information";
                    _logger.LogInformation("【{logType} message,Lavel={logLevel}】", logType, logLevel);
                    break;
                case 3:
                    logType = "Warning";
                    _logger.LogWarning("【{logType} message,Lavel={logLevel}】", logType, logLevel);
                    break;
                case 4:
                    logType = "Error";
                    _logger.LogError("【{logType} message,Lavel={logLevel}】", logType, logLevel);
                    break;
                case 5:
                    logType = "Critical";
                    _logger.LogCritical("【{logType} message,Lavel={logLevel}】", logType, logLevel);
                    break;

            }

            return new string[] { "value1", "value2" };
        }

 

        // POST: api/Demo
        [HttpGet("divided/{num1}/{num2}")]
        public ActionResult<string> divided(int num1,int num2)
        {
            
            try {
                _logger.LogDebug("開始計算{num1}/{num2}", num1, num2);
                int ans = num1 / num2;
                _logger.LogDebug("計算結果{num1}/{num2}={ans}", num1, num2,ans);
                return Content(ans.ToString());
            }
            catch(Exception ex)
            {
                string errorMessage = ex.Message;
                string stackTrace = ex.StackTrace;
                 _logger.LogError("計算{num1}/{num2}結果有錯,原因=[{errorMessage}],StackTrace=[stackTrace]", num1, num2, errorMessage, stackTrace);
            }

            return this.BadRequest();
        }

        // DELETE: api/Demo/5
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {

            if (id < 10)
            {
                _logger.LogInformation("【Delete OK,id={id}】", id);
            }
            else
            {
                _logger.LogError("【Delete Error (id={id})】", id);
            }
        }
    }
}
