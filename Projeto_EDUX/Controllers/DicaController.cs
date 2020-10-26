using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Repositories;
using Projeto_EDUX.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_EDUX.Controllers
{
    [Authorize(Roles = "Comum, Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private DicaRepository _repo;
        public DicaController()
        {
            _repo = new DicaRepository();
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
                var dicas = _repo.Listar();
                //caso não tiver nenhuma dica retorna esse status code 
                if (dicas.Count == 0)
                    return NoContent();
                //retorna a lista de dicas
                return Ok(dicas);
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
                Dica dica = _repo.BuscarPorId(id);
                // caso der erro, retorna esse status code
                if (dica == null)
                    return NotFound();
                //se achar retorna a dica referente ao id
                return Ok(dica);


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
        /// <param name="dica">as informações da dica</param>
        /// <returns>adiciona a dica</returns>
        
        [HttpPost]
        public IActionResult Post([FromForm] Dica dica)
        {
            try
            {
                //Verifico se foi enviado um arquivo com a imagem
                if (dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(dica.Imagem);

                    dica.UrlImagem = urlImagem;

                }
                //adicionar as alterações
                _repo.Adicionar(dica);
                //se der certo, adiciona e retorna  
                return Ok(dica);
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
        /// <param name="dica">informações da dica</param>
        /// <returns>a dica alterada</returns>
        /// 
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Dica dica)
        {
            try
            {
                //busca por id
                dica.Id = id;
                //edita a dica
                _repo.Editar(dica);
                //retorna a dica alterada
                return Ok(dica);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE api/<DicaController>/5
        /// <summary>
        /// Excluir uma dica
        /// </summary>
        /// <param name="id">id da dica a ser excluida</param>
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //busca o id para excluir
                var dica = _repo.BuscarPorId(id);
                // caso no acha retorna esse status code
                if (dica == null)
                    return NotFound();
                //exclui a dica
                _repo.Excluir(id);
                //exclui a dica
                return Ok(dica);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
    }
}
