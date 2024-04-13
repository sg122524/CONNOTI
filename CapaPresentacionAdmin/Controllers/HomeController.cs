using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaProveedor;
namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }
        [HttpGet]

        public JsonResult listarUsuarios()
        {
            List<Usuarios> oLista = new List<Usuarios>();
            oLista = new CN_Usuarios().Listar();

            return Json(new {data = oLista }, JsonRequestBehavior.AllowGet);
        }


    }
}