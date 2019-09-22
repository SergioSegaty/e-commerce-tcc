namespace Model.Entities
{
    public class Estoque : Base
    {
        public Produto Produto { get; set; }

        public int IdProduto { get; set; }

        public int Quantidade { get; set; }

        public string Status { get; set; }
    }
}