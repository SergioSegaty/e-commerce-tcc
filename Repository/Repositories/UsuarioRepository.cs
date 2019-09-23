﻿using PadawanStore.Domain.Identity;
using PadawanStore.Infra.Data.Context;
using PadawanStore.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PadawanStore.Infra.Data.Repositories
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
            return context.Usuarios.FirstOrDefault(x => x.Login == login && x.Senha == senha && x.RegistroAtivo);
        }
    }
}
