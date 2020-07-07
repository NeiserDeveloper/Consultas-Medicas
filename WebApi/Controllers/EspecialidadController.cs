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

    public class EspecialidadController : ApiController
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerEspecialidad")]
        public HttpResponseMessage ObtenerEspecialidad()
        {
            try
            {
                EspecialidadRepository especialidadRepository = new EspecialidadRepository();
                var result = especialidadRepository.ListarEspecialidad();
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
        [Route("api/GuardarEspecialidad")]
        public HttpResponseMessage GuardarEspecialidad(Especialidad especialidad)
        {
            try
            {
                EspecialidadRepository especialidadRepository = new EspecialidadRepository();
                var result = especialidadRepository.InsertEspecialidad(especialidad);
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
        [Route("api/EliminarEspecialidad/{codEspecialidad}")]
        public HttpResponseMessage EliminarEspecialidad(int codEspecialidad)
        {
            try
            {
                EspecialidadRepository especialidadRepository = new EspecialidadRepository();
                var result = especialidadRepository.DeleteEspecialidad(codEspecialidad);
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
        [Route("api/ActualizarEspecialidad")]
        public HttpResponseMessage ActulizarEspecialidad(Especialidad especialidad)
        {
            try
            {
                EspecialidadRepository especialidadRepository = new EspecialidadRepository();
                var result = especialidadRepository.UpdateEspecialidad(especialidad);
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