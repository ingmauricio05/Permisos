
namespace Permisos.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorAutorizacionController : Controller
    {
        [HttpGet]
        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}