using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class CurtidaRepository : ICurtida
    {
        private readonly EduxContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona uma nova curtida
        /// </summary>
        /// <param name="curtida">Lista as curtidas</param>
        /// <returns>Objeto Pedido</returns>
        public void Adicionar(Curtida curtida)
        {
            try
            {
                _ctx.Curtidas.Add(curtida);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message)
;
            }
        }

        public Curtida BuscarPorId(Guid id)
        {
            Curtida curtida = _ctx.Curtidas.Find(id);
            if (curtida == null)
                throw new Exception("Curtida não localizada");
            return curtida;
        }

        public void Editar(Curtida curtida)
        {
            Curtida curtida1 = BuscarPorId(curtida.id);

            if (curtida.id == null)
                throw new Exception("Curtida não localizada");

            _ctx.Curtidas.Update(curtida1);
            _ctx.SaveChanges();
        }

        public List<Curtida> Listar()
        {
            try
            {
                List<Curtida> curtidas = _ctx.Curtidas.ToList();
                return curtidas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            Curtida curtida = BuscarPorId(id);
            if (curtida == null)
                throw new Exception("Curtida não localizada");

            _ctx.Curtidas.Remove(curtida);
            _ctx.SaveChanges();
        }
    }
}

