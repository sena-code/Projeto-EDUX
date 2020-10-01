using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Repositories;
using Projeto_EDUX.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_EDUX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioRepository _repo;
        public UsuarioController()
        {
            _repo = new UsuarioRepository();
        }

        // GET: api/<UsuarioController>
        /// <summary>
        /// Listar os Usuários  
        /// </summary>
        /// <returns>Lista de Usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // coloca o método como uma variavel para dar de retorno
                var usuario = _repo.Listar();
                //Caso não tiver nenhum usuário retorna isso
                if (usuario.Count == 0)
                    return NoContent();
                // retorna uma lista
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //casa dar erro 
                return BadRequest(ex);
            }
        }

        // GET api/<UsuarioController>/5
        /// <summary>
        /// Buscar por ID 
        /// </summary>
        /// <param name="id">id da busca</param>
        /// <returns>o usuario do id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                // Colocar o método como variavel para returnar
                Usuario usuario = _repo.BuscarPorId(id);
                // Caso não achar retorna isso
                if (usuario == null)
                    return NotFound();
                //Caso der tudo certo 
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // POST api/<UsuarioController>
        /// <summary>
        /// Adiciona um usuario nos sistema
        /// </summary>
        /// <param name="usuario">Nome do usuario</param>
        /// <returns>Usuario cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {

                // Criptografamos antes de salvar a senha
                usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
                //adiciona o novo usuário
                _repo.Adicionar(usuario);
                
                //se tiver tudo ok, retorna o usuário adicionado 
                return Ok(usuario);

            }
            catch (Exception ex)
            {
                //se der erro retorna uma bad request 
                return BadRequest(ex);
            }
        }

        // PUT api/<UsuarioController>/5
        /// <summary>
        /// Editar um Usuário
        /// </summary>
        /// <param name="id">id do usuário que deseja editar</param>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                //difinir o id que está como argumento no metodo de BuscarPorId
                usuario.Id = id;
                // Criptografamos antes de salvar a senha
                usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
                //Edita uma informação do usuario
                _repo.Editar(usuario);
                //Caso der tudo certo, a informação é editada 
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE api/<UsuarioController>/5
        /// <summary>
        /// Deletar um usuário
        /// </summary>
        /// <param name="id">id do usuário que deseja excluir</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca o usuario que vai excluir por Id
                var usuario = _repo.BuscarPorId(id);
                // caso não achor retorna um not found
                if (usuario == null)
                    return NotFound();
                //remove o id
                _repo.Deletar(id);
                //se ocorre tudo bem deleta o usuario selecionado 
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                //caso der erro
                return BadRequest(ex);
            }
        }
    }
}
