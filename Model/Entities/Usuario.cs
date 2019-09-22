using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("usuarios")]
    public class Usuario : Base
    {
        [Column("nome"), StringLength(100, ErrorMessage = "No maximo 100 caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("login"), StringLength(25, ErrorMessage = "No maximo 25 caracteres.", MinimumLength = 5)]
        public string Login { get; set; }

        [Column("senha"), StringLength(50, ErrorMessage = "No maximo 50 caracteres.", MinimumLength = 5)]
        public string Senha { get; set; }

        [Column("quantidade_de_vezes_senha_errada")]
        public int QuantidadeDeVezesSenhaErrada { get; set; }

        public ICollection<Endereco> Endereco { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}