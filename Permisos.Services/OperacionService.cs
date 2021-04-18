namespace Permisos.Services
{
    using Permisos.Entities;
    using Permisos.Interfaces.Repositories;
    using Permisos.Interfaces.Services;
    using System.Collections.Generic;

    public class OperacionService : IOperacionService
    {
        private readonly IOperacionRespository OperacionRepository;

        public OperacionService(IOperacionRespository OperacionRepository)
        {
            this.OperacionRepository = OperacionRepository;
        }

        public void Add(Operacion entity)
        {
            this.OperacionRepository.Add(entity);
        }

        public void Delete(int id)
        {
            this.OperacionRepository.Delete(id);
        }

        public void Edit(Operacion entity)
        {
            this.OperacionRepository.Edit(entity);
        }

        public Operacion GetById(int id)
        {
            return this.OperacionRepository.GetById(id);
        }

        public List<Operacion> GetList()
        {
            return this.OperacionRepository.GetList();
        }
    }
}
