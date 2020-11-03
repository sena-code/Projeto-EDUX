﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<ObjetivoAluno> ObjetivosAlunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }
        public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }
        public DbSet<Curtida> Curtidas { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source = .\SQLEXPRESS; Initial Catalog = eduxcorrigido; User ID = sa; Password = sa132;");
        }



    }
}
