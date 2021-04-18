using Permisos.Entities;
using Permisos.Interfaces.Repositories;
using Permisos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permisos.Core
{
    public class OperacionService : IOperacionService
    {
        private readonly IOperacionRespository OperacionRepository;

        public OperacionService(IOperacionRespository OperacionRepository)
        {
            this.OperacionRepository = OperacionRepository;
        }

        public void Add(Operacion entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Operacion entity)
        {
            throw new NotImplementedException();
        }

        public List<Operacion> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Operacion> GetListFilter(string search)
        {
            throw new NotImplementedException();
        }
    }
}
