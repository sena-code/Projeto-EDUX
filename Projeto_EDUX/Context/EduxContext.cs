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
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source = VINICIUS\SQLEXPRESS; Initial Catalog = edux; User ID = sa; Password = sa132");
        }



    }
}