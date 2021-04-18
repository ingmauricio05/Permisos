namespace Permisos.Services
{
    using Permisos.Entities;
    using Permisos.Interfaces.Repositories;
    using Permisos.Interfaces.Services;
    using System.Collections.Generic;

    public class RolService: IRolService
    {
        private readonly IRolRespositoy RolRepository;

        public RolService(IRolRespositoy RolRepository)
        {
            this.RolRepository = RolRepository;
        }

        public void Add(Rol entity)
        {
            this.RolRepository.Add(entity);
        }

        public void Delete(int id)
        {
            this.RolRepository.Delete(id);
        }

        public void Edit(Rol entity)
        {
            this.RolRepository.Edit(entity);
        }

        public Rol GetById(int id)
        {
            return this.RolRepository.GetById(id);
        }

        public List<Rol> GetList()
        {
            return this.RolRepository.GetList();
        }
    }
}
