using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class DicaRepository : IDica
    {
        private EduxContext _ctx;

        public DicaRepository()
        {
            _ctx = new EduxContext();
        }
        public void Adicionar(Dica dica)
        {
            try
            {
                //Adicionar as informações do body no banco
                _ctx.Dicas.Add(dica);
                //Salvar as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Dica BuscarPorId(Guid Id)
        {
            //é colocado uma variável para achar a dica segundo seu id
            Dica dica = _ctx.Dicas.Find(Id);
            //caso não achar a dica
            if (dica == null)
                throw new Exception("Não foi possível achar nenhuma dica");
            //retorna a dica que tem o id correspondente ao inserido 
            return dica;
        }

        public void Editar(Dica dica)
        {
            //busca a dica a ser alterada 
            Dica dicanew = BuscarPorId(dica.Id);
            //caso nenhuma dica for achada ira retornar essa mensagem
            if (dica.Id == null)
                throw new Exception("Nenhuma dica encontrada");
            //atualiza a dica com as informações inseridas no body 
            _ctx.Dicas.Update(dicanew);
            //salva as alterações
            _ctx.SaveChanges();

        }

        public void Excluir(Guid id)
        {
            //procura a dica por id
            Dica dica = BuscarPorId(id);
            //caso não achar a dica
            if (dica == null)
                throw new Exception("Nenhuma dica foi encontrada");
            //remove a dica por id 
            _ctx.Dicas.Remove(dica);
            //salva as alterações
            _ctx.SaveChanges ();
        }

        public List<Dica> Listar()
        {
            try
            {
                List<Dica> dica = _ctx.Dicas.ToList();

                return dica;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
