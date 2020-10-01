using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class Objetivo : BaseDomains
    {
        public string Descricao { get; set; }

    
        public Guid IdCategoria{ get; set; }
        [ForeignKey(" IdCategoria")]
        public Categoria Categoria { get; set; }
    }
}
