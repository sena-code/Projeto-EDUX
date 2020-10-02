using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface ICurtida
    {
        Curtida BuscarPorId(Guid id);
        void Adicionar(Curtida curtida);
        void Excluir(Guid id);
    }
}
