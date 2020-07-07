using Entity;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST", exposedHeaders: "X-My-Header")]
    public class PacienteController : ApiController
    {

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerPacientes")]
        public HttpResponseMessage ObtenerPacientes()
        {
            try
            {
                PacienteRepository pacienteRepository = new PacienteRepository();
                var result = pacienteRepository.ListarPacientes();
                //var totales = registros.totalDatos(codDep) Prueba de Paginado;
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
        [Route("api/GuardarPaciente")]
        public HttpResponseMessage GuardarPaciente(Pacientes paciente)
        {
            try
            {
                PacienteRepository pacienteRepository = new PacienteRepository();
                var result = pacienteRepository.InsertPatient(paciente);
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
        [Route("api/EliminarPaciente")]
        public HttpResponseMessage EliminarPaciente(int codPaciente)
        {
            try
            {
                PacienteRepository pacienteRepository = new PacienteRepository();
                var result = pacienteRepository.DeletePatient(codPaciente);
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
        [Route("api/ActulizarPaciente")]
        public HttpResponseMessage ActulizarPaciente(Pacientes paciente)
        {
            try
            {
                PacienteRepository pacienteRepository = new PacienteRepository();
                var result = pacienteRepository.UpdatePatient(paciente);
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
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerDatosReniec/{dni}")]
        public HttpResponseMessage ObtenerDatosReniec(string dni)
        {
            try
            {
                var result = ObtenerPersonaDni(dni);
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
        public PersonaResponseReniec ObtenerPersonaDni(string documento)
        {
            //BaseurlString ="http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" & documento
            //string HostURI = "https://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" + documento;
            string API_RENIEC = "https://api.reniec.cloud/dni/" + documento;
            PersonaResponseReniec personaResponse = new PersonaResponseReniec();
            try
            {
                var webClient = new WebClient();

                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                var respuesta = webClient.UploadString(API_RENIEC , "GET");  
                PersonaResponseReniec persona = JsonConvert.DeserializeObject<PersonaResponseReniec>(respuesta);
                return persona;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
