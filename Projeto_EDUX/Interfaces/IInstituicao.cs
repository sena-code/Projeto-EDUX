using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IInstituicao
    {
        //Metodo que lista todas as instituicao cadastradas no sistema
        List<Instituicao> Listar();

        //Metodo que busca uma determinada instituicao dentro do sistema pelo seu respectivo nome 
        List<Instituicao> BuscarPorNome(string nome);

        //Metodo que busca uma determinada instituicao pelo seu id no sistema
        Instituicao BuscarPorId(Guid id);

        //Metodo para cadastrar uma instituicao
        void Cadastrar(Instituicao instituicao);

        //Metodo para excluir uma instituicao do sistema
        void Exluir(Guid id);

    }
}
