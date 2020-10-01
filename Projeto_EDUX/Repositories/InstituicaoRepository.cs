using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {

        private readonly EduxContext _ctx;

        public InstituicaoRepository()
        {
            _ctx = new EduxContext();
        }


        /// <summary>
        /// Busca uma isntituicao pelo seu nome
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <returns>Instituicao procurada</returns>
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Instituicao.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma instituicao pelo seu nome
        /// </summary>
        /// <param name="nome">Nome da instituicao</param>
        /// <returns>Instituicao procurada</returns>
        public List<Instituicao> BuscarPorNome(string nome)
        {
            try
            {
                List<Instituicao> instituicao = _ctx.Instituicao.Where(c => c.Nome.Contains(nome)).ToList();
                return instituicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra uma instituicao
        /// </summary>
        /// <param name="instituicao">Instuicao cadastrada</param>
        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _ctx.Instituicao.Add(instituicao);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma instituicao
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        public void Remover(Guid id)
        {
            try
            {
                Instituicao instituicao = BuscarPorId(id);

                if (instituicao == null)
                    throw new Exception("Curso não encontrado");

                _ctx.Instituicao.Remove(instituicao);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Instituicao> Listar()
        {
            try
            {
                return _ctx.Instituicao.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
