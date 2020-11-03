using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IPost
    {
        List<Post> Listar();
        Post BuscarPorId(Guid Id);
        void Adicionar(Post post);
        void Editar(Post post);
        void Excluir(Guid id);
    }
}
