namespace Model.Entities
{
    public class Endereco : Base
    {
        public int IdCidade { get; set; }

        public Cidade Cidade { get; set; }

        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }
    }
}
