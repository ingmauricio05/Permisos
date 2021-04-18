
namespace Permisos.Web.Controllers
{
    using Permisos.Entities;
    using Permisos.Interfaces.Services;
    using System;
    using System.Web.Mvc;

    public class AutenticarController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public AutenticarController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: Autenticar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(string nombre, string password)
        {
            try
            {
                Usuario user = this.usuarioService.Autenticar(nombre, password);
                if (user != null)
                {
                    Session["user"] = user;
                    Session["username"] = user.nombrecompleto;
                    return Content("1");
                }

                return Content("Usuario invalido");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }
    }
}