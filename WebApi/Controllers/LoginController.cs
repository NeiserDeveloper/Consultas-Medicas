using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST", exposedHeaders: "X-My-Header")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Authentication/{user}/{password}/")]
        public HttpResponseMessage Authentication(string user, string password)
        {
            try
            {
                LoginRepository loginRepository = new LoginRepository();
                var result = loginRepository.Authentication(user, password);
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    result
                });
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Success = false,
                    Error = e.Message
                });
            }
        }
    }
}