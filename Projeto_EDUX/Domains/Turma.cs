using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class Turma : BaseDomains
    {
        public int IdTurma { get; set; }
        public string descricao { get; set; }

        public Guid IdAluno { get; set; }
        [Foreignkey("IdCurso")]
        public ObjetivoAluno Objetivo{ get; set; }
    }
}
