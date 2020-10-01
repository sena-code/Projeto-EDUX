using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class Curso : BaseDomains
    {
        //Atributo para nome do curso que sera cadastrado
        public string Titulo { get; set; }

        public Guid IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]
        public Instituicao Instituicao { get; set; }
    }
}
