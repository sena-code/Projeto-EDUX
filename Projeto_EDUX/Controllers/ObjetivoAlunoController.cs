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
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAluno _objetivoAlunoRepository;

        public ObjetivoAlunoController()
        {
            _objetivoAlunoRepository = new ObjetivoAlunoRepository();
        }

        // GET api/<ObjetivoAlunoController>

        /// <summary>
        /// Lista todos os objetivos feitos pelos alunos
        /// </summary>
        /// <returns>Objetivos cumpridos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var turmas = _objetivoAlunoRepository.Listar();

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

        // GET api/<ObjetivoAlunoController>/5

        /// <summary>
        /// Busca determinado objetivo pelo ID
        /// </summary>
        /// <param name="id">Id do objetivo cumprido</param>
        /// <returns>Objetivo encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                ObjetivoAluno objetivoA = _objetivoAlunoRepository.BuscarPorId(id);

                if (objetivoA == null)
                    return NotFound();

                return Ok(objetivoA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        
        [HttpGet("objetivo")]
        public IActionResult Buscarobjetivocomobjetivo()
        {
            try
            {
                var Objetivos = _objetivoAlunoRepository.Listar();

                return Ok(new { data = Objetivos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario")]
        public IActionResult Buscarobjetivocomousuario()
        {
            try
            {
                var Usuarios = _objetivoAlunoRepository.Listar();

                return Ok(new { data = Usuarios });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<ObjetivoAlunoController>

        /// <summary>
        /// Adiciona dados de avaliação do objetivo proposto
        /// </summary>
        /// <param name="objetivo">Dados do aluno</param>
        /// <returns>Dados adicionados</returns>
        [HttpPost]
        public IActionResult Post(ObjetivoAluno objetivo)
        {
            try
            {
                _objetivoAlunoRepository.Adicionar(objetivo);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<ObjetivoAlunoController>/5
        
        /// <summary>
        /// Alterar dados de avaliação do objetivo
        /// </summary>
        /// <param name="id">ID do objetivo</param>
        /// <param name="objetivo">Objetivo proposto</param>
        /// <returns>Dados alterados</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ObjetivoAluno objetivo)
        {
            try
            {
                objetivo.Id = id;
                _objetivoAlunoRepository.Editar(objetivo);
                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<ObjetivoAlunoController>/5
        
        /// <summary>
        /// Deleta dados de avaliação de objetivos propostos
        /// </summary>
        /// <param name="id">Id do objetivo</param>
        /// <returns>Dados deletados</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var objetivoA = _objetivoAlunoRepository.BuscarPorId(id);
                if (objetivoA == null)
                    return NotFound();

                _objetivoAlunoRepository.Excluir(id);

                return Ok(objetivoA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
