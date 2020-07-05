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
    public class ReporteController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ReciboConsulta")]
        public HttpResponseMessage ReciboConsulta()
        {
            try
            {
                var result = "ACA PUEDES DEVOLVER LA RESPUESTA";
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