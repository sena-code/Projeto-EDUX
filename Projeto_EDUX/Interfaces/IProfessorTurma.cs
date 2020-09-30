using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IProfessorTurma
    {
        List<ProfessorTurma> Listar();
        ProfessorTurma BuscarPorId(Guid id);
        //List<ProfessorTurma> BuscarPorNome(string nome);
        void Adicionar(ProfessorTurma professorTurma);
        void Editar(ProfessorTurma professorTurma);
        void Excluir(Guid id);
    }
}