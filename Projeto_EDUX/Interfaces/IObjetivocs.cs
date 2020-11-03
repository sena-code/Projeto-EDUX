using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IObjetivocs
    {
        //Metodo que lista todos os curso que foram adicionados no sistema
        List<Objetivo> Listar();
        //Metodo para buscar um curso pelo id
        Objetivo BuscarPorId(Guid id);
       
        void Editar(Objetivo objetivo);

        //Metodo que adiciona um curso no sistema, com os seus respectivos dados
        void Adicionar(Objetivo  objetivo);

        //Metodo que remove um curso do sistema
        void Remover(Guid id);
    }
}
