using LivrariaNerd.Domain.Identity;
using LivrariaNerd.Infra.Data.Context;
using LivrariaNerd.Infra.Data.Interface;
using System.Linq;

namespace LivrariaNerd.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private StoreContext context;

        public UsuarioRepository(StoreContext context)
        {
            this.context = context;
        }

        public Usuario ValidarLogin(string login, string senha)
        {
            //ToUpper pois o login nao eh case sensitive
            return context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Senha == senha && x.RegistroAtivo);
        }
    }
}
