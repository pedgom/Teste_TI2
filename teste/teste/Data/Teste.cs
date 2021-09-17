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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // insert DB seed

            modelBuilder.Entity<Categorias>().HasData(
               new Categorias { Id = 1, Categoria = "Vinho" },
               new Categorias { Id = 2, Categoria = "Vinho do Porto" },
               new Categorias { Id = 3, Categoria = "Vinho Moscatel" },
               new Categorias { Id = 4, Categoria = "Whisky" },
               new Categorias { Id = 5, Categoria = "Gin e Vodka" },
               new Categorias { Id = 6, Categoria = "Rum e Tequila" },
               new Categorias { Id = 7, Categoria = "Cachaça e Aguardente" },
               new Categorias { Id = 8, Categoria = "Licores" },
           new Categorias { Id = 9, Categoria = "Champanhe e Espumante" },
           new Categorias { Id = 10, Categoria = "Cerveja e Cidra" }

            );

            modelBuilder.Entity<Clientes>().HasData(
               new Clientes { Id = 1, Nome = "Pedro Rafael", Email = "pr@pr.com", Contacto = 937492122, Datanasc = new DateTime(1995, 6, 15), Fotografia = "noUser.png" },
               new Clientes { Id = 2, Nome = "Jose Vieira", Email = "jv@jv.com", Contacto = 920562956, Datanasc = new DateTime(1994, 12, 9), Fotografia = "noUser.png" },
               new Clientes { Id = 3, Nome = "Maria Silva", Email = "ms@ms.com", Contacto = 914659935, Datanasc = new DateTime(1999, 5, 21), Fotografia = "noUser.png" },
               new Clientes { Id = 4, Nome = "Filipe Santos", Email = "fs@fs.com", Contacto = 936581003, Datanasc = new DateTime(1990, 8, 7), Fotografia = "noUser.png" },
               new Clientes { Id = 5, Nome = "Ana Sousa", Email = "as@as.com", Contacto = 962813384, Datanasc = new DateTime(1998, 2, 9), Fotografia = "noUser.png" },
               new Clientes { Id = 6, Nome = "Beatriz Pinto", Email = "bp@bp.com", Contacto = 961883421, Datanasc = new DateTime(1985, 10, 20), Fotografia = "noUser.png" },
               new Clientes { Id = 7, Nome = "Tiago Mendonça", Email = "tm@tm.com", Contacto = 917745362, Datanasc = new DateTime(1978, 3, 5), Fotografia = "noUser.png" }

            );

            modelBuilder.Entity<Bebidas>().HasData(
               new Bebidas { Id = 1, Nome = "Vinho Rose Mateus", Descricao = " MATEUS ROSÉ é um vinho leve, fresco, jovem e ligeiramente «pétillant»", Preco = 20, Stock = "Sim", CategoriaFK = 1 },
               new Bebidas { Id = 2, Nome = "Vinho do Porto Ferreira", Descricao = "É vinificado pelo método tradicional do vinho do Porto.", Preco = 30, Stock = "Sim", CategoriaFK = 2 },
               new Bebidas { Id = 3, Nome = "Veritas Moscatel", Descricao = "Vinho Moscatel de Setúbal", Preco = 10, Stock = "Sim", CategoriaFK = 3 },
               new Bebidas { Id = 4, Nome = "Grants Whisky", Descricao = "Grant’s é um whisky extraordinário e um dos mais complexos produzidos na Escócia.", Preco = 15, Stock = "Sim", CategoriaFK = 4 },
               new Bebidas { Id = 5, Nome = "Ciroc Vodka", Descricao = "Cîroc Vodka é uma marca de vodca eau-de-vie de luxo, fabricada com uvas da região Carântono-Marítimo, da França", Preco = 30, Stock = "Sim", CategoriaFK = 5 },
               new Bebidas { Id = 6, Nome = "Malibu Rum", Descricao = "Nada bate um original, e Malibu não é apenas o original, é o mais vendido rum do Caribe com sabor natural de coco ", Preco = 15, Stock = "Sim", CategoriaFK = 6 },
               new Bebidas { Id = 7, Nome = "Cachaça 51", Descricao = "Cachaça, o sabor e aroma perfeito da original caipirinha brasileira.", Preco = 11, Stock = "Sim", CategoriaFK = 7 },
               new Bebidas { Id = 8, Nome = "Moet&Chandon", Descricao = "Moet & Chandon, um champanhe de estilo único e elegante.", Preco = 50, Stock = "Sim", CategoriaFK = 9 },
               new Bebidas { Id = 9, Nome = "Super Bock Pack15", Descricao = "O sabor autêntico. Super Bock Original é a única cerveja portuguesa com 37 medalhas de ouro consecutivas", Preco = 7, Stock = "Sim", CategoriaFK = 10 }

            );

            modelBuilder.Entity<Imagens>().HasData(
               new Imagens { Id = 1, Imagem = "Vinho-Mateus-Rose.jpg", BebidaFK = 1 },
               new Imagens { Id = 2, Imagem = "ferreira_Porto.jpg", BebidaFK = 2 },
               new Imagens { Id = 3, Imagem = "veritas_moscatel.jpg", BebidaFK = 3 },
               new Imagens { Id = 4, Imagem = "grants_whisky.jpg", BebidaFK = 4 },
               new Imagens { Id = 5, Imagem = "ciroc_vodka.jpg", BebidaFK = 5 },
               new Imagens { Id = 6, Imagem = "malibu_rum.jpg", BebidaFK = 6 },
               new Imagens { Id = 7, Imagem = "51_cachaça.jpg", BebidaFK = 7 },
               new Imagens { Id = 8, Imagem = "moet_champanhe.jpg", BebidaFK = 8 },
               new Imagens { Id = 9, Imagem = "superBock.jpg", BebidaFK = 9 }

            );

            modelBuilder.Entity<Reservas>().HasData(
               new Reservas { Id = 1, DataReserva = DateTime.Now, DataEntrega = new DateTime(2022, 6, 19), Estado = "Entregue", Quantidade = 2, BebidaFK = 1, ClienteFK = 1 },
               new Reservas { Id = 2, DataReserva = DateTime.Now, DataEntrega = new DateTime(2021, 12, 19), Estado = "Entregue", Quantidade = 1, BebidaFK = 2, ClienteFK = 2 },
               new Reservas { Id = 3, DataReserva = DateTime.Now, DataEntrega = new DateTime(2022, 5, 23), Estado = "Entregue", Quantidade = 1, BebidaFK = 3, ClienteFK = 3 },
               new Reservas { Id = 4, DataReserva = DateTime.Now, DataEntrega = new DateTime(2022, 8, 9), Estado = "Entregue", Quantidade = 1, BebidaFK = 4, ClienteFK = 4 },
               new Reservas { Id = 5, DataReserva = DateTime.Now, DataEntrega = new DateTime(2021, 10, 23), Estado = "Entregue", Quantidade = 5, BebidaFK = 5, ClienteFK = 5 },
               new Reservas { Id = 6, DataReserva = DateTime.Now, DataEntrega = new DateTime(2021, 12, 3), Estado = "Entregue", Quantidade = 2, BebidaFK = 6, ClienteFK = 6 },
               new Reservas { Id = 7, DataReserva = DateTime.Now, DataEntrega = new DateTime(2022, 2, 13), Estado = "Entregue", Quantidade = 3, BebidaFK = 7, ClienteFK = 7 },
               new Reservas { Id = 8, DataReserva = DateTime.Now, DataEntrega = new DateTime(2022, 6, 24), Estado = "Entregue", Quantidade = 1, BebidaFK = 8, ClienteFK = 3 },
               new Reservas { Id = 11, DataReserva = DateTime.Now, DataEntrega = new DateTime(2022, 3, 8), Estado = "Entregue", Quantidade = 4, BebidaFK = 9, ClienteFK = 2 }
            );

        }



        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Bebidas> Bebidas { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Imagens> Imagens { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }

        
        }
    }
