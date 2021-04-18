namespace Permisos.Services
{
    using Permisos.Entities;
    using Permisos.Interfaces.Repositories;
    using Permisos.Interfaces.Services;
    using System.Collections.Generic;

    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository UsuarioRepository;

        public UsuarioService(IUsuarioRepository UsuarioRepository)
        {
            this.UsuarioRepository = UsuarioRepository;
        }

        public void Add(Usuario entity)
        {
            this.UsuarioRepository.Add(entity);
        }

        public void Delete(int id)
        {
            this.UsuarioRepository.Delete(id);
        }

        public void Edit(Usuario entity)
        {
            this.UsuarioRepository.Edit(entity);
        }

        public List<Usuario> GetList()
        {
            return this.UsuarioRepository.GetList();
        }

        public List<Usuario> GetListFilter(string search)
        {
            return this.UsuarioRepository.GetListFilter(search);
        }

        public Usuario GetById(int id)
        {
            return this.UsuarioRepository.GetById(id);
        }

        public Usuario Autenticar(string nombre, string pass)
        {
            return this.UsuarioRepository.Autenticar(nombre, pass);
        }
    }
}
