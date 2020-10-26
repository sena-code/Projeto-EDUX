using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class ProfessorTurma : BaseDomains
    {

        /// <summary>
        /// Define a classe professorTurma
        /// </summary>
      


        public string descricao { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }



        public Guid IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma{ get; set; }

    }
}