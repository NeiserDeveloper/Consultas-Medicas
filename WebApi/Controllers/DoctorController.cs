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
    public class DoctorController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerDoctores")]
        public HttpResponseMessage ObtenerDoctores()
        {
            try
            {
                DoctorRepository doctorRepository = new DoctorRepository();
                var result = doctorRepository.listarDoctores();
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