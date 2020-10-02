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


        
    }
}