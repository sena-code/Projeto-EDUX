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
<<<<<<< HEAD
        public DbSet<ObjetivoAluno> Objetivos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
=======
>>>>>>> 9ed6b089379833bf8ea210854eda5ca23d1e053e
>>>>>>> e6692e66ee0db39c289fba899009c67203cdf1a8

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source = .\SQLEXPRESS; Initial Catalog = edux; User ID = sa; Password = sa132");
        }



    }
}
