using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class Curtida
    {
        /// <summary>
        /// Define a classe curtida
        /// </summary>
        [Key]
        public Guid id { get; set; }


        public Curtida()
        {
            id = Guid.NewGuid();
        }
    }
}
