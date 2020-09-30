using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class ProfessorTurma
    {
        /// <summary>
        /// Define a classe professorTurma
        /// </summary>
        [Key]
        public Guid id { get; set; }
        public string descricao { get; set; }


        public ProfessorTurma()
        {
            id = Guid.NewGuid();
        }
    }
}