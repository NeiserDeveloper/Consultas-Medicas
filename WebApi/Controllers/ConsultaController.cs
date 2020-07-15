using Entity;
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
    public class ConsultaController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerConsulta")]
        public HttpResponseMessage ObtenerMedicamento()
        {
            try
            {
                ConsultaRepository consultaRepository = new ConsultaRepository();
                var result = consultaRepository.ListarConsulta();
                //var totales = registros.totalDatos(codDep);
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    success = true,
                    result
                    /*data = new
                    {
                        totalConfirmados = totales.confirmados,
                        totalRecuperados = totales.recuperados,
                        totalFallecidos = totales.fallecidos,
                        result
                    }*/
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


        [HttpPost]
        [AllowAnonymous]
        [Route("api/GuardarConsulta")]
        public HttpResponseMessage GuardarMedicamento(Consulta consulta)
        {
            try
            {
                ConsultaRepository consultaRepository = new ConsultaRepository();
                var result = consultaRepository.InsertConsulta(consulta);
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
        [HttpPost]
        [AllowAnonymous]
        [Route("api/EliminarConsulta/{codConsulta}")]
        public HttpResponseMessage EliminarConsulta(int codConsulta)
        {
            try
            {
                ConsultaRepository consultaRepository = new ConsultaRepository();
                var result = consultaRepository.DeleteConsulta(codConsulta);
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
        [HttpPost]
        [AllowAnonymous]
        [Route("api/ActualizarConsulta")]
        public HttpResponseMessage ActulizarConsulta(Consulta consulta)
        {
            try
            {
                ConsultaRepository consultaRepository = new ConsultaRepository();
                var result = consultaRepository.UpdateConsulta(consulta);
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
