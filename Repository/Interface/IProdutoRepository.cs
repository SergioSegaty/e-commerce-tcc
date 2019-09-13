using System.Collections.Generic;
using Model.Entities;

namespace Repository.Interface
{
    public interface IProdutoRepository
    {

        Produto ObterPeloId(int id);

        List<Produto> ObterTodosPelaCategoria(int idCategoria);

        List<Produto> ObterTodos();
    }
}