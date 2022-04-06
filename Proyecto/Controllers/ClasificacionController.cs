using Proyecto.DBContext;
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

    }
}