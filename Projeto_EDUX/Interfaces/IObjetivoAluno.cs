using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IObjetivoAluno
    {
        List<ObjetivoAluno> Listar();
        ObjetivoAluno BuscarPorId(Guid id);
        void Adicionar(ObjetivoAluno objetivo);
        void Editar(ObjetivoAluno objetivo);
        void Excluir(Guid id);

    }
}