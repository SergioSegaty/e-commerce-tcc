using LivrariaNerd.Domain.Entities;
using System.Collections.Generic;

namespace LivrariaNerd.Infra.Data.Interface
{
    public interface IEstoqueRepository
    {
        Estoque ObterPeloId(int id);

        List<Estoque> ObterTodosPeloProduto(int idProduto);

        List<Estoque> ObterTodos(string status);
    }
}
