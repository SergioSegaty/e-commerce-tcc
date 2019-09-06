using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    interface IEnderecoRepository
    {
        Endereco ObterPeloId(int id);

        List<Endereco> ObterTodosPelaCidade(int idCidade);

        List<Endereco> ObterTodosPeloUsuario(int idUsuario);
    }
}
