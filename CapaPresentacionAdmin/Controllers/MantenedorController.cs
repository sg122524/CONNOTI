using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Conciertos()
        {
            return View();
        }

        public ActionResult Organizadores()
        {
            return View();
        }

        public ActionResult Calendario()
        {
            return View();
        }
    }
}