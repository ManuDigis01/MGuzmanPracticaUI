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
        public IHttpActionResult Add([FromBody] ML.Libros libro)
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
        [Route("LibroGetByAutor/{idAutor}")]
        public IHttpActionResult GetByIdAutor(int idAutor)
        {
            ML.Result result = BL.Libro.LibroGetByAutor(idAutor);
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
        [Route("LibroGetBytitulo/{Titulo}")]
        public IHttpActionResult GetByTitulo(string Titulo)
        {
            ML.Result result = BL.Libro.LibroGetByTitulo(Titulo);
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
        [Route("LibroGetByEditorial/{idEditorial}")]
        public IHttpActionResult GetByIdEdotorial(int idEditorial)
        {
            ML.Result result = BL.Libro.LibroGetByEditorial(idEditorial);
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
        [Route("LibroGetByAutorAndFecha/{idAutor}")]
        public IHttpActionResult GetByIdAutor(int idAutor, DateTime fechaDePublicacion)
        {
            ML.Result result = BL.Libro.LibroGetByAutorAndFecha(idAutor, fechaDePublicacion);
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
