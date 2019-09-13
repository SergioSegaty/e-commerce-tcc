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

    $("#btn-cadastrar").on('click', () => {
        if ($id == -1) {
            inserir();
        } else {
            alterar();
        }
    });

    $('#abrir-modal-cadastro').on('click', () => { PreencherSelectEstados(-1); });

    PreencherSelectEstados = function (idEstado) {
        $('#campo-estado').empty();

        let option = document.createElement('option');
        option.disabled = true;
        option.selected = true;
        option.value = -1;
        option.innerHTML = 'Selecione um Estado'

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
        $nome = $("#campo-nome").val();
        $idEstado = $("#campo-estado").val();

        $.ajax({
            url: '/cidade/adicionar',
            method: 'post',
            data: {
                Nome: $nome,
                IdEstado: $idEstado
            },
            success: function () {
                obterTodos();
                $id = -1;
                $('#cadastro-modal').modal('hide');
                limparCampos();
            }
        });
    }

    alterar = function () {
        $nome = $("#campo-nome").val();
        $idEstado = $("#campo-estado").val();

        $.ajax({
            url: '/cidade/alterar',
            method: 'post',
            data: {
                Id: $id,
                Nome: $nome,
                IdEstado: $idEstado
            },
            success: function () {
                obterTodos();
                $id = -1;
                $('#cadastro-modal').modal('hide');
                limparCampos();
            }
        });
    }

    limparCampos = function () {
        $('#campo-nome').val("");
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
                    botaoEditar.innerHTML = 'Editar';
                    botaoEditar.classList.add('btn', 'btn-primary', 'botao-editar');
                    botaoEditar.style = "color: white; margin-right: 50px";
                    botaoEditar.setAttribute('data-id', _data.id);

                    tdAcao.append(botaoEditar);

                    var botaoApagar = document.createElement('a');
                    botaoApagar.innerHTML = 'Apagar';
                    botaoApagar.classList.add('btn', 'btn-danger', 'botao-apagar');
                    botaoApagar.style = "color: white;margin-left: 50px;";
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
                $('#campo-nome').val(data.nome);
                PreencherSelectEstados(data.idEstado);
                $('#cadastro-modal').modal('show');
            }
        });
    });

    $('#tabela-cidades').on('click', '.botao-apagar', function() {
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
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    obterTodos();
});