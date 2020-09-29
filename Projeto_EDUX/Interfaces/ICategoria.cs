using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface ICategoria
    {
        //Metodo que lista todos os curso que foram adicionados no sistema
        List<Categoria> Listar();
        //Metodo para buscar um curso pelo id
        Categoria BuscarPorId(Guid id);

        //Metodo que adiciona um curso no sistema, com os seus respectivos dados
        void Adicionar(Categoria categoria);

        //Metodo que remove um curso do sistema
        void Remover(Guid id);
    }
}
