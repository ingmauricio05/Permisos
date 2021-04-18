namespace Permisos.Interfaces.Repositories
{
    using Permisos.Entities;
    using System.Collections.Generic;

    public interface IUsuarioRepository
    {
        void Add(Usuario entity);

        void Delete(int id);

        void Edit(Usuario entity);

        List<Usuario> GetList();

        List<Usuario> GetListFilter(string search);

        Usuario GetById(int id);

        Usuario Autenticar(string nombre, string pass);
    }
}
