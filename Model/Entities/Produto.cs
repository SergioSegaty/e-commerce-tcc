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

        //[Column("id_marca")]
        //public int IdMarca { get; set; }

        //[ForeignKey("IdMarca")]
        //public Marca Marca { get; set; }

        [Column("nome"), StringLength(100, ErrorMessage = "No maximo 100 caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("preco")]
        public int Preco { get; set; }

        [Column("peso")]
        public int Peso { get; set; }

        [Column("cor")]
        public string Cor { get; set; }

        [Column("imagem")]
        public string Imagem { get; set; }
    }
}