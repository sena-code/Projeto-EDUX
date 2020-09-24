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
