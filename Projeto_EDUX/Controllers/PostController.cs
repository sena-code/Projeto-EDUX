using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Repositories;
using Projeto_EDUX.Utils;

namespace Projeto_EDUX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private PostRepository _repo;
        public PostController()
        {
            _repo = new PostRepository();
        }
        // GET: api/<DicaController>
        /// <summary>
        /// Listar as Dicas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //colocar o listar em uma variavel para um retorno
                var post = _repo.Listar();
                //caso não tiver nenhuma dica retorna esse status code 
                if (post.Count == 0)
                    return NoContent();
                //retorna a lista de dicas
                return Ok(new { data = post });
            }
            catch (Exception ex)
            {
                //caso der erro retorna um bad request
                return BadRequest(ex);
            }
        }

        // GET api/<DicaController>/5
        /// <summary>
        ///  Buscar dica por Id
        /// </summary>
        /// <param name="id">id da dica</param>
        /// <returns>a dica referente ao id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                // Busca a dica por id
                Post post = _repo.BuscarPorId(id); 
                // caso der erro, retorna esse status code
                if (post == null)
                    return NotFound();
                //se achar retorna a dica referente ao id
                return Ok(post);


            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // POST api/<DicaController>
        /// <summary>
        /// Adicionar Dica
        /// </summary>
        /// <param name="post">as informações do post</param>
        /// <returns>adiciona a dica</returns>

        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            try
            {
                //Verifico se foi enviado um arquivo com a imagem
                if (post.Imagem != null)
                {
                    var urlImagem = Upload.Local(post.Imagem);

                    post.UrlImagem = urlImagem;

                }

                //adicionar as alterações
                _repo.Adicionar(post);
                //se der certo, adiciona e retorna  
                return Ok(new { data = post});
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // PUT api/<DicaController>/5
        /// <summary>
        /// Editar uma dica 
        /// </summary>
        /// <param name="id">id da dica</param>
        /// <param name="post">informações do post</param>
        /// <returns>a dica alterada</returns>
        /// 
        [Authorize(Roles = "Comum")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Post post)
        {
            try
            {
                //busca por id
                post.Id = id;
                //edita a dica
                _repo.Editar(post);
                //retorna a dica alterada
                return Ok(post);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("usuario")]
        public IActionResult Buscarobjetivocomousuario()
        {
            try
            {
                var Usuarios = _repo.Listar();

                return Ok(new { data = Usuarios });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<DicaController>/5
        /// <summary>
        /// Excluir uma dica
        /// </summary>
        /// <param name="id">id da dica a ser excluida</param>
        [Authorize(Roles =  "Comum, Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca o id para excluir
                var post = _repo.BuscarPorId(id);
                // caso no acha retorna esse status code
                if (post == null)
                    return NotFound();
                //exclui a dica
                _repo.Excluir(id);
                //exclui a dica
                return Ok(post);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
    }
}
