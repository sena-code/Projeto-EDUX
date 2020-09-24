﻿using System;
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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Ler todos as instituicoes cadastradas
        /// </summary>
        /// <returns>Lista das instituicoes</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var instituicoes = _instituicaoRepository.Listar();

                if (instituicoes.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = instituicoes.Count,
                    data = instituicoes
                });
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/produtos"
                });
            }
        }

        /// <summary>
        /// Busca uma unica instituicao
        /// </summary>
        /// <param name="id">ID da instituicao</param>
        /// <returns>Instituicao procurada</returns>

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Instituicao instituicao = _instituicaoRepository.BuscarPorId(id);

                if (instituicao == null)
                    return NotFound();

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra uma instituicao no sistema
        /// </summary>
        /// <param name="instituicao">Instituicao toda</param>
        /// <returns>Instituicao cadastrada</returns>
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui uma instituicao do sistema
        /// </summary>
        /// <param name="id">ID da instituicao a ser excluida</param>
        /// <returns>ID da instituicao excluida</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var instituicao = _instituicaoRepository.BuscarPorId(id);
                if (instituicao == null)
                    return NotFound();

                _instituicaoRepository.Remover(id);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
