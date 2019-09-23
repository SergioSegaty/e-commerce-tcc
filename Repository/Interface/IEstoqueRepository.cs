using PadawanStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadawanStore.Infra.Data.Interface
{
    public interface IEstoqueRepository
    {
        Estoque ObterPeloId(int id);

        List<Estoque> ObterTodosPeloProduto(int idProduto);

        List<Estoque> ObterTodos();
    }
}
