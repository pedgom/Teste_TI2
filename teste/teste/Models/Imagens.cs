using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniqueDrinks.Models
{
    /// <summary>
    /// Fotografias das Bebidas
    /// </summary>
    public class Imagens
    {
        /// <summary>
        /// Idetificador das Fotos
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do ficheiro com a fotografia da Bebida
        /// </summary>
        public string Imagem { get; set; }


        // criação da FK que referencia a Bebida a quem a Foto pertence
        [ForeignKey(nameof(Bebida))]
        [Display(Name = "Bebida")]
        public int BebidaFK { get; set; }
        public Bebidas Bebida { get; set; }
    }
}
