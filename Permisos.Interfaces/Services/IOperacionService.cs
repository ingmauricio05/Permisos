namespace Permisos.Interfaces.Services
{
    using Permisos.Entities;
    using System.Collections.Generic;

    public interface IOperacionService
    {
        void Add(Operacion entity);

        void Delete(int id);

        void Edit(Operacion entity);

        List<Operacion> GetList();

        Operacion GetById(int id);
    }
}
