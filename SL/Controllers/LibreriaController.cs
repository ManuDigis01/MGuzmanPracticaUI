using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/libros")]
    public class LibreriaController : ApiController
    {

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpGet]
        [Route("LibroGetByBusqueda/")]
        public IHttpActionResult LibroGetByBuqueda(int opcion, int idAutor = 0, DateTime? fecha = null, int idEditorial = 0, string titulo = "")
        {
            var opciones = new ML.Opciones
            {
                opcion = opcion,
                idAutor = idAutor,
                FechaDePublicacion = Convert.ToDateTime(fecha),
                idEditorial = idEditorial,
                Titulo = titulo
            };

            var result = BL.Libro.BusquedaLibro(opciones);

            if (result.Correct)
                return Ok(result.Objects);
            else
                return Content(HttpStatusCode.NotFound, result.ErrorMessage);
        }




        [HttpDelete]
        [Route("LibrosDeleteAutor/{idAutor}")]
        public IHttpActionResult DeleteAutor(int idAutor)
        {
            ML.Result result = BL.Libro.LibrosDeleteAutor(idAutor);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpDelete]
        [Route("LibrosDeleteEditorial/{idEditorial}")]
        public IHttpActionResult DeleteEditorial(int idEditorial)
        {
            ML.Result result = BL.Libro.LibrosDeleteEditorial(idEditorial);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }



        [AcceptVerbs("OPTIONS")]
        [Route("{*any}")]

        public HttpResponseMessage Option()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT,DELETE,OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
            return response;
        }
    }
}
