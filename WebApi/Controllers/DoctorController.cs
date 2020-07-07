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
    public class DoctorController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ObtenerDoctor")]
        public HttpResponseMessage ObtenerDoctor()
        {
            try
            {
                DoctorRepository doctorRepository = new DoctorRepository();
                var result = doctorRepository.ListarDoctor();

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
        [Route("api/GuardarDoctor")]
        public HttpResponseMessage GuardarDoctor(Doctor doctor)
        {
            try
            {
                DoctorRepository doctorRepository = new DoctorRepository();
                var result = doctorRepository.InsertDoctor(doctor);
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
        [Route("api/EliminarDoctor/{codDoctor}")]
        public HttpResponseMessage EliminarDoctor(int codDoctor)
        {
            try
            {
                DoctorRepository doctorRepository = new DoctorRepository();
                var result = doctorRepository.DeleteDoctor(codDoctor);
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
        [Route("api/ActualizarDoctor")]
        public HttpResponseMessage ActualizarDoctor(Doctor doctor)
        {
            try
            {
                DoctorRepository doctorRepository = new DoctorRepository();
                var result = doctorRepository.UpdateDoctor(doctor);
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