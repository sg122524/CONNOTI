using Capa_Datos;
using Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CONNOTI_PROYECTO.Controllers
{
    public class BoleteriaController : Controller
    {
        // GET: Tienda
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<BOLETERIAS> lista = CD_Boleteria.Instancia.ObtenerBoleteria();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(BOLETERIAS objeto)
        {
            bool respuesta = false;

            if (objeto.IdBoleteria == 0)
            {

                respuesta = CD_Boleteria.Instancia.RegistrarBoleteria(objeto);
            }
            else
            {
                respuesta = CD_Boleteria.Instancia.ModificarBoleteria(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Boleteria.Instancia.EliminarBoleteria(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}