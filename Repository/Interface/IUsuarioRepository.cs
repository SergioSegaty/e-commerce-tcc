using PadawanStore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadawanStore.Infra.Data.Interface
{
    public interface IUsuarioRepository
    {
        Usuario ValidarLogin(string login, string senha);
    }
}
