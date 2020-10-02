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
    public class CurtidaController : ControllerBase
    {
        private CurtidaRepository _repo;
        public CurtidaController()
        {
            _repo = new CurtidaRepository();
        }

/*        // GET: api/<CurtidaController>
        /// <summary>
        /// Listar Curtidas
        /// </summary>
        /// <returns>OK ou BadRequest em caso de exceção</returns>
        /// 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var curtidas = _repo.Listar();

                if (curtidas.Count == 0)
                    return NoContent();

                return Ok(curtidas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }*/

        // GET api/<CurtidaController>/5

         /// <summary>
        ///  Buscar curtida através do id
        /// </summary>
        /// <param name="id">id da curtida</param>
        /// <returns>Curtida correspondente ao id</returns>
        [HttpGet("{id}")]

      

        public IActionResult Get(Guid id)
        {
            try
            {
                Curtida curtida = _repo.BuscarPorId(id);
                if (curtida == null)
                    return NotFound();
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<CurtidaController>
        /// <summary>
        /// Adicionar curtidas
        /// </summary>
        /// <param name="curtida">Vixualização das curtidas</param>
        /// <returns>adiciona curtidas</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Curtida curtida)
        {
            try
            {
                _repo.Adicionar(curtida);
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

<<<<<<< HEAD

        // PUT api/<CurtidaController>/5

        

=======
/*        // PUT api/<CurtidaController>/
>>>>>>> 6f9c724915792b2d205cfcd628b456185a43ea34
        /// <summary>
        /// Editar a curtida
        /// </summary>
        /// <param name="id">id da curtida </param>
        /// <param name="curtida">vizualizações da curtida </param>
        /// <returns>Curtida alterada</returns>
        [HttpPut("{id}")]


        public IActionResult Put(Guid id, Curtida curtida)
        {
            try
            {
                curtida.id = id;
                _repo.Editar(curtida);
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }*/

        // DELETE api/<CurtidaController>/5
        /// <summary>
        /// Excluir curtida
        /// </summary>

        /// <param name="id">id da curtida</param>
        /// <returns>exclui a curtida</returns>
        [HttpDelete("{id}")]
        

        public IActionResult Delete(Guid id)
        {
            try
            {
                var curtiu = _repo.BuscarPorId(id);

                if (curtiu == null)
                    return NotFound();

                _repo.Excluir(id);
                return Ok(curtiu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
