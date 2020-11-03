using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly EduxContext _ctx;

        public CategoriaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um categoria
        /// </summary>
        /// <param name="categoria">Nome da categoria</param>
        public void Adicionar(Categoria categoria)
        {
            try
            {
                _ctx.Categoria.Add(categoria);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Atualizar(Categoria categoria)
        {
            try
            {
                //Aqui busca um perfil pelo o Id
                Categoria newcategoria = BuscarPorId(categoria.Id);

                //Verificar se o Perfil do Id selecionado existe
                if (newcategoria == null)
                    throw new Exception("Objetivo não encontrado");

                //aqui ele vai dar um update nas informação do perfil
                _ctx.Categoria.Update(newcategoria);

                //Irá salvar as mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Procura uma categoria pelo seu id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>categoria procurado</returns>
        public Categoria BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Categoria.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Listar todos as categorias do sistema
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public List<Categoria> Listar()
        {
            try
            {
                return _ctx.Categoria.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Remove uma categoria
        /// </summary>
        /// <param name="id">Id da categoria</param>
        public void Remover(Guid id)
        {
            try
            {
                Categoria categoria = BuscarPorId(id);

                if (categoria == null)
                    throw new Exception("Curso não encontrado");

                _ctx.Categoria.Remove(categoria);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
