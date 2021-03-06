﻿$(() => {
    $id = -1;
    $busca = "";

    ObterTodos = function (busca) {
        $.ajax({
            url: '/estado/obtertodosbusca',
            method: 'get',
            data: {
                busca: busca
            },
            success: function (data) {

                $('#tabela-estados').empty();

                for (let i = 0; i < data.length; i++) {
                    let _data = data[i];

                    let tr = document.createElement('tr');

                    let tdId = document.createElement('td');
                    tdId.innerHTML = _data.id;

                    let tdSigla = document.createElement('td');
                    tdSigla.innerHTML = _data.sigla;

                    let tdNome = document.createElement('td');
                    tdNome.innerHTML = _data.nome;

                    let tdAcao = document.createElement('td');

                    let botaoEditar = document.createElement('a');
                    botaoEditar.innerHTML = '<i class=\"fas fa-edit\"></i>';
                    botaoEditar.classList.add('btn', 'btn-primary', 'botao-editar');
                    botaoEditar.style = "color: white; margin-right: 5px";
                    botaoEditar.setAttribute('data-id', _data.id);
                    botaoEditar.setAttribute('data-toggle', 'tooltip');
                    botaoEditar.setAttribute('title', 'Editar Estado: ' + _data.nome);

                    tdAcao.append(botaoEditar);

                    var botaoApagar = document.createElement('a');
                    botaoApagar.innerHTML = '<i class=\"fas fa-trash\"></i>';
                    botaoApagar.classList.add('btn', 'btn-danger', 'botao-apagar');
                    botaoApagar.style = "color: white;margin-left: 5px;";
                    botaoApagar.setAttribute('data-id', _data.id);
                    botaoApagar.setAttribute('data-toggle', 'tooltip');
                    botaoApagar.setAttribute('title', 'Apagar Estado: ' + _data.nome);

                    tdAcao.append(botaoApagar);

                    tr.append(tdId);
                    tr.append(tdNome);
                    tr.append(tdSigla);
                    tr.append(tdAcao);

                    document.getElementById('tabela-estados').append(tr);
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    $('#btn-cadastrar').on('click', function () {
        $sigla = $('#campo-sigla-estado').val();
        $nome = $('#campo-nome-estado').val();

        if ($('#cadastro-estado-form').valid()) {
            if ($id === -1) {
                cadastrar();
            } else {
                editar();
            }
        }
    });

    cadastrar = function () {
        $.ajax({
            url: '/estado/adicionar',
            method: 'post',
            data: {
                Nome: $nome,
                Sigla: $sigla
            },
            success: function (data) {
                limparCampos();
                ObterTodos($busca);
                $id = -1;
                $('#cadastro-modal-estado').modal('hide');
                notifyAlert(1, 'Cadastrado com sucesso!', 2);
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    editar = function () {
        $.ajax({
            url: '/estado/alterar',
            method: 'post',
            data: {
                Id: $id,
                Nome: $nome,
                Sigla: $sigla
            },
            success: function (data) {
                limparCampos();
                ObterTodos($busca);
                $('#cadastro-modal-estado').modal('hide');
                $id = -1;
                notifyAlert(1, 'Alterado com sucesso!', 2);
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    $('#tabela-estados').on('click', '.botao-apagar', function () {
        $id = $(this).data('id');

        $('#alert-apagar-estado').modal('show');
    });

    $('#tabela-estados').on('click', '.botao-editar', function () {
        $id = $(this).data('id');

        $.ajax({
            url: '/estado/obterpeloid?id=' + $id,
            method: 'get',
            success: function (data) {
                $('#campo-sigla-estado').val(data.sigla);
                $('#campo-nome-estado').val(data.nome);
                $('#cadastro-modal-estado').modal('show');
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $('#btn-apagar-estado').on('click', function () {
        $.ajax({
            url: '/estado/apagar?id=' + $id,
            method: 'get',
            success: function (data) {
                ObterTodos($busca);
                $('#alert-apagar-estado').modal('hide');
                notifyAlert(1, 'Apagado com sucesso!', 2);
                $id = -1;
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    limparCampos = function () {
        $('#campo-sigla-estado').val("");
        $('#campo-nome-estado').val("");
    }

    $('.close-modal').on('click', () => {
        limparCampos();
        $id = -1;
    });

    $('.close').on('click', () => {
        limparCampos();
        $id = -1;
    });

    $('#buscar-produto').on('keyup', function () {
        $busca = $(this).val();
        ObterTodos($busca);
    });

    ObterTodos($busca);
});