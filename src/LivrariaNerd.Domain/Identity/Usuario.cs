using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaNerd.Domain.Identity
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

        [Column("imagem_caminho_completo")]
        public string CaminhoImagem { get; set; }

        [Column("imagem_shortcut")]
        public string ShortcutImagem { get; set; }
    }
}