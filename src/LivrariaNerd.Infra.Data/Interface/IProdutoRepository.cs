using LivrariaNerd.Domain.Entities;
using System.Collections.Generic;

namespace LivrariaNerd.Infra.Data.Interface
{
    public interface IProdutoRepository
    {

        Produto ObterPeloId(int id);

        List<Produto> ObterTodosPelaCategoria(int idCategoria);

        List<Produto> ObterTodos();
    }
}