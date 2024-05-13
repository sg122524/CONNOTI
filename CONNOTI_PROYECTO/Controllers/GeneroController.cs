using Capa_Datos;
using Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CONNOTI_PROYECTO.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Categoria
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            List<Genero> lista = CD_Genero.Instancia.ObtenerGenero();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(Genero objeto)
        {
            bool respuesta = false;

            if (objeto.IdGenero == 0)
            {

                respuesta = CD_Genero.Instancia.RegistrarGenero(objeto);
            }
            else
            {
                respuesta = CD_Genero.Instancia.ModificarGenero(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Genero.Instancia.EliminarGenero(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}