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
    public class RolService:BaseService<Rol>, IRolService
    {
        private readonly IRolRespositoy RolRepository;

        public RolService(IRolRespositoy RolRepository):base(RolRepository)
        {
            this.RolRepository = RolRepository;
        }
    }
}
