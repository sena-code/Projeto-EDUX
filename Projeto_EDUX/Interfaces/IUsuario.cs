using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IUsuario
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(Guid id);
        void Adicionar(Usuario usuario);
        void Deletar(Guid id);
        void Editar(Usuario usuario);

    }
}
