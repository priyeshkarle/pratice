using MyApp.API;
using MyApp.WebAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApp.WebAPI.Controllers
{
    public class SecurityController : ApiController
    {
        [HttpPost()]
        public async Task<IHttpActionResult> LogIn(GlobalUser user)
        {
            if (user == null) return BadRequest("No data provided");
            using (var security = ObjectFactory.SecurityManager)
            {
                var token = await security.LogIn(user.Username, user.Password);
                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Log In Failed");
                }
                return Ok<string>(token);
            }
        }

        [HttpGet()]
        [Route("api/Security/GetNameByToken")]
        public async Task<IHttpActionResult> GetNameByToken(string token)
        {
            using (var security = ObjectFactory.SecurityManager)
            {
                var name = await security.GetNameByToken(token);
                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Provide data");
                }
                return Ok<string>(name);
            }
        }

        [HttpGet()]
        [Route("api/Security/GetUserByToken")]
        public async Task<IHttpActionResult> GetUserByToken(string token)
        {
            using (var security = ObjectFactory.SecurityManager)
            {
                if (string.IsNullOrEmpty(token))
                {
                    return BadRequest("Provide data");
                }

                var user = await security.GetUser(token);
                if (user == null) return NotFound();
                return Ok<Models.Common.BaseResponse<Models.Security.GlobalUser>>(
                    new Models.Common.BaseResponse<GlobalUser>()
                    {
                        Data = GlobalUser.Marshall(user),
                        Status = "OK"
                    }
                    );
            }
        }
    }
}
