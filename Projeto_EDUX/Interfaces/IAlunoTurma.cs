using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IAlunoTurma
    {
        List<AlunoTurma> Listar();
        AlunoTurma BuscarPorId(Guid id);
        //List<AlunoTurma> BuscarPorNome(string nome);
        void Adicionar(AlunoTurma alunoTurma);
        void Editar(AlunoTurma alunoTurma);
        void Excluir(Guid id);

    }
}
