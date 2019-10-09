using LivrariaNerd.Domain.Entities;
using System.Collections.Generic;

namespace LivrariaNerd.Infra.Data.Interface
{
    public interface ICidadeRepository
    {
        Cidade ObterPeloId(int id);

        List<Cidade> ObterTodosPeloEstado(int idEstado);

        List<Cidade> ObterTodos(string busca);
    }
}
