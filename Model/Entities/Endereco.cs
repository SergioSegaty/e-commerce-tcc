using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("enderecos")]
    public class Endereco : Base
    {
        [Column("id_cidade")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Column("cep"), StringLength(11, ErrorMessage = "No maximo 11 caracteres.", MinimumLength = 11)]
        public string CEP { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("bairro"), StringLength(100, ErrorMessage = "No maximo 100 caracteres.", MinimumLength = 3)]
        public string Bairro { get; set; }

        [Column("numero"), StringLength(10, ErrorMessage = "No maximo 10 digitos.", MinimumLength = 1)]
        public string Numero { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }
    }
}
