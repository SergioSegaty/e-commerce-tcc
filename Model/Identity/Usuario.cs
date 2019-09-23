using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadawanStore.Domain.Identity
{
    [Table("usuarios")]
    public class Usuario : Base
    {
        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("nome_completo")]
        public string NomeCompleto { get; set; }
    }
}