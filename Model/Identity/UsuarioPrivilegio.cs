using Microsoft.AspNetCore.Identity;

namespace PadawanStore.Domain.Identity
{
    public class UsuarioPrivilegio : IdentityRole<int>
    {
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }

        public Privilegio Privilegio { get; set; }
        public int IdPrivilegio { get; set; }
    }
}
