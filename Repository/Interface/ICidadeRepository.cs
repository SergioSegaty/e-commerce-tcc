using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICidadeRepository
    {
        Cidade ObterPeloId(int id);

        List<Cidade> ObterTodosPeloEstado(int idEstado);

        List<Cidade> ObterTodos();
    }
}
