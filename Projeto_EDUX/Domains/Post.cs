using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto_EDUX.Domains
{
    public class Post : BaseDomains
    {
        public string Texto {get; set;}
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]

        public Usuario Usuario { get; set; }

        

        [NotMapped] //Não mapeia a propiedade no banco de dados 
        [JsonIgnore] //Ignora propiedade no retorno no Json

        public IFormFile Imagem { get; set; } 
        public string UrlImagem { get; set; }
        



    }
}
