namespace Permisos.Interfaces.Repositories
{
    using Permisos.Entities;
    using System.Collections.Generic;

    public interface IRolRespositoy
    {
        void Add(Rol entity);

        void Delete(int id);

        void Edit(Rol entity);

        List<Rol> GetList();

        Rol GetById(int id);
    }
}
