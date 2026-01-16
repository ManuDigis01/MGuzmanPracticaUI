using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    { 

    public static ML.Result Add(ML.Libros libro)
    {
        ML.Result result = new ML.Result();
        try
        {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroAdd(
                        libro.Nombre,
                        libro.AÑoPublicado,
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

        public static ML.Result LibroGetByAutor(int idAutor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroGetByAutor(idAutor).ToList();

                    if (registros.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var registro in registros)
                        {
                            ML.Libros libro = new ML.Libros();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.IdLibros = Convert.ToInt32(registro.IdLibros);
                            libro.Nombre = registro.Nombre;
                            libro.AÑoPublicado = Convert.ToInt32(registro.AñoPublicacion);
                            libro.FechaDePublicacion = Convert.ToDateTime(registro.FechaDePublicacion);
                            libro.Autor.IdAutor = Convert.ToInt32(registro.IdAutor);
                            libro.Autor.Nombre = registro.NombreAutor;
                            libro.Editorial.IdEditorial = Convert.ToInt32(registro.IdEditorial);
                            libro.Editorial.Nombre = registro.Editorial;

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

        public static ML.Result LibroGetByTitulo(string Titulo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroGetByTitulo(Titulo).ToList();

                    if (registros.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var registro in registros)
                        {
                            ML.Libros libro = new ML.Libros();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.IdLibros = Convert.ToInt32(registro.IdLibros);
                            libro.Nombre = registro.Titulo;
                            libro.AÑoPublicado = Convert.ToInt32(registro.AñoPublicacion);
                            libro.FechaDePublicacion = Convert.ToDateTime(registro.FechaDePublicacion);
                            libro.Autor.IdAutor = Convert.ToInt32(registro.IdAutor);
                            libro.Autor.Nombre = registro.NombreAutor;
                            libro.Editorial.IdEditorial = Convert.ToInt32(registro.IdEditorial);
                            libro.Editorial.Nombre = registro.Editorial;

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
        public static ML.Result LibroGetByEditorial(int idEditorial) { 
     
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroGetByEditorial(idEditorial).ToList();

                    if (registros.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var registro in registros)
                        {
                            ML.Libros libro = new ML.Libros();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.IdLibros = Convert.ToInt32(registro.IdLibros);
                            libro.Nombre = registro.Nombre;
                            libro.AÑoPublicado = Convert.ToInt32(registro.AñoPublicacion);
                            libro.FechaDePublicacion = Convert.ToDateTime(registro.FechaDePublicacion);
                            libro.Autor.IdAutor = Convert.ToInt32(registro.IdAutor);
                            libro.Autor.Nombre = registro.NombreAutor;
                            libro.Editorial.IdEditorial = Convert.ToInt32(registro.IdEditorial);
                            libro.Editorial.Nombre = registro.Editorial;

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

        public static ML.Result LibroGetByAutorAndFecha(int idAutor, DateTime fechaDePublicacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LibreriaEntities context = new DL.LibreriaEntities())
                {
                    var registros = context.LibroGetByAutorAndFecha(idAutor,fechaDePublicacion).ToList();

                    if (registros.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var registro in registros)
                        {
                            ML.Libros libro = new ML.Libros();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();
                            libro.IdLibros = Convert.ToInt32(registro.IdLibros);
                            libro.Nombre = registro.Nombre;
                            libro.AÑoPublicado = Convert.ToInt32(registro.AñoPublicacion);
                            libro.FechaDePublicacion = Convert.ToDateTime(registro.FechaDePublicacion);
                            libro.Autor.IdAutor = Convert.ToInt32(registro.IdAutor);
                            libro.Autor.Nombre = registro.NombreAutor;
                            libro.Editorial.IdEditorial = Convert.ToInt32(registro.IdEditorial);
                            libro.Editorial.Nombre = registro.Editorial;

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
