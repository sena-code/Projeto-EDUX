using Microsoft.EntityFrameworkCore;
using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class PostRepository
    {
        private EduxContext _ctx;

        public PostRepository()
        {
            _ctx = new EduxContext();
        }
        public void Adicionar(Post post)
        {
            try
            {
                
                //Adicionar as informações do body no banco
                _ctx.Posts.Add(post);
                //Salvar as alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Post BuscarPorId(Guid Id)
        {
            //é colocado uma variável para achar a dica segundo seu id
            Post post = _ctx.Posts.Find(Id);
            //caso não achar a dica
            if (post == null)
                throw new Exception("Não foi possível achar nenhuma dica");
            //retorna a dica que tem o id correspondente ao inserido 
            return post;
        }

        public void Editar(Post post)
        {
            //busca a dica a ser alterada 
            Post postnew = BuscarPorId(post.Id);
            //caso nenhuma dica for achada ira retornar essa mensagem
            if (post.Id == null)
                throw new Exception("Nenhuma dica encontrada");
            //atualiza a dica com as informações inseridas no body 
            _ctx.Posts.Update(postnew);
            //salva as alterações
            _ctx.SaveChanges();

        }

        public void Excluir(Guid id)
        {
            //procura a dica por id
           Post post = BuscarPorId(id);
            //caso não achar a dica
            if (post == null)
                throw new Exception("Nenhum post foi encontrado");
            //remove a dica por id 
            _ctx.Posts.Remove(post);
            //salva as alterações
            _ctx.SaveChanges();
        }

        public List<Post> Listar()
        {
            try
            {
                List<Post> post = _ctx.Posts.Include("Usuario").ToList();

                return post;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
