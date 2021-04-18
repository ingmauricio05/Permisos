namespace Permisos.Repositories.Repositories
{
    using Permisos.Entities;
    using Permisos.Interfaces.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class RolRepository : IRolRespositoy
    {
        public void Add(Rol entity)
        {
            using (var db = new permisosdbEntities())
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Rol.Add(entity);
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
                        var entity = db.Rol.Find(id);
                        db.Rol.Remove(entity);
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

        public void Edit(Rol entity)
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

        public List<Rol> GetList()
        {
            using (var db = new permisosdbEntities())
            {
                try
                {
                    return db.Rol.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los registros", ex);
                }
            }
        }

        public Rol GetById(int id)
        {
            using (var db = new permisosdbEntities())
            {
                try
                {
                    return db.Rol.Where(c => c.id.Equals(id)).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el registro", ex);
                }
            }
        }
    }
}
