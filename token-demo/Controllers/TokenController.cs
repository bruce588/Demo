using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using token_demo.Helper;
using token_demo.Models;

namespace token_demo.Controllers
{

        [Authorize]
        [Route("api/[controller]")]
        [ApiController]
        public class TokenController : ControllerBase
        {
            private JwtHelper _jwtHelper;

            public TokenController(JwtHelper helper)
            {
                _jwtHelper = helper;

            }
            [AllowAnonymous]
            [HttpPost("~/signin")]
            [ProducesDefaultResponseType]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public ActionResult<string> SignIn(LoginViewModel user)
            {
                if (this.ValidateUser(user))
                {
                // 你可以自行擴充 "roles" 加入登入者該有的角色
                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim("roles", "Admin"));
                userClaims.Add(new Claim("roles", "Users"));
                return this._jwtHelper.GenerateToken(user.Username, userClaims,10);

                }
                else
                {
                    return this.BadRequest();
                }


            }

            private bool ValidateUser(LoginViewModel user)
            {
                return true;
            }

            [HttpGet("~/claims")]
            public IActionResult GetClaims()
            {
                return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
            }

            [HttpGet("~/username")]
            public IActionResult GetUserName()
            {
                return Ok(User.Identity.Name);
            }

            [HttpGet("~/jwtid")]
            public IActionResult GetUniqueId()
            {
                var jti = User.Claims.FirstOrDefault(p => p.Type == "jti");
                return Ok(jti.Value);
            }
        }
   
}