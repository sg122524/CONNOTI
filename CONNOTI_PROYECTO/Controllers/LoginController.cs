using Capa_Datos;
using Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCrypt.Net; // Importar BCrypt.Net
using CONNOTI_PROYECTO.Utilidades;

namespace CONNOTI_PROYECTO.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {

            Usuario ousuario = CD_Usuario.Instancia.ObtenerUsuarios().Where(u => u.Correo == correo && u.Clave == Encriptar.GetSHA256(clave)).FirstOrDefault();

            if (ousuario == null)
            {
                ViewBag.Error = "Usuario o contraseña no correcta";
                return View();
            }

            Session["Usuario"] = ousuario;

            return RedirectToAction("Index", "Home");
        }


    }
}
