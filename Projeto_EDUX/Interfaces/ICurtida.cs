using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface ICurtida
    {
        List<Curtida> Listar();
        Curtida BuscarPorId(Guid id);
        void Adicionar(Curtida curtida);
        void Editar(Curtida curtida);
        void Excluir(Guid id);
    }
}
