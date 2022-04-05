using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto.DBContext;

namespace Proyecto.Controllers
{
    public class UnidadController : Controller
    {
        public Labodega context;
       
        public ActionResult Index()
        {
            return View();
        }
    }
}