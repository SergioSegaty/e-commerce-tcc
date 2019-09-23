using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadawanStore.Domain.Identity
{
    [Table("privilegios")]
    public class Privilegio : IdentityRole<int>
    {
        public List<UsuarioPrivilegio> UsuarioPrivilegios{ get; set; }
    }
}