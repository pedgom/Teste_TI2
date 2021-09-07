using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
    /// <summary>
    /// descrição de cada uma das Bebidas
    /// </summary>
    public class Bebidas
    {
        public Bebidas()
        {
            // inicializar a lista de Fotografias de cada uma das Bebidas
            ListaDeImagens = new HashSet<Imagens>();
            // inicializar a lista de Clientes das Reservas de Bebidas
            ListaDeReservas = new HashSet<Reservas>();
        }

        /// <summary>
        /// Identificador de cada Bebida
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da bebida
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição breve da bebida
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Preço da bebida
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Imagem referente à bebida
        /// </summary>
        public string Imagem { get; set; }


        /// <summary>
        /// Verificar se a bebida se encontra em stock
        /// </summary>
        public string Stock { get; set; }


        /// <summary>
        /// FK para a Categoria da bebida
        /// </summary>
        [ForeignKey(nameof(Categoria))]
        public int CategoriaFK { get; set; }
        public Categorias Categoria { get; set; }

        /// <summary>
        /// Lista das Reservas referentes às Bebidas
        /// </summary>
        public virtual ICollection<Reservas> ListaDeReservas { get; set; }

        /// <summary>
        /// Lista das Fotografias da bebida
        /// </summary>
        public virtual ICollection<Imagens> ListaDeImagens { get; set; }




    }
}

