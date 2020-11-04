using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using Projeto_EDUX.Repositories;

namespace Projeto_EDUX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
            private readonly ITurma _turmaRepository;

            public TurmaController()
            {
                _turmaRepository = new TurmaRepository();
            }

             // GET api/<TurmaController>

             /// <summary>
             /// Lista todas as turmas
             /// </summary>
             /// <returns>Lista de turmas</returns>
             [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    var turmas = _turmaRepository.Listar();

                    if (turmas.Count == 0)
                        return NoContent();

                    return Ok(new
                    {
                        totalCount = turmas.Count,
                        data = turmas
                    });
                }
                catch (Exception)
                {
                    return BadRequest(new
                    {
                        statusCode = 400,
                        error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/turma"
                    });
                }
            }
        [HttpGet("curso")]
        public IActionResult Buscarobjetivocomousuario()
        {
            try
            {
                var Cursos = _turmaRepository.Listar();

                return Ok(new { data = Cursos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<TurmaController>/5

        /// <summary>
        /// Busca uma turma pelo seu ID
        /// </summary>
        /// <param name="id">Id de turma</param>
        /// <returns>Turma procurada</returns>
        [HttpGet("{id}")]
            public IActionResult Get(Guid id)
            {
                try
                {
                    Turma turma = _turmaRepository.BuscarPorId(id);

                    if (turma == null)
                        return NotFound();

                    return Ok(turma);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        // POST api/<TurmaController>

        /// <summary>
        /// Adiciona uma turma no sistema
        /// </summary>
        /// <param name="turma">Turma a ser adicionada</param>
        /// <returns>Turma adicionada</returns>
        [HttpPost]
            public IActionResult Post(Turma turma)
            {
                try
                {
                _turmaRepository.Adicionar(turma);

                    return Ok(turma);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


        // GET api/<TurmaController>/5
        /// <summary>
        /// Alterar dados de uma turma
        /// </summary>
        /// <param name="id">Id da turma</param>
        /// <param name="turma">Turma a ser alterada</param>
        /// <returns>Turma alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Turma turma)
        {
            try
            {
                turma.Id = id;
                _turmaRepository.Editar(turma);
                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<TurmaController>/5
        /// <summary>
        /// Remove uma turma do sistema
        /// </summary>
        /// <param name="id">Id da turma</param>
        /// <returns>Turma removida</returns>
        [HttpDelete("{id}")]
            public IActionResult Delete(Guid id)
            {
                try
                {
                    var turma = _turmaRepository.BuscarPorId(id);
                    if (turma == null)
                        return NotFound();

                _turmaRepository.Excluir(id);

                    return Ok(turma);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
}
