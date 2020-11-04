using Microsoft.EntityFrameworkCore;
using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class TurmaRepository : ITurma
    {
        private EduxContext _ctx;

        public TurmaRepository()
        {
            _ctx = new EduxContext();
        }
        public void Adicionar(Turma turma)
        {
            try
            {
                
                _ctx.Turmas.Add(turma);
                
                
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Editar(Turma turma)
        {

            Turma turmanew = BuscarPorId(turma.Id);
            turmanew.Descricao = turma.Descricao;
            turmanew.IdCurso = turma.IdCurso;


            if (turma.Id == null)
                throw new Exception("Nenhum objetivo encontrado");

            _ctx.Turmas.Update(turmanew);

            _ctx.SaveChanges();

        }

        public Turma BuscarPorId(Guid Id)
        {
            
            Turma turma = _ctx.Turmas.Find(Id);
         
            if (turma == null)
                throw new Exception("Não foi possível achar uma turma");
           
            return turma;
        }

       

        public void Excluir(Guid id)
        {
            
            Turma turma = BuscarPorId(id);
            
            if (turma == null)
                throw new Exception("Nenhuma turma foi encontrada");
            
            _ctx.Turmas.Remove(turma);
            
            _ctx.SaveChanges();
        }

        public List<Turma> Listar()
        {
            try
            {
                List<Turma> turma = _ctx.Turmas.Include("Curso").ToList();

                return turma;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

