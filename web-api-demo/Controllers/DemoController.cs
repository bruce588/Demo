using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using web_api_demo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_demo.Controllers
{
    [Route("api/[controller]")]
    public class DemoController : Controller
    {
        private readonly IWebHostEnvironment _host;
        public DemoController(IWebHostEnvironment hostingEnvironment    )
        {

            // ASP.NET Core 大量拋棄靜態方法降低依賴，所以沒有 Server.MapPath() 方法可用了
            //在 ASP.NET Core 要取得網站根目錄的話，需要注入 IHostingEnvironment
            _host = hostingEnvironment;

        }

        // GET: api/<controller>
        [HttpGet("{youername}")]
        public ActionResult<string> Hello(string youername)
        {
            return $"hello {youername}";
        } 

        [HttpGet("GetResult/{id:int}")]
        public IActionResult LogicCheck(int id)
        {

           switch(id)
            { 
                case 1:/*HTTP200:作業正常,前端回報OK  */ return Ok() ;
                case 2:/*HTTP200:回傳字串 */return Content(_host.WebRootPath);
                case 3:/*HTTP200:下載檔案*/return PhysicalFile(_host.WebRootPath+ "/FordGT.jpg", "image/jpg");
                case 4:/*HTTP202:伺服器已接受請求，但尚未處理*/return Accepted();
                case 5:/*HTTP204:沒有內容 204*/return  NoContent();
                case 6:/*找不到*/return NotFound(); 
            }
             
           return NoContent();
        }

        [HttpGet("GetResult2/{id:length(6)}")]
        public IActionResult LogicCheck2(int id)
        {

            return Content($"你輸入的是［{id}］");
        }

        [HttpGet("customers/{customerId}/Blogs")]
        public ActionResult<List<Blog>> FindOrdersByCustomer(int customerId) {

             if(customerId<10)
            {
                List<Blog> blogs = new List<Blog>();
                blogs.Add(new Blog() { BlogId = 1, Url = "http://localhost/1" });
                blogs.Add(new Blog() { BlogId = 2, Url = "http://localhost/2" });

                return blogs;
            } 

            return NotFound();
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
