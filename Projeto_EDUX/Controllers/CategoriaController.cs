using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using Projeto_EDUX.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }



        // GET api/<CategoriaController>
        /// <summary>
        /// Ler todos as categorias cadastrados
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var descricao = _categoriaRepository.Listar();

                if (descricao.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = descricao.Count,
                    data = descricao
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


        // GET api/<CategoriaController>/5
        /// <summary>
        /// Busca um unica categoria  no sistema pelo seu ID
        /// </summary>
        /// <param name="id">ID do categoria</param>
        /// <returns>Categoria procurado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Categoria categoria = _categoriaRepository.BuscarPorId(id);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoriaController>
        /// <summary>
        /// Cadastra uma categoria no sistema
        /// </summary>
        /// <param name="categoria">categoria</param>
        /// <returns>Curso cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            try
            {
                _categoriaRepository.Adicionar(categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                var categoria = _categoriaRepository.BuscarPorId(id);
                if (categoria == null)
                    return NotFound();

                _categoriaRepository.Remover(id);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}

<<<<<<< HEAD
 
=======


>>>>>>> c4a095c887177572a87488693034a84a1215717f
