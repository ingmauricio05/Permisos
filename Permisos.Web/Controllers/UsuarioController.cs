
namespace Permisos.Web.Controllers
{
    using Permisos.Entities;
    using Permisos.Interfaces.Services;
    using Permisos.Web.Filters;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;
        private readonly IRolService rolService;
        public UsuarioController(IUsuarioService usuarioService, IRolService rolService)
        {
            this.usuarioService = usuarioService;
            this.rolService = rolService;
        }

        // GET: Usuario
        [AuthorizeUser(4)]
        public ActionResult Index(string search = "")
        {
            return View(this.usuarioService.GetListFilter(search));
        }

        // GET: Usuario/Details/5
        [AuthorizeUser(4)]
        public ActionResult Details(int id)
        {
            Usuario usuario = this.usuarioService.GetById(id);

            return View(usuario);
        }

        // GET: Usuario/Create
        [AuthorizeUser(1)]
        public ActionResult Create()
        {
            this.RolFillList();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser(1)]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                this.RolFillList(usuario.idrol);
                if (ModelState.IsValid)
                {
                    if (this.NombreUsuarioUnico(0, usuario.nombre))
                    {
                        this.usuarioService.Add(usuario);

                        return RedirectToAction("Index");
                    }
                }

                return View(usuario);
            }
            catch
            {
                return View();
            }
        }

        [AuthorizeUser(3)]
        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = this.usuarioService.GetById(id);
            this.RolFillList(usuario.idrol);

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [AuthorizeUser(3)]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                this.RolFillList(usuario.idrol);
                if (ModelState.IsValid)
                {
                    if (this.NombreUsuarioUnico(usuario.id, usuario.nombre))
                    {
                        this.usuarioService.Edit(usuario);
                        return RedirectToAction("Index");
                    }
                }

                return View(usuario);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        [AuthorizeUser(2)]
        public ActionResult Delete(int id)
        {
            Usuario usuario = this.usuarioService.GetById(id);
            
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [AuthorizeUser(2)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                this.usuarioService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void RolFillList(int idRol = 0)
        {
            List<Rol> listaRoles = this.rolService.GetList();
            ViewBag.Roles = new SelectList(listaRoles, "id", "nombre", idRol);
        }

        private bool NombreUsuarioUnico(int id, string nombre)
        {
            var result = this.usuarioService.GetList();

            foreach (var item in result)
            {
                if (item.nombre == nombre)
                {
                    return (item.id == id);
                }
            }

            return true;
        }
    }
}
