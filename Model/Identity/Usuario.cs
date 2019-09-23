using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PadawanStore.Domain.Identity
{
    public class Usuario : IdentityUser<int>
    {
        public string NomeCompleto { get; set; }

        public List<UsuarioPrivilegio> UsuarioPrivilegios { get; set; }
    }
}