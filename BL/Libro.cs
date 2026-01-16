using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    { 

    public static ML.Result Add(ML.Libro libro)
    {
        ML.Result result = new ML.Result();
        try
        {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroAdd(
                        libro.Titulo,
                        libro.FechaDePublicacion,
                        libro.Autor.IdAutor,
                        libro.Editorial.IdEditorial
                        );
                    if(registros > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }

                }

        }
        catch (Exception ex)
        {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

    }

        public static ML.Result BusquedaLibro(ML.Opciones opcion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.BusquedaLibrosGet(opcion.opcion,
                        opcion.idAutor,
                        opcion.FechaDePublicacion ,
                        opcion.idEditorial,
                        opcion.Titulo).ToList();

                    
                        if (registros.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (var registro in registros)
                            {
                                ML.Libro libro = new ML.Libro();
                                libro.Autor = new ML.Autor();
                                libro.Editorial = new ML.Editorial();

                                libro.IdLibro = Convert.ToInt32(registro.IdLibro);
                                libro.Titulo = registro.Titulo;
                                libro.FechaDePublicacion = Convert.ToDateTime(registro.FechaDePublicacion);

                                libro.Autor.IdAutor = Convert.ToInt32(registro.IdAutor);
                                libro.Autor.Nombre = registro.NombreAutor;
                                libro.Autor.ApellidoPaterno = registro.ApellidoPaterno;
                                libro.Autor.ApellidoMaterno = registro.ApellidoMaterno;

                                libro.Editorial.IdEditorial = Convert.ToInt32(registro.IdEditorial);
                                libro.Editorial.Nombre = registro.NombreEditorial;
                                libro.Editorial.Telefono = registro.Telefono;

                                result.Objects.Add(libro);
                            }

                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se encontró el Libro";
                        }
                    

                   
                }
            }
            catch (Exception ex)

            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

       
        public static ML.Result LibrosDeleteAutor(int idAutor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroDeleteAutor(idAutor);

                    if (registros > 0)
                    {

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino";
                    }

                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result LibrosDeleteEditorial(int idEditorial)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroDeleteEditorial(idEditorial);

                    if (registros > 0)
                    {

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino";
                    }

                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


    }
}
