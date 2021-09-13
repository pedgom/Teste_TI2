using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using teste.Models;

namespace teste.Data
{
    /// <summary>
    /// classe para recolher os dados particulares dos Utilizadores
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }

        public string Fotografia { get; set; }

        public DateTime RegisterTime { get; set; }


    }

    /// <summary>
    /// criação da BD do projeto
    /// </summary>
   

    public class Teste : IdentityDbContext<ApplicationUser>
    {

        public Teste(DbContextOptions<Teste> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Bebidas> Bebidas { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Imagens> Imagens { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservas>()
                .HasKey(k => new { k.ClienteFK, k.BebidaFK });

            modelBuilder.Entity<Bebidas>()
                .Property(p => p.Preco)
                .HasColumnType("decimal (18,4)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
