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

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }

=======
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
>>>>>>> c4a095c887177572a87488693034a84a1215717f
        public DbSet<ObjetivoAluno> Objetivos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
<<<<<<< HEAD

=======
>>>>>>> c4a095c887177572a87488693034a84a1215717f

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source = .\SQLEXPRESS; Initial Catalog = edux; User ID = sa; Password = sa132");
        }



    }
}
