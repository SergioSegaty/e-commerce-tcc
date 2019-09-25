using LivrariaNerd.Domain.Entities;
using System.Collections.Generic;

namespace LivrariaNerd.Infra.Data.Interface
{
    public interface IEnderecoRepository
    {
        Endereco ObterPeloId(int id);

        List<Endereco> ObterTodosPelaCidade(int idCidade);

        List<Endereco> ObterTodosPeloUsuario(int idUsuario);
    }
}
