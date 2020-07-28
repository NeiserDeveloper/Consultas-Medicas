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
    public class PagosController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerPagos")]
        public HttpResponseMessage ObtenerPagos()
        {
            try
            {
                PagosRepository pagosRepository = new PagosRepository();
                var result = pagosRepository.ListarPagos();
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
        [Route("api/GuardarPagos")]
        public HttpResponseMessage GuardarPagos(Pagos pagos)
        {
            try
            {
                PagosRepository pagosRepository = new PagosRepository();
                var result = pagosRepository.InsertPagos(pagos);
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
        [Route("api/EliminarPagos/{codPagos}")]
        public HttpResponseMessage EliminarPagos(int codPagos)
        {
            try
            {
                PagosRepository pagosRepository = new PagosRepository();
                var result = pagosRepository.DeletePagos(codPagos);
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
        [Route("api/ActualizarPagos")]
        public HttpResponseMessage ActulizarPagos(Pagos pagos)
        {
            try
            {
                PagosRepository pagosRepository = new PagosRepository();
                var result = pagosRepository.UpdatePagos(pagos);
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