using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teste.Models
{
    /// <summary>
    ///  Categoria atribuida à Bebidas
    /// </summary>
    public class Categorias
    {
        // procurar as Bebidas de cada Categoria e criar, para cada Categoria, uma lista com as suas bebidas
        public Categorias()
        {
            ListaDeBebidas = new HashSet<Bebidas>();
        }

        /// <summary>
        /// Identificador de cada uma das Categorias
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// identifica o nome da Categoria
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Lista das Bebidas que são da Categoria
        /// </summary>
        public virtual ICollection<Bebidas> ListaDeBebidas { get; set; }

    }
}
