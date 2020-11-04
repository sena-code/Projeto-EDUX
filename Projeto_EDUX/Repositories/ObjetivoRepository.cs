using Microsoft.EntityFrameworkCore;
using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class ObjetivoRepository : IObjetivocs
    {
        private readonly EduxContext _ctx;
        public ObjetivoRepository ()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um objeto 
        /// </summary>
        /// <param name="objetivo">Nome do objetivvo </param>
        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                _ctx.Objetivo.Add(objetivo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Procura um objetivo pelo seu id
        /// </summary>
        /// <param name="id">Id do objetivo</param>
        /// <returns>Curso procurado</returns>
        public Objetivo BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Objetivo.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar(Objetivo objetivo)
        {

            Objetivo objetivonew = BuscarPorId(objetivo.Id);
            objetivonew.IdCategoria = objetivo.IdCategoria;
            objetivonew.Descricao = objetivo.Descricao;


            if (objetivo.Id == null)
                throw new Exception("Nenhum objetivo encontrado");

            _ctx.Objetivo.Update(objetivonew);

            _ctx.SaveChanges();

        }
        /// <summary>
        /// Listar todos os objetivos do sistema
        /// </summary>
        /// <returns>Lista de objetivos</returns>
        public List<Objetivo> Listar()
        {
            try
            {
                
                
                return _ctx.Objetivo.Include("Categoria").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Atualizar(Objetivo objetivo)
        {
            try
            {
                //Aqui busca um perfil pelo o Id
                Objetivo newobjetivo = BuscarPorId(objetivo.Id);

                //Verificar se o Perfil do Id selecionado existe
                if (newobjetivo == null)
                    throw new Exception("Objetivo não encontrado");

                //aqui ele vai dar um update nas informação do perfil
                _ctx.Objetivo.Update(newobjetivo);

                //Irá salvar as mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Listar todos os objetivos do sistema
        /// </summary>
        /// <returns>Lista de Objetivos</returns>
        public void Remover(Guid id)
        {
            try
            {
                Objetivo objetivo = BuscarPorId(id);

                if (objetivo == null)
                    throw new Exception("Curso não encontrado");

                _ctx.Objetivo.Remove(objetivo);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
