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

    public class MedicamentoController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerMedicamento")]
        public HttpResponseMessage ObtenerMedicamento()
        {
            try
            {
                MedicamentoRepository medicamentoRepository = new MedicamentoRepository();
                var result = medicamentoRepository.ListarMedicamento();
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
        [Route("api/GuardarMedicamento")]
        public HttpResponseMessage GuardarMedicamento(Medicamentos medicamentos)
        {
            try
            {
                MedicamentoRepository medicamentoRepository = new MedicamentoRepository();
                var result = medicamentoRepository.InsertMedicamento(medicamentos);
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
        [Route("api/EliminarMedicamento/{codMedicamento}")]
        public HttpResponseMessage EliminarMedicamento(int codMedicamento)
        {
            try
            {
                MedicamentoRepository medicamentoRepository = new MedicamentoRepository();
                var result = medicamentoRepository.DeleteMedicamento(codMedicamento);
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
        [Route("api/ActualizarMedicamento")]
        public HttpResponseMessage ActulizarMedicamento(Medicamentos medicamentos)
        {
            try
            {
                MedicamentoRepository medicamentoRepository = new MedicamentoRepository();
                var result = medicamentoRepository.UpdateMedicamento(medicamentos);
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