using LivrariaNerd.Domain.Entities;
using System.Collections.Generic;

namespace LivrariaNerd.Infra.Data.Interface
{
    public interface ICidadeRepository : IBaseRepositoryAsync<Cidade>
    {

        List<Cidade> ObterTodosPeloEstado(int idEstado);

        List<Cidade> ObterTodos(string busca);
    }
}
