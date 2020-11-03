using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using Projeto_EDUX.Repositories;

namespace Projeto_EDUX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICurso _cursoRepository;

        public  CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        // GET api/<CursoController>
        /// <summary>
        /// Ler todos os cursos cadastrados
        /// </summary>
        /// <returns>Lista dos cursos</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cursos = _cursoRepository.Listar();

                if (cursos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = cursos.Count,
                    data = cursos
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/curso"
                });
            }
        }

        // GET api/<CursoController>/5
        /// <summary>
        /// Busca um unico curso no sistema pelo seu ID
        /// </summary>
        /// <param name="id">ID do curso</param>
        /// <returns>Curso procurado</returns>

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Curso curso = _cursoRepository.BuscarPorId(id);

                if (curso == null)
                    return NotFound();

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CursoController>
        /// <summary>
        /// Cadastra um curso no sistema
        /// </summary>
        /// <param name="curso">Curso</param>
        /// <returns>Curso cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Curso curso)
        {
            try
            {
                _cursoRepository.Adicionar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Curso curso)
        {
            try
            {
                curso.Id = id;
                _cursoRepository.Editar(curso);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<CursoController>/5
        /// <summary>
        /// Exclui um curso do sistema
        /// </summary>
        /// <param name="id">ID do curso a ser excluida</param>
        /// <returns>ID do curso excluido</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var curso = _cursoRepository.BuscarPorId(id);
                if (curso == null)
                    return NotFound();

                _cursoRepository.Remover(id);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
