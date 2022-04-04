using Proyecto.DBContext;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ClasificacionController : Controller
    {
        private LaBodegaContext context;

        public ClasificacionController()
        {
            context = new LaBodegaContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
        // GET: CategoriaProducto
        public ActionResult Index()
        {
            var clasificacion = context.Clasificacion.ToList();
            return View(clasificacion);
        }

        public ActionResult Crear()
        {
            var clasificacion = new Clasificacion();
            return View(clasificacion);
        }

        [HttpPost]
        public ActionResult Crear(Clasificacion clasificacion)
        {
            if (!ModelState.IsValid)
            {
                var clasifi = clasificacion;
                return View(clasifi);
            }
            context.Clasificacion.Add(clasificacion);
            context.SaveChanges();
            return RedirectToAction("Index", "Clasificacion");
        }


    }
}