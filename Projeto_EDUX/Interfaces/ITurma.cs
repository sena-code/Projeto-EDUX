using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface ITurma
    {
        List<Turma> Listar();
        Turma BuscarPorId(Guid id);
        void Adicionar(Turma turma);

        
        void Editar(Turma Turma);
        void Excluir(Guid id);
    }
}