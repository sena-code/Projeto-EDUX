using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IObjetivoAluno
    {
        List<Objetivo> ListarObjetivos();
        Objetivo BuscPorID(Guid id);
        void Adicionar(Objetivo objetivo);
        void Editar(Objetivo objetivo);
        void Remover(Guid id);

    }
}