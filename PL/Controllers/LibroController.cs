using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using UI.Models; // Ajusta al namespace real

public class LibrosController : Controller
{
 

    // GET: Libros
    public ActionResult Index()
    {
        var libros = db.Libro
            .Include(l => l.Autor)
            .Include(l => l.Editorial)
            .ToList();

        return View(libros);
    }

    // 🔍 Buscar libros por Autor
    [HttpPost]
    public ActionResult BuscarPorAutor(int idAutor)
    {
        var libros = db.Libro
            .Include(l => l.Autor)
            .Include(l => l.Editorial)
            .Where(l => l.IdAutor == idAutor)
            .ToList();

        return View("Index", libros);
    }

    // 🔍 Buscar libro por Título
    [HttpPost]
    public ActionResult BuscarPorTitulo(string titulo)
    {
        var libros = db.Libro
            .Include(l => l.Autor)
            .Include(l => l.Editorial)
            .Where(l => l.Titulo.Contains(titulo))
            .ToList();

        return View("Index", libros);
    }

    // 📖 Detalle del Libro
    public ActionResult Details(int id)
    {
        var libro = db.Libro
            .Include(l => l.Autor)
            .Include(l => l.Editorial)
            .FirstOrDefault(l => l.IdLibro == id);

        if (libro == null)
            return HttpNotFound();

        return View(libro);
    }

    // ➕ Alta de Libro
    public ActionResult Create()
    {
        ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre");
        ViewBag.IdEditorial = new SelectList(db.Editorial, "IdEditorial", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Libro libro)
    {
        if (ModelState.IsValid)
        {
            db.Libro.Add(libro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.IdAutor = new SelectList(db.Autor, "IdAutor", "Nombre", libro.IdAutor);
        ViewBag.IdEditorial = new SelectList(db.Editorial, "IdEditorial", "Nombre", libro.IdEditorial);
        return View(libro);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            db.Dispose();

        base.Dispose(disposing);
    }
}
