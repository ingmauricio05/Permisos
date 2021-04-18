namespace Permisos.Web.Filters
{
    using Permisos.Entities;
    using Permisos.Web.Controllers;
    using System.Web;
    using System.Web.Mvc;

    public class VerifySession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (Usuario)HttpContext.Current.Session["user"];

            if (user == null)
            {
                if (filterContext.Controller is AutenticarController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Autenticar/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AutenticarController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}