using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurma
    {
        private readonly EduxContext _ctx;

        public AlunoTurmaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um novo aluno
        /// </summary>
        /// <param name="AlunoTurma">Lista de alunos da turma</param>
        /// <returns>Objeto Aluno</returns>
        public void Adicionar(AlunoTurma alunoTurma)
        {
            try
            {
                _ctx.AlunosTurmas.Add(alunoTurma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AlunoTurma BuscarPorId(Guid id)
        {
            AlunoTurma alunoTurma = _ctx.AlunosTurmas.Find(id);
            if (alunoTurma == null)
                throw new Exception("Aluno não localizado");
            return alunoTurma;
        }

        /*
        public List<AlunoTurma> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }*/

        public void Editar(AlunoTurma alunoTurma)
        {
            AlunoTurma alunoTurma1 = BuscarPorId(alunoTurma.id);

            if (alunoTurma.id == null)
                _ctx.AlunosTurmas.Update(alunoTurma1);
            _ctx.SaveChanges();
        }

        public List<AlunoTurma> Listar()
        {
            try
            {
                List<AlunoTurma> alunoTurmas = _ctx.AlunosTurmas.ToList();
                return alunoTurmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            AlunoTurma alunoTurma = BuscarPorId(id);
            if (alunoTurma == null)
                throw new Exception("Aluno não localizado");
            _ctx.AlunosTurmas.Remove(alunoTurma);
            _ctx.SaveChanges();
        }
    }
}
