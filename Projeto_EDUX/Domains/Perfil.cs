using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class Perfil : BaseDomains
    {
        public string Permicao { get; set; }

        [NotMapped]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
