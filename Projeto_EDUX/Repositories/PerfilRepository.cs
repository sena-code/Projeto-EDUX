using Projeto_EDUX.Context;
using Projeto_EDUX.Domains;
using Projeto_EDUX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Repositories
{
    public class PerfilRepository : IPerfil
    {
        private readonly EduxContext _ctx;
        public PerfilRepository()
        {
            _ctx = new EduxContext();
        }
        public void Adicionar(Perfil perfil)
        {
            try
            {
                //Método que adiciona os valores colocado no body ao banco de dados
                _ctx.Perfils.Add(perfil);

                // Para salvar as mudanças, ou seja, salvar as informações inseridas no body
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Perfil BuscarPorId(Guid Id)
        {
            try
            {
                // Ao inserir o Id na URL, ele irá retornar todas as informações que tem no perfil
               Perfil perfil = _ctx.Perfils.Find(Id);

                //Caso não achar o perfil
                if (perfil == null)
                    throw new Exception("Permição não encontrado");

                //retorna as informções do perfil
                return perfil;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(Perfil perfil)
        {
            try
            {
                //Aqui busca um perfil pelo o Id
                Perfil perfilnew = BuscarPorId(perfil.Id);

                //Verificar se o Perfil do Id selecionado existe
                if (perfilnew == null)
                    throw new Exception("Permição não encontrado");

                //aqui ele vai dar um update nas informação do perfil
                _ctx.Perfils.Update(perfilnew);

                //Irá salvar as mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                // vai achar o perfil pelo id
                Perfil perfil = BuscarPorId(id);

                if (perfil == null)
                    throw new Exception("Permição não encontrado");

                //Irá remover o perfil pela a Id
                _ctx.Perfils.Remove(perfil);

                //Salvar as mudanças 
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perfil> Listar()
        {

            try
            {
                //Pego os perfils como lista 
                List<Perfil> perfils = _ctx.Perfils.ToList();
                //retorna os perfils e sua informação 
                return perfils;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
    
}
