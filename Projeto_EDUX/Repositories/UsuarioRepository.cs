using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private EduxContext _ctx;
        public UsuarioRepository()
        {
            _ctx = new EduxContext();
        }
        
        public void Adicionar(Usuario usuario)
        {
            try
            {
                usuario.DataCadastro = DateTime.Now;
                usuario.DataUltimoAcesso = DateTime.Now;
                // adiciona as informações que estão no body
                _ctx.Usuario.Add(usuario);
                // Salva as mudanças 
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                //definir um usuário que vai ser encontrado pelo Id

                Usuario usuario = _ctx.Usuario.Find(id);
                //caso não achar
                if (usuario == null)
                    throw new Exception("O usuário não foi encontrado");
                //retorna o usuario selecionado pelo id
                return usuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                //buscar o usuário que deseja excluir 
                Usuario usuario = BuscarPorId(id);
                // caso não achar o usuário
                if (usuario == null)
                    throw new Exception("Usuário não encontrado");
                //excluir o usuário selecionado por id
                _ctx.Usuario.Remove(usuario);
                //salvar as mudanças 
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Usuario usuario)
        {
            try
            {
                //procura o usuario que quer editar pelo id 
                Usuario usuarionew = BuscarPorId(usuario.Id);
                //Caso não achar
                if (usuarionew == null)
                    throw new Exception("Usuário não encontrado");
                //Atualiza as informações novas
                _ctx.Usuario.Update(usuarionew);
                //salva as alterações 
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> Listar()
        {
            try
            {
           

                //pega a lista de usuarios
                List<Usuario> usuarios = _ctx.Usuario.ToList();
                //retorna essa lista 
                return usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
