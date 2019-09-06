using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("produtos")]
    public class Produto : Base
    {
        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        [Column("nome"), StringLength(100, ErrorMessage = "No maximo 100 caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("altura")]
        public double Altura { get; set; }

        [Column("largura")]
        public double Largura { get; set; }

        [Column("comprimento")]
        public double Comprimento { get; set; }

        [Column("peso")]
        public double Peso { get; set; }
    }
}