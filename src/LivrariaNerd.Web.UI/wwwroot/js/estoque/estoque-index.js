$id = -1;
$idProduto = -1;

$(function () {
    var status = '*';
    var x = FooTable.init('#tabela-estoque', {
        "columns": [
            { "name": "id", "title": "Código", "breakpoints": "xs sm", "type": "number", "style": { "width": 122, "maxWidth": 80 } },
            { "name": "nomeProduto", "title": "Nome", "type": "text", "style": { "width": 167, "maxWidth": 80 } },
            { "name": "quantidade", "title": "Quantidade", "type": "number", "style": { "width": 130, "maxWidth": 80, "text-align": "center" } },
            {
                "name": "status", "title": "Status", "type": "text", "style": { "width": 190, "maxWidth": 120, "text-align": "center" },
                "formatter": function (status) {
                    if (status === 'Em Estoque')
                        return '<td class="badge badge-table badge-success">' + status + '</td>'
                    else if (status === 'Esgotado')
                        return '<td class="badge badge-table badge-warning">' + status + '</td>'
                    else if (status === 'Suspenso')
                        return '<td class="badge badge-table badge-danger">' + status + '</td>'
                }
            },
            {
                "name": "id", "style": { "width": 45, "text-align": "center" }, "title": "Ação",
                "formatter": function (id) {
                    return '<button data-id="' + id + '" class="editar-estoque btn btn-primary mr-2"> <i class=\"fas fa-edit\"></i> </button>' + '<button data-id="' + id + '" class="apagar-estoque btn btn-danger ml-2"> <i class=\"fas fa-trash\"></i> </button>';
                }
            }
        ],
        "rows": $.get({
            url: '/estoque/obtertodosfootable?status=' + status,
            method: 'get'
        })
    });

    atualizarTabela = function () {
        $.ajax({
            url: '/estoque/obtertodosfootable?status=' + status,
            method: 'get',

        }).then(function (rows) {
            x.rows.load(rows);
        });
    }

    $('[name=status]').on('change', function () {
        var filter = $(this).val();
        status = filter;
        atualizarTabela();
    });


    $('#tabela-estoque').on('click', '.editar-estoque', function () {

        $id = $(this).data('id');

        $.ajax({
            url: 'estoque/obterpeloid?id=' + $id,
            method: 'get',
            success: function (data) {
                $campoStatus = $('#campo-status');
                // Seedando Status e Conferindo
                $idProduto = data.id;

                $('#campo-nome-produto').val(data.produto.nome);
                $('#campo-status').val(data.status);
                $('#campo-quantidade').val(data.quantidade);


                $('#editar-modal-estoque').modal('show');

            }


        });


    });

    $('#btn-editar-estoque').on('click', function () {
        $status = $('#campo-status').val();
        $quantidade = $('#campo-quantidade').val();
        $nomeProduto = $('#campo-nome-produto').val();


        $.ajax({
            url: '/estoque/alterar',
            method: 'post',
            data: {
                Id: $id,
                IdProduto: $idProduto,
                Status: $status,
                Quantidade: $quantidade

            },
            success: function (data) {
                notifyAlert(1, 'Alterado com Sucesso', 2);
                $('#editar-modal-estoque').modal("hide");
                $id = -1;
                $idProduto = -1;
                atualizarTabela();

            },
            err: function (data) {
                notifyAlert(2, 'Erro ao Alterar', 2);
            }

        });


    });



});
