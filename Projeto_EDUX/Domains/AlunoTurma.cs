using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class AlunoTurma
    {
        /// <summary>
        /// Define a classe alunoTurma
        /// </summary>
        [Key]
        public Guid id { get; set; }
        public string matricula { get; set; }

    }
}
