using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_EDUX.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private PerfilRepository _repo;
        public PerfilController()
        {
            _repo = new PerfilRepository();
        }
        // GET: api/<PerfilController>
        /// <summary>
        /// Listar as Permições
        /// </summary>
        /// <returns>lista de permissões e id</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //adicionamos uma variavel pro método listar 
                var perfils = _repo.Listar();

                //Caso não tenho nenhum perfil retorna uma mensagem que não contem nada
                if (perfils.Count == 0)
                    return NoContent();

                //caso tiver tudo ok retorna os perfils
                return Ok(perfils);
            }
            catch (Exception ex)
            {
                //retorna um erro de bad request 
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PerfilController>/5
        /// <summary>
        /// Buscar uma permição por ID 
        /// </summary>
        /// <param name="id">Id da permição </param>
        /// <returns>permição do id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //defenimos a variavel com um método
                Perfil perfil = _repo.BuscarPorId(id);

                //Caso não achar o perfil
                if (perfil == null)
                    return NotFound();

                //caso achar retorna o perfil
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //retorna um erro de bad request 
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PerfilController>
        /// <summary>
        /// Adicionar uma permição nova          
        /// </summary>
        /// <param name="perfil">é a nova permição</param>
        /// <returns>permição adicionada</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Perfil perfil)
        {
            try
            {
                //O método adicionar uma informação nova
                _repo.Adicionar(perfil);
                // se der tudo certo a informação é adicionada 
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                //retorna um erro de bad request 
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PerfilController>/5
        /// <summary>
        /// Editar uma permição
        /// </summary>
        /// <param name="id">id da permição que deseja editar</param>
        /// <param name="perfil">a permição editada</param>
        /// <returns>a permição editada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Perfil perfil)
        {
            try
            {
                //difinir o id que está como argumento no metodo de BuscarPorId
                perfil.Id = id;
                //Edita uma informação do perfil
                _repo.Editar(perfil);
                //Caso der tudo certo, a informação é editada 
                return Ok(perfil);
            }
            catch (Exception ex)
            {

                //retorna um erro de bad request 
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PerfilController>/5
        /// <summary>
        /// Deletar uma permição 
        /// </summary>
        /// <param name="id">id da permição que deseja excluir</param>
        /// <returns>exclui a permição</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //defenimos a variavel com um método para buscar por id
                var perfil = _repo.BuscarPorId(id);

                //caso não achar
                if (perfil == null)
                    return NotFound();
                //remove o id
                _repo.Excluir(id);
                //Caso achar, o perfil é excluido
                return Ok(perfil);

            }
            catch (Exception ex)
            {

                //retorna um erro de bad request 
                return BadRequest(ex.Message);
            }
        }
    }
}
