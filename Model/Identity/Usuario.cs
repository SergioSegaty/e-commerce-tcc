using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PadawanStore.Domain.Identity
{
    public class Usuario : Base
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public string NomeCompleto { get; set; }
    }
}