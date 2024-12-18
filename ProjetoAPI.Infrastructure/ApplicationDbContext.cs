﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoAPI.Domain.Entities;
using System.Reflection.Emit;


namespace ProjetoAPI.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Livro> Livro { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Livro>()
                .HasMany(l => l.Autores)
                .WithMany(a => a.Livros)
                .UsingEntity(j => j.ToTable("LivroAutor"));

            builder.Entity<Livro>()
                .HasMany(l => l.Assuntos)
                .WithMany(s => s.Livros)
                .UsingEntity(j => j.ToTable("LivroAssunto"));

            builder.Entity<ViewRelatorio>()
                .ToView("view_relatorio")
                .HasKey(v => v.LivroId);
        }
    }
}
