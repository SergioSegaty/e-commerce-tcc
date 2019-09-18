using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("estoques")]
    public class Estoque : Base
    {
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        [Column("id_produto")]
        public int IdProduto { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }
}