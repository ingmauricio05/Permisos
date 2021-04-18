namespace Permisos.Repositories.Repositories
{
    using Permisos.Entities;
    using Permisos.Interfaces.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class OperacionRepository : IOperacionRespository
    {
        public void Add(Operacion entity)
        {
            using (var db = new permisosdbEntities())
            {
                using (var context = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Operacion.Add(entity);
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
                        var entity = db.Operacion.Find(id);
                        db.Operacion.Remove(entity);
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

        public void Edit(Operacion entity)
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

        public Operacion GetById(int id)
        {
            using (var db = new permisosdbEntities())
            {
                try
                {
                    return db.Operacion.Where(c => c.id.Equals(id)).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el registro", ex);
                }
            }
        }

        public List<Operacion> GetList()
        {
            using (var db = new permisosdbEntities())
            {
                try
                {
                    return db.Operacion.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los registros", ex);
                }
            }
        }
    }
}
