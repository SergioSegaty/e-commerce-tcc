using PadawanStore.Domain.Entities;
using System.Collections.Generic;

namespace PadawanStore.Infra.Data.Interface
{
    public interface IProdutoRepository
    {

        Produto ObterPeloId(int id);

        List<Produto> ObterTodosPelaCategoria(int idCategoria);

        List<Produto> ObterTodos();
    }
}