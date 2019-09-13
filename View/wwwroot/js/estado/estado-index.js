$(() => {
    $id = -1;

    ObterTodos = function () {
        $.ajax({
            url: '/estado/obtertodos',
            method: 'get',
            success: function (data) {

                $('#tabela-estados').empty();

                for (let i = 0; i < data.length; i++) {
                    let id = data[i].id;
                    let nome = data[i].nome;
                    let sigla = data[i].sigla;

                    var tr = document.createElement('tr');

                    var tdId = document.createElement('td');
                    tdId.innerHTML = id;

                    var tdSigla = document.createElement('td');
                    tdSigla.innerHTML = sigla;

                    var tdNome = document.createElement('td');
                    tdNome.innerHTML = nome;

                    var tdAcao = document.createElement('td');

                    var botaoEditar = document.createElement('a');
                    botaoEditar.innerHTML = 'Editar';
                    botaoEditar.classList.add('btn', 'btn-primary', 'botao-editar');
                    botaoEditar.style = "color: white; margin-right: 50px";
                    botaoEditar.setAttribute('data-id', id);

                    tdAcao.append(botaoEditar);

                    var botaoApagar = document.createElement('a');
                    botaoApagar.innerHTML = 'Apagar';
                    botaoApagar.classList.add('btn', 'btn-danger', 'botao-apagar');
                    botaoApagar.style = "color: white;margin-left: 50px;";
                    botaoApagar.setAttribute('data-id', id);

                    tdAcao.append(botaoApagar);

                    tr.append(tdId);
                    tr.append(tdSigla);
                    tr.append(tdNome);
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
        $sigla = $('#campo-sigla').val();
        $nome = $('#campo-nome').val();

        if ($id == -1) {
            cadastrar();
        } else {
            editar();
        }
    });

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
                ObterTodos();
                $('#cadastro-modal-estado').modal('hide');
                $id = -1;
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

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
                ObterTodos();
                $('#cadastro-modal-estado').modal('hide');
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
                $('#campo-sigla').val(data.sigla);
                $('#campo-nome').val(data.nome);
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
                ObterTodos();
                $('#alert-apagar-estado').modal('hide');
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    limparCampos = function () {
        $('#campo-sigla').val("");
        $('#campo-nome').val("");
    }

    $('.close-modal').on('click', () => {
        limparCampos();
        $id = -1;   
    });

    $('.close').on('click', () => {
        limparCampos();
        $id = -1;
    });

    ObterTodos();
});