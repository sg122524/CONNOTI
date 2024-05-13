using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Modelo;

namespace CONNOTI_PROYECTO.Controllers
{
    public class ConciertoController : Controller
    {
        // GET: Producto
        public ActionResult Crear()
        {
            return View();
        }

        // GET: Producto
        public ActionResult Asignar()
        {
            return View();
        }



        public JsonResult Obtener()
        {
            List<Concierto> lista = CD_Concierto.Instancia.ObtenerConcierto();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerPorBoleteria(int IdBoleteria)
        {

            List<Concierto> oListaConcierto = CD_Concierto.Instancia.ObtenerConcierto();
            List<ConciertoBoleteria> oListaConciertoBoleteria = CD_ConciertoBoleteria.Instancia.ObtenerConciertoBoleteria();

            oListaConcierto = oListaConcierto.Where(x => x.Activo == true).ToList();
            if (IdBoleteria != 0)
            {
                oListaConciertoBoleteria = oListaConciertoBoleteria.Where(x => x.oBoleteria.IdBoleteria == IdBoleteria).ToList();
                oListaConcierto = (from concierto in oListaConcierto
                                  join conciertoboleteria in oListaConciertoBoleteria on concierto.IdConcierto equals conciertoboleteria.oConcierto.IdConcierto
                                  where conciertoboleteria.oBoleteria.IdBoleteria == IdBoleteria
                                  select concierto).ToList();
            }

            return Json(new { data = oListaConcierto }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Concierto objeto)
        {
            bool respuesta = false;

            if (objeto.IdConcierto == 0)
            {

                respuesta = CD_Concierto.Instancia.RegistrarConcierto(objeto);
            }
            else
            {
                respuesta = CD_Concierto.Instancia.ModificarConcierto(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Concierto.Instancia.EliminarConcierto(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarConciertoBoleteria(ConciertoBoleteria objeto)
        {
            bool respuesta = CD_ConciertoBoleteria.Instancia.RegistrarConciertoBoleteria(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ModificarConciertoBoleteria(ConciertoBoleteria objeto)
        {
            bool respuesta = CD_ConciertoBoleteria.Instancia.ModificarConciertoBoleteria(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EliminarConciertoBoleteria(int id)
        {
            bool respuesta = CD_ConciertoBoleteria.Instancia.EliminarConciertoBoleteria(id);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ObtenerAsignaciones()
        {
            List<ConciertoBoleteria> lista = CD_ConciertoBoleteria.Instancia.ObtenerConciertoBoleteria();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}