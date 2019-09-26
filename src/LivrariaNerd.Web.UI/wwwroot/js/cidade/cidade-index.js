$(() => {
    $id = -1;

    $('.close-modal').on('click', () => {
        limparCampos();
        $id = -1;
    });

    $('.close').on('click', () => {
        limparCampos();
        $id = -1;
    });

    $("#btn-cadastrar-cidade").on('click', () => {
        $nome = $("#campo-nome-cidade").val();
        $idEstado = $("#campo-estado").val();

        if ($('#cadastro-cidade-form').valid()) {
            if ($id == -1) {
                inserir();
            } else {
                alterar();
            }
        }
    });

    $('#abrir-modal-cadastro').on('click', () => { PreencherSelectEstados(-1); });

    PreencherSelectEstados = function (idEstado) {
        $('#campo-estado').empty();

        let option = document.createElement('option');
        option.disabled = true;
        option.selected = true;
        option.value = -1;
        option.innerHTML = 'Selecione um Estado';


        document.getElementById('campo-estado').appendChild(option);

        $.ajax({
            url: '/estado/obtertodos',
            type: 'get',
            success: function (data) {
                for (let i = 0; i < data.length; i++) {
                    let _data = data[i];

                    let option = document.createElement('option');
                    if (idEstado != -1 && _data.id == idEstado) {
                        option.selected = true;
                    }
                    option.value = _data.id;
                    option.innerHTML = _data.nome;

                    document.getElementById('campo-estado').appendChild(option);
                }
            }
        });
    }

    inserir = function () {
        $.ajax({
            url: '/cidade/adicionar',
            method: 'post',
            data: {
                Nome: $nome,
                IdEstado: $idEstado
            },
            success: function (data) {
                obterTodos();
                limparCampos();
                $id = -1;
                $('#cadastro-modal-cidade').modal('hide');
                notifyAlert(1, 'Cadastrado com Sucesso!', 2);
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    alterar = function () {
        $.ajax({
            url: '/cidade/alterar',
            method: 'post',
            data: {
                Id: $id,
                Nome: $nome,
                IdEstado: $idEstado
            },
            success: function (data) {
                obterTodos();
                limparCampos();
                $id = -1;
                $('#cadastro-modal-cidade').modal('hide');
                notifyAlert(1, 'Alterado com Sucesso!', 2);
            },
            error: function (err) {
            }
        });
    }

    limparCampos = function () {
        $('#campo-nome-cidade').val("");
        $('#campo-estado').val(-1);
    }

    obterTodos = function () {
        $("#tabela-cidades").empty();

        $.ajax({
            url: '/cidade/obtertodos',
            method: 'get',
            success: function (data) {
                for (let i = 0; i < data.length; i++) {
                    let _data = data[i];

                    var tr = document.createElement('tr');

                    var tdId = document.createElement('td');
                    tdId.innerHTML = _data.id;

                    var tdNome = document.createElement('td');
                    tdNome.innerHTML = _data.nome;

                    var tdAcao = document.createElement('td');

                    var tdSigla = document.createElement('td');
                    tdSigla.innerHTML = _data.estado.sigla;

                    var botaoEditar = document.createElement('a');
                    botaoEditar.innerHTML = '<i class=\"fas fa-edit\"></i>';
                    botaoEditar.classList.add('btn', 'btn-primary', 'botao-editar');
                    botaoEditar.style = "color: white; margin-right: 5px";
                    botaoEditar.setAttribute('data-id', _data.id);

                    tdAcao.append(botaoEditar);

                    var botaoApagar = document.createElement('a');
                    botaoApagar.innerHTML = '<i class=\"fas fa-trash\"></i>';
                    botaoApagar.classList.add('btn', 'btn-danger', 'botao-apagar');
                    botaoApagar.style = "color: white;margin-left: 5px;";
                    botaoApagar.setAttribute('data-id', _data.id);

                    tdAcao.append(botaoApagar);

                    tr.append(tdId);
                    tr.append(tdNome);
                    tr.append(tdSigla);
                    tr.append(tdAcao);

                    document.getElementById('tabela-cidades').append(tr);
                }
            }
        });
    }

    $('#tabela-cidades').on('click', '.botao-editar', function () {
        $id = $(this).data('id');
        $.ajax({
            url: '/cidade/obterpeloid',
            data: {
                id: $id
            },
            method: 'get',
            success: function (data) {
                $('#campo-nome-cidade').val(data.nome);
                PreencherSelectEstados(data.idEstado);
                $('#cadastro-modal-cidade').modal('show');
            }
        });
    });

    $('#tabela-cidades').on('click', '.botao-apagar', function () {
        $id = $(this).data('id');
        $('#alert-apagar-cidade').modal('show');
    });

    $('#btn-apagar-cidade').on('click', function () {
        $.ajax({
            url: '/cidade/apagar?id=' + $id,
            method: 'get',
            success: function (data) {
                obterTodos();
                $id = -1;
                $('#alert-apagar-cidade').modal('hide');
                notifyAlert(1, 'Apagou com Sucesso!', 2);
            },
            error: function (err) {
                console.log(err);   
            }
        });
    });

    obterTodos();
});