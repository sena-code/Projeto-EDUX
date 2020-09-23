using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IDica
    {
        List<Dica> Listar();
        Dica BuscarPorId(Guid Id);
        void Adicionar(Dica dica);
        void Editar(Dica dica);
        void Excluir(Guid id);
    }
}
