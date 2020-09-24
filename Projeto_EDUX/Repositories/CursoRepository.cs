using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class CursoRepository : ICurso
    {

        private readonly EduxContext _ctx;

        public CursoRepository()
        {
            _ctx = new EduxContext();
        }

        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Curso.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Curso.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Curso.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                Curso curso = BuscarPorId(id);

                if (curso == null)
                    throw new Exception("Curso não encontrado");

                _ctx.Curso.Remove(curso);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
