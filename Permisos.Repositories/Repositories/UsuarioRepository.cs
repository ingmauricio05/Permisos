namespace Permisos.Repositories.Repositories
{
    using Permisos.Entities;
    using Permisos.Interfaces.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario entity)
        {
            using (var db = new permisosdbEntities())
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuario.Add(entity);
                        db.SaveChanges();
                        context.Commit();
                    }
                    catch (Exception ex)
                    {
                        context.Rollback();
                        throw new Exception("Error al guardar el registro", ex);
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new permisosdbEntities())
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {
                        var entity = db.Usuario.Find(id);
                        db.Usuario.Remove(entity);
                        db.SaveChanges();
                        context.Commit();
                    }
                    catch (Exception ex)
                    {
                        context.Rollback();
                        throw new Exception("Error al eliminar el registro", ex);
                    }
                }
            }
        }

        public void Edit(Usuario entity)
        {
            using (var db = new permisosdbEntities())
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(entity).State = EntityState.Modified;
                        db.SaveChanges();
                        context.Commit();
                    }
                    catch (Exception ex)
                    {
                        context.Rollback();
                        throw new Exception("Error al editar el registro", ex);
                    }
                }
            }
        }

        public List<Usuario> GetList()
        {
            using (var db = new permisosdbEntities())
            {
                try
                {
                    return db.Usuario.Include(c=>c.Rol).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los registros", ex);
                }
            }
        }

        public List<Usuario> GetListFilter(string search)
        {
            using (var db = new permisosdbEntities())
            {
                try
                {
                    return (from u in db.Usuario
                            join rol in db.Rol on u.idrol equals rol.id into rolU
                            from result in rolU.DefaultIfEmpty()
                            where (u.nombre.Contains(search) ||
                            result.nombre.Contains(search))
                            select u)
                              .Include(r => r.Rol)
                              .ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los registros", ex);
                }
            }
        }

        public Usuario Autenticar(string nombre, string pass)
        {
            using (var db = new permisosdbEntities())
            {
                var usuario = (from u in db.Usuario
                               where u.nombre == nombre && u.password == pass
                               select u).Include(c => c.Rol).Include(c => c.Rol.Operacion).FirstOrDefault();

                return usuario;
            }
        }

        public Usuario GetById(int id)
        {
            using (var db = new permisosdbEntities())
            {
                try
                {
                    return db.Usuario.Where(c => c.id.Equals(id)).Include(c=>c.Rol).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el registro", ex);
                }
            }
        }
    }
}
