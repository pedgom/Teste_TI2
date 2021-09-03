using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using teste.Models;

namespace teste.Data
{
    public class Teste : IdentityDbContext
    {
        public Teste(DbContextOptions<Teste> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Bebidas> Bebidas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Imagens> Imagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservas>()
                .HasKey(k => new { k.ClienteFK, k.BebidaFK });
        }
    }
}
