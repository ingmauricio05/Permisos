namespace Permisos.Interfaces.Repositories
{
    using Permisos.Entities;
    using System.Collections.Generic;

    public interface IOperacionRespository
    {
        void Add(Operacion entity);

        void Delete(int id);

        void Edit(Operacion entity);

        List<Operacion> GetList();

        Operacion GetById(int id);
    }
}
