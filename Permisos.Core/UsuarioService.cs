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
    public class UsuarioService:BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository UsuarioRepository;

        public UsuarioService(IUsuarioRepository UsuarioRepository):base(UsuarioRepository)
        {
            this.UsuarioRepository = UsuarioRepository;
        }
    }
}
