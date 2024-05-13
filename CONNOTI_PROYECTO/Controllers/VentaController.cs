using Capa_Datos;
using Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CONNOTI_PROYECTO.Controllers
{
    public class VentaController : Controller
    {
        private static Usuario SesionUsuario;
        // GET: Venta
        public ActionResult Crear()
        {
            SesionUsuario = (Usuario)Session["Usuario"];
            return View();
        }

        // GET: Venta
        public ActionResult Consultar()
        {
            return View();
        }

        public ActionResult Documento(int IdVenta = 0)
        {

            Venta oVenta = CD_Venta.Instancia.ObtenerDetalleVenta(IdVenta);



            NumberFormatInfo formato = new CultureInfo("es-PE").NumberFormat;
            formato.CurrencyGroupSeparator = ".";


            if (oVenta == null)
                oVenta = new Venta();
            else
            {

                oVenta.oListaDetalleVenta = (from dv in oVenta.oListaDetalleVenta
                                             select new DetalleVenta()
                                             {
                                                 Cantidad = dv.Cantidad,
                                                 NombreConcierto = dv.NombreConcierto,
                                                 PrecioUnidad = dv.PrecioUnidad,
                                                 TextoPrecioUnidad = dv.PrecioUnidad.ToString("N", formato), //numero.ToString("C", formato)
                                                 ImporteTotal = dv.ImporteTotal,
                                                 TextoImporteTotal = dv.ImporteTotal.ToString("N", formato)
                                             }).ToList();

                oVenta.TextoImporteRecibido = oVenta.ImporteRecibido.ToString("N", formato);
                oVenta.TextoImporteCambio = oVenta.ImporteCambio.ToString("N", formato);
                oVenta.TextoTotalCosto = oVenta.TotalCosto.ToString("N", formato);
            }


            return View(oVenta);
        }


        public JsonResult Obtener(string codigo, string fechainicio, string fechafin, string numerodocumento, string nombres)
        {
            List<Venta> lista = CD_Venta.Instancia.ObtenerListaVenta(codigo, Convert.ToDateTime(fechainicio), Convert.ToDateTime(fechafin), numerodocumento, nombres);


            if (lista == null)
                lista = new List<Venta>();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerUsuario()
        {
            Usuario rptUsuario = CD_Usuario.Instancia.ObtenerDetalleUsuario(SesionUsuario.IdUsuario);
            return Json(rptUsuario, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerProductoPorTienda(int IdTienda)
        {

            List<ConciertoBoleteria> oListaConciertoBoleteria = CD_ConciertoBoleteria.Instancia.ObtenerConciertoBoleteria();
            oListaConciertoBoleteria = oListaConciertoBoleteria.Where(x => x.oBoleteria.IdBoleteria == IdTienda && x.Stock > 0).ToList();


            return Json(new { data = oListaConciertoBoleteria }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ControlarStock(int idconcierto, int idboleteria, int cantidad, bool restar)
        {
            bool respuesta = CD_ConciertoBoleteria.Instancia.ControlarStock(idconcierto, idboleteria, cantidad, restar);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(string xml)
        {
            xml = xml.Replace("!idusuario¡", SesionUsuario.IdUsuario.ToString());
            int Respuesta = 0;
            Respuesta = CD_Venta.Instancia.RegistrarVenta(xml);
            if (Respuesta != 0)
                return Json(new { estado = true, valor = Respuesta.ToString() }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { estado = false, valor = "" }, JsonRequestBehavior.AllowGet);
        }
    }
}