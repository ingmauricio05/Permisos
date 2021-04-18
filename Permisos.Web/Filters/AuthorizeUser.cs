namespace Permisos.Web.Filters
{
    using Permisos.Entities;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuario usuario;
        private int idOperacion;

        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                usuario = (Usuario)HttpContext.Current.Session["user"];

                if (!usuario.Rol.Operacion.Any(c => c.id == idOperacion))
                {
                    filterContext.Result = new RedirectResult("~/ErrorAutorizacion/Unauthorized");
                }
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("~/ErrorAutorizacion/Unauthorized");
            }
        }
    }
}