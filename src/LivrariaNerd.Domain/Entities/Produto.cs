using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaNerd.Domain.Entities
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

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("preco", TypeName = ("decimal(18,2)"))]
        public decimal Preco { get; set; }

        [Column("peso")]
        public int Peso { get; set; }

        [Column("cor")]
        public string Cor { get; set; }

        [Column("imagem_caminho_completo")]
        public string ImagemCaminhoCompleto { get; set; }

        [Column("imagem_caminho_wwwroot")]
        public string ImagemCaminhoWwwroot { get; set; }

        [NotMapped]
        public string PrecoString
        {
            get
            {
                return string.Format("{0:N}", Preco);
            }
        }
    }
}