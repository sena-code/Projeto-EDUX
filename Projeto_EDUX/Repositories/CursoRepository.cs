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

        /// <summary>
        /// Adiciona um curso
        /// </summary>
        /// <param name="curso">Nome do curso</param>

        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Cursos.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Procura um curso pelo seu id
        /// </summary>
        /// <param name="id">Id do curso</param>
        /// <returns>Curso procurado</returns>
        public Curso BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Cursos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar(Curso curso)
        {

           Curso cursonew = BuscarPorId(curso.Id);
            cursonew.IdInstituicao = curso.IdInstituicao;
            cursonew.Titulo = curso.Titulo;
            

            if (curso.Id == null)
                throw new Exception("Nenhum objetivo encontrado");

            _ctx.Cursos.Update(cursonew);

            _ctx.SaveChanges();

        }

        /// <summary>
        /// Listar todos os cursos do sistema
        /// </summary>
        /// <returns>Lista de cursos</returns>
        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Cursos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Remove um curso
        /// </summary>
        /// <param name="id">Id do curso</param>
        public void Remover(Guid id)
        {
            try
            {
                Curso curso = BuscarPorId(id);

                if (curso == null)
                    throw new Exception("Curso não encontrado");

                _ctx.Cursos.Remove(curso);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
