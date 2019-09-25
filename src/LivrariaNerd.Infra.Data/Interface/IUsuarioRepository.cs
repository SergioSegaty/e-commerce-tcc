using LivrariaNerd.Domain.Identity;

namespace LivrariaNerd.Infra.Data.Interface
{
    public interface IUsuarioRepository
    {
        Usuario ValidarLogin(string login, string senha);
    }
}
