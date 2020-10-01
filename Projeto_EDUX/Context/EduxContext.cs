using Microsoft.EntityFrameworkCore;
using Projeto_EDUX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_EDUX.Context
{
    public class EduxContext : DbContext
    {
        public DbSet<Dica> Dicas { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
<<<<<<< HEAD
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
=======
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
>>>>>>> 9ed6b089379833bf8ea210854eda5ca23d1e053e

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source = .\SQLEXPRESS; Initial Catalog = edux; User ID = sa; Password = sa132");
        }



    }
}
