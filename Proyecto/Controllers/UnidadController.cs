using Proyecto.DBContext;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class UnidadController : Controller
    {
       //
            private LaBodegaContext context;

            public UnidadController()
            {
                context = new LaBodegaContext();
            }
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                context.Dispose();
            }
           
            public ActionResult Index()
            {
                var unidad = context.Unidad.ToList();
                return View(unidad);
            }

            public ActionResult Detalle(int id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var unidad = context.Unidad.SingleOrDefault(u =>  u.UnidadMedidaID== id);
                if (unidad == null)
                    return HttpNotFound();

                return View(unidad);
            }



        
        public ActionResult Editar(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var unidad = context.Unidad.SingleOrDefault(uu => uu.UnidadMedidaID == id);
            if (unidad == null)
                return HttpNotFound();

            return View(unidad);
        }

        [HttpPost]
        public ActionResult Editar(Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                var unid = unidad;
                return View(unid);
            }
            if (unidad.UnidadMedidaID == 0)
                return HttpNotFound();


            var unidadDb = context.Unidad.SingleOrDefault(uu => uu.UnidadMedidaID == unidad.UnidadMedidaID);
            if (unidad == null)
                return HttpNotFound();
            unidadDb.Codigo = unidad.Codigo;
            unidadDb.Descripcion = unidad.Descripcion;
            unidadDb.Estado = unidad.Estado;

            context.SaveChanges();
            return RedirectToAction("Index", "Unidad");
        }


        public ActionResult Crear()
        {
            var unidad = new Unidad();
            return View(unidad);
        }



        [HttpPost]
            public ActionResult Crear(Unidad unidad)
            {
                if (!ModelState.IsValid)
                {
                    var unida = unidad;
                    return View(unida);
                }
                context.Unidad.Add(unidad);
                context.SaveChanges();
                return RedirectToAction("Index", "Unidad");
            }

            public ActionResult Eliminar(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var unidad = context.Unidad.SingleOrDefault(u => u.UnidadMedidaID == id);

                if (unidad == null)
                    return HttpNotFound();

                return View(unidad);
            }

            [HttpPost]
            public ActionResult Eliminar(int id)
            {

                if (id == 0)
                    return HttpNotFound();

                var Unidad = context.Unidad.SingleOrDefault(u => u.UnidadMedidaID == id);
                if (Unidad == null)
                    return HttpNotFound();

                context.Unidad.Remove(Unidad);
                context.SaveChanges();
                return RedirectToAction("Index", "Unidad");
            }
}
}


