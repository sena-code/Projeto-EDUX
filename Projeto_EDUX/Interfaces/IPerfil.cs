using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Interfaces
{
    interface IPerfil
    {
        List<Perfil> Listar();
        Perfil BuscarPorId(Guid Id);
        void Adicionar(Perfil perfil);
        void Editar(Perfil perfil);
        void Excluir(Guid id );
    }
}
