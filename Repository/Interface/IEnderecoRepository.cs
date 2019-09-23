using PadawanStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadawanStore.Infra.Data.Interface
{
    public interface IEnderecoRepository
    {
        Endereco ObterPeloId(int id);

        List<Endereco> ObterTodosPelaCidade(int idCidade);

        List<Endereco> ObterTodosPeloUsuario(int idUsuario);
    }
}
