﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class AlunoTurma : BaseDomains
    {
        /// <summary>
        /// Define a classe alunoTurma
        /// </summary>
       
        public string matricula { get; set; }

    }
}
