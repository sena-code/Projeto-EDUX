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
                
                _ctx.ObjetivosAlunos.Add(objetivo);
              
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public ObjetivoAluno BuscarPorId(Guid Id)
        {
            
            ObjetivoAluno objetivo = _ctx.ObjetivosAlunos.Find(Id);
           
            if (objetivo == null)
                throw new Exception("Não foi possível achar nenhum objetivo");
           
            return objetivo;
        }

        public void Editar(ObjetivoAluno objetivo)
        {
           
            ObjetivoAluno objetivonew = BuscarPorId(objetivo.Id);
            objetivonew.DataAlcancada = objetivo.DataAlcancada;
            objetivonew.IdUsuario = objetivo.IdUsuario;
            objetivonew.Nota = objetivo.Nota;
            objetivonew.IdObjetivo = objetivo.IdObjetivo;
            
            if (objetivo.Id == null)
                throw new Exception("Nenhum objetivo encontrado");
           
            _ctx.ObjetivosAlunos.Update(objetivonew);
           
            _ctx.SaveChanges();

        }

        public void Excluir(Guid id)
        {
           
            ObjetivoAluno objetivo = BuscarPorId(id);
           
            if (objetivo == null)
                throw new Exception("Nenhum objetivo encontrado");
           
            _ctx.ObjetivosAlunos.Remove(objetivo);
           
            _ctx.SaveChanges();
        }

        public List<ObjetivoAluno> Listar()
        {
            try
            {
                List<ObjetivoAluno> objetivo = _ctx.ObjetivosAlunos.Include("Objetivo").ToList();
              



                return objetivo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}

