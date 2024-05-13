using Capa_Datos;
using Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CONNOTI_PROYECTO.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Concierto()
        {
            return View();
        }

        // GET: Reporte
        public ActionResult Ventas()
        {
            return View();
        }

        public JsonResult ObtenerConcierto(int idboleteria, string codigoconcierto)
        {
            List<ReporteConcierto> lista = CD_Reportes.Instancia.ReporteConciertoBoleteria(idboleteria, codigoconcierto);

            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerVenta(string fechainicio, string fechafin, int idboleteria)
        {

            List<ReporteVenta> lista = CD_Reportes.Instancia.ReporteVenta(Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin), idboleteria);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

    }
}