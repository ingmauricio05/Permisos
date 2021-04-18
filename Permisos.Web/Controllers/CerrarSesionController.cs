
namespace Permisos.Web.Controllers
{
    using System.Web.Mvc;

    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesion
        public ActionResult Logoff()
        {
            Session["user"] = null;
            Session["username"] = string.Empty;
            return RedirectToAction("Index", "Autenticar");
        }
    }
}