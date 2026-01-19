using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PL_UI.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public ActionResult GetBusqueda()
        {
         

            string titulo = "";
            int IdAutor = 0;



            
            var registros = BL.Libro.GetAll(IdAutor,titulo);
                ML.Libro libro = new ML.Libro();
            if (registros.Correct)
            {
            
                libro.Libros = registros.Objects;

                

                

                return View(libro);
            }
            else
            {
                libro.Libros = new List<object>();


                return View(libro);
            }

        }

        [HttpPost]
        public ActionResult GetBusqueda(ML.Libro libro)
        {



            libro.Titulo = libro.Titulo ?? "";




            if (libro.Titulo != "")
            {
                var registroTituolo = GetBuquedaAPITitulo(libro.Titulo);
                if (registroTituolo.Correct)
                {


                    libro.Libros = registroTituolo.Objects;
                 

                }
                else
                {
                    libro.Libros = new List<object>();
                }
            }

            if (libro.Autor.IdAutor > 0)
            {
                ML.Result registros = GetBuquedaAPI(libro.Autor.IdAutor);
                if (registros.Correct)
                {


                    libro.Libros = registros.Objects;

                }
                else
                {
                    libro.Libros = new List<object>();
                }
            }




            return View(libro);
        }

        [HttpGet]
        public ActionResult FormLibro(int? Idlibro)
        {
            ML.Libro Libro = new ML.Libro();
           
       
          

            if (Idlibro == null)
            {

            }
            else
            {

             
                ML.Result respuesta = BL.Libro.GetById(Idlibro.Value);
                if (respuesta.Correct)
                {
                    Libro = (ML.Libro)respuesta.Object;

                  


                }
                else
                {

                }
               

            }
            return View(Libro);

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

      

        [NonAction]
        public static  ML.Result GetBuquedaAPI(int idAutor)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44387/api/libros/");

                    var response = client.GetAsync(
                        $"LibroGetByBusqueda?opcion=1&idAutor={idAutor}"
                    ).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // 🔥 CAMBIO CLAVE AQUÍ
                        var libros = response.Content.ReadAsAsync<List<ML.Libro>>().Result;

                        foreach (var libro in libros)
                        {
                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }


        public static ML.Result GetBuquedaAPITitulo(string titulo)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44387/api/libros/");

                    var response = client.GetAsync(
                        $"LibroGetByBusqueda?opcion=2&titulo={titulo}"
                    ).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // 🔥 CAMBIO CLAVE AQUÍ
                        var libros = response.Content.ReadAsAsync<List<ML.Libro>>().Result;

                        foreach (var libro in libros)
                        {
                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


    }
}