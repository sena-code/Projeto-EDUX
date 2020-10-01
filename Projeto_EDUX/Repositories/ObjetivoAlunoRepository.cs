using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAluno
    {
        private EduxContext _ctx;

        public ObjetivoAlunoRepository()
        {
            _ctx = new EduxContext();
        }
        public void Adicionar(ObjetivoAluno objetivo)
        {
            try
            {
                
                _ctx.Objetivos.Add(objetivo);
              
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ObjetivoAluno BuscarPorId(Guid Id)
        {
            
            ObjetivoAluno objetivo = _ctx.Objetivos.Find(Id);
           
            if (objetivo == null)
                throw new Exception("Não foi possível achar nenhum objetivo");
           
            return objetivo;
        }

        public void Editar(ObjetivoAluno objetivo)
        {
           
            ObjetivoAluno objetivonew = BuscarPorId(objetivo.Id);
            
            if (objetivo.Id == null)
                throw new Exception("Nenhum objetivo encontrado");
           
            _ctx.Objetivos.Update(objetivonew);
           
            _ctx.SaveChanges();

        }

        public void Excluir(Guid id)
        {
           
            ObjetivoAluno objetivo = BuscarPorId(id);
           
            if (objetivo == null)
                throw new Exception("Nenhum objetivo encontrado");
           
            _ctx.objetivos.Remove(objetivo);
           
            _ctx.SaveChanges();
        }

        public List<ObjetivoAluno> Listar()
        {
            try
            {
                List<ObjetivoAluno> objetivo = _ctx.Objetivos.ToList();

                return objetivo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

