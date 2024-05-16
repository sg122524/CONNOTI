using Capa_Datos;
using Capa_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            var usuario = CD_Usuario.Instancia.ObtenerUsuarios()
                .FirstOrDefault(u => u.Correo == correo);

            if (usuario == null || !Encriptar.VerifyPassword(clave, usuario.Clave))
            {
                ViewBag.Error = "Usuario o contraseña no correcta";
                return View();
            }

            Session["Usuario"] = usuario;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Clave = Encriptar.HashPassword(usuario.Clave);
                usuario.ConfirmarClave = Encriptar.HashPassword(usuario.ConfirmarClave);

                bool resultado = CD_Usuario.Instancia.RegistrarUsuario(usuario);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Hubo un error al registrar el usuario.";
                }
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Reestablecer(string correo)
        {
            var usuario = CD_Usuario.Instancia.ObtenerUsuarios().FirstOrDefault(u => u.Correo == correo);
            if (usuario != null)
            {
                // Generar una nueva contraseña
                string nuevaClave = Guid.NewGuid().ToString().Substring(0, 8);
                usuario.Clave = Encriptar.HashPassword(nuevaClave);

                bool resultado = CD_Usuario.Instancia.ModificarUsuario(usuario);
                if (resultado)
                {
                    // Enviar correo con la nueva contraseña (implementación del envío de correo no incluida)
                    // EnviarCorreo(correo, nuevaClave);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Hubo un error al reestablecer la contraseña.";
                }
            }
            else
            {
                ViewBag.Error = "No se encontró un usuario con ese correo.";
            }
            return View();
        }
    }
}
