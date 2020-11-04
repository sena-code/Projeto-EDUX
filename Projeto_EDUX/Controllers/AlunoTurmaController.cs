﻿using System;
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
    public class AlunoTurmaController : ControllerBase
    {
        private AlunoTurmaRepository _repo;

        public AlunoTurmaController()
        {
            _repo = new AlunoTurmaRepository();
        }

        // GET: api/<AlunoTurmaController>
        /// <summary>
        /// Listar as Alunos
        /// </summary>
        /// <returns>Ok ou badResquest em caso de exceção</returns>
        /// 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var alunos = _repo.Listar();
                if (alunos.Count == 0)
                    return NoContent();

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AlunoTurmaController>/5
        /// <summary>
        ///  Buscar aluno por Id
        /// </summary>
        /// <param name="id">id do aluno</param>
        /// <returns>Aluno conforme o id</returns>
        ///
        [HttpGet("{id}")]

        
        

        public IActionResult Get(Guid id)

        {
            try
            {
                AlunoTurma alunoTurma = _repo.BuscarPorId(id);
                if (alunoTurma == null)
                    return NotFound();

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario")]
        public IActionResult BuscarEventosComEventos()
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



        /*
        /// <summary>
        /// Buscar aluno pelo nome
        /// </summary>
        /// <param name="nome">descricao do aluno</param>
        /// <returns>Retorna um aluno pelo nome</returns>
        public List<AlunoTurma> BuscarPorNome(string nome)
        {
            try
            {

                List<AlunoTurma> AlunosTurmas = _ctx.AlunosTurmas.Where(c => c.Nome.Contains(nome)).ToList();
                return AlunosTurmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/


        // POST api/<AlunoTurmaController>
        /// <summary>
        /// Adicionar Aluno
        /// </summary>
        /// <param name="alunoTurma">informações do aluno</param>
        /// <returns>adiciona aluno</returns>
        /// 
        [HttpPost]
        public IActionResult Post([FromBody] AlunoTurma alunoTurma)
        {
            try
            {
                _repo.Adicionar(alunoTurma);
                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlunoTurmaController>/5
        /// <summary>
        /// Editar dados do aluno
        /// </summary>
        /// <param name="id">id da dica</param>
        /// <param name="alunoTurma">informações do aluno</param>
        /// <returns>dados atualizadOs do aluno </returns>
        [HttpPut("{id}")]

        
        public IActionResult Put(Guid id, [FromBody] AlunoTurma alunoTurma)

        {
            try
            {
                alunoTurma.Id = id;
                _repo.Editar(alunoTurma);
                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlunoTurmaController>/5
        /// <summary>
        /// Excluir aluno
        /// </summary>
        /// <param name="id">id do aluno a ser excluido</param>
        [HttpDelete("{id}")]



       
        public IActionResult Excluir(Guid id)

        {
            try
            {
                var alunoDaTurma = _repo.BuscarPorId(id);
                if (alunoDaTurma == null)
                    return NotFound();

                _repo.Excluir(id);
                return Ok(alunoDaTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
