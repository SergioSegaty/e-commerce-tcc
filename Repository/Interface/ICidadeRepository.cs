using PadawanStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadawanStore.Infra.Data.Interface
{
    public interface ICidadeRepository
    {
        Cidade ObterPeloId(int id);

        List<Cidade> ObterTodosPeloEstado(int idEstado);

        List<Cidade> ObterTodos();
    }
}
