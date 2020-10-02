using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class AlunoTurma : BaseDomains
    {
<<<<<<< HEAD
        /// <summary>
        /// Define a classe alunoTurma
        /// </summary>
       
=======
>>>>>>> 6f9c724915792b2d205cfcd628b456185a43ea34
        public string matricula { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public Guid IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }
    }
}
