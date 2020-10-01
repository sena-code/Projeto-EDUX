using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class ObjetivoAluno : BaseDomains
    {
        public int IdAluno { get; set; }
        public string Nota { get; set; }
        public int DataAlcancada { get; set; }
        
        public Guid IdTurma { get; set; }
        [ForeignKey("IdAlunoTurma")]
        public AlunoTurma AlunoTurma{ get; set; }


        public Guid IdObjetivo { get; set; }
        [ForeignKey("IdObjetivo")]
        public ObjetivoAluno Objetivo { get; set; }
    }

}