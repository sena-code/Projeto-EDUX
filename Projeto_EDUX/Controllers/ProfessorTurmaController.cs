using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_EDUX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorTurmaController : ControllerBase
    {
        private ProfessorTurmaRepository _repo;

        public ProfessorTurmaController()
        {
            _repo = new ProfessorTurmaRepository();
        }

        // GET: api/<ProfessorTurmaController> 
        /// <summary>
        /// Listar professores
        /// </summary>
        /// <returns>Ok ou badRequest em caso de exceção</returns>
        ///
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var professores = _repo.Listar();
                if (professores.Count == 0)
                    return NoContent();
                return Ok(professores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<ProfessorTurmaController>/5
        /// <summary>
        ///  Buscar professor pelo id
        /// </summary>
        /// <param name="id">id do professor</param>
        /// <returns>dados do professsor através do id</returns>
        [HttpGet("{id}")]
      
        public IActionResult Get(Guid id)
        {
            try
            {
                ProfessorTurma professorTurma = _repo.BuscarPorId(id);
                if (professorTurma == null)
                    return NotFound();
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /*
        /// <summary>
        /// Buscar professor pelo nome
        /// </summary>
        /// <param name="nome">descricao do professor</param>
        /// <returns>Retorna um professor pelo nome</returns>
        public List<ProfessorTurma> BuscarPorNome(string nome)
        {
            try
            {

                List<ProfessorTurma> professoresTurma = _ctx.professoresTurma.Where(c => c.Nome.Contains(nome)).ToList();
                return professoresTurma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/



        // POST api/<ProfessorTurmaController>
        /// <summary>
        /// Adicionar professor
        /// </summary>
        /// <param name="professor">dados do professor</param>
        /// <returns>professor adicionado</returns>
        /// 
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorTurma professor)
        {
            try
            {
                _repo.Adicionar(professor);
                return Ok(professor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProfessorTurmaController>/5
        /// <summary>
        /// Editar dados do professor
        /// </summary>
        /// <param name="id">id do professor</param>
        /// <param name="professorTurma">dados do professor</param>
        /// <returns>dados do professor adicionado ok</returns>
        [HttpPut("{id}")]
        
        public IActionResult Put(Guid id, [FromBody] ProfessorTurma professorTurma)
        {
            try
            {
                professorTurma.id = id;
                _repo.Editar(professorTurma);
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProfessorTurmaController>/5
        /// <summary>
        /// Excluir um cadastro de professor
        /// </summary>
        /// <param name="id">id do cadastro correspondente ao professor a ser excluida</param>
        [HttpDelete("{id}")]
        
        public IActionResult Delete(Guid id)
        {
            try
            {
                var professorDaTurma = _repo.BuscarPorId(id);

                if (professorDaTurma == null)
                    return NotFound();

                _repo.Excluir(id);
                return Ok(professorDaTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
