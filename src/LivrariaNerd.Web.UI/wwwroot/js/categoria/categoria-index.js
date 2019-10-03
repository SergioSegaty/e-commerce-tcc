// Jquery

$(function () {

    $id = -1;

    // Botao Editar
    $(".table").on("click", ".botao-editar", function () {
        $id = $(this).data("id");


        $.ajax({

            url: '/categoria/obterpeloid?id=' + $id,
            method: 'get',
            success: function (data) {
                $id = data.id;
                $("#campo-nome").val(data.nome);
                $("#modalCadastroCategoria").modal("show");
            }
        })

    });

    // Abrir Alerta Deletar
    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $('#alert-apagar-categoria').modal('show');

    });

    // Botao Apagar no Alerta
    $("#btn-apagar-categoria").on('click', function () {
        $.ajax({
            url: '/categoria/apagar?id=' + $id,
            method: 'get',
            success: function (data) {
                obterTodos();
                notifyAlert(1, "Apagou com sucesso", 2);
                $('#alert-apagar-categoria').modal("hide");

            },
            error: function (data) {
                notifyAlert(2, "Erro no servidor", 2);
                console.log("Erro apagar");
            }
        });

    });

    // Botao Salvar no [Modal]
    $("#categoria-botao-salvar").on("click", function () {
        $form = $('#form-cadastro-categoria');

        var $validado = $form.valid();

        if ($validado == true) {
            if ($id == -1) {
                inserir();
            } else {
                alterar();
            }
        }
    });


    function alterar() {
        $nome = $('#campo-nome').val();
        $.ajax({
            method: 'post',
            url: '/categoria/alterar',
            data: {
                Nome: $nome,
                Id: $id
            },
            success: function (data) {
                $id = -1;
                $("#modalCadastroCategoria").modal("hide");
                notifyAlert(1, "Alterado com sucesso", 2);

                obterTodos();
                limparCampos();
            },
            error: function (data) {
                notifyAlert(2, "Erro no servidor", 2);
                console.log("ERROR");
            }
        });

    }

    function inserir() {
        $nome = $("#campo-nome").val();
        $.ajax({

            method: 'post',
            url: '/categoria/adicionar',
            data: {
                Nome: $nome

            },
            success: function (data) {
                $id = -1;
                $("#modalCadastroCategoria").modal("hide");
                obterTodos();
                notifyAlert(1, "Cadastrado com sucesso", 2);
                limparCampos();
            },
            error: function (data) {
                console.log("ERROR");
                notifyAlert(2, "Erro no servidor", 2);
            }
        })

    }


    function obterTodos() {

        $busca = $('#campo-busca').val();

        $("#lista-categorias").empty();

        $.ajax({
            url: '/categoria/obtertodos',
            method: 'get',
            data: {
            },

            success: function (data) {

                for (let i = 0; i < data.length; i++) {
                    var _data = data[i];

                    var linha = document.createElement("tr");

                    var colunaCodigo = document.createElement("td");
                    colunaCodigo.innerHTML = _data.id;

                    var colunaNome = document.createElement("td");
                    colunaNome.innerHTML = _data.nome;

                    var colunaAcao = document.createElement("td");
                    var botaoEditar = document.createElement("button");

                    botaoEditar.classList.add("btn", "btn-primary", "mr-2", "botao-editar");
                    botaoEditar.innerHTML = "<i class=\"fas fa-edit\"></i>";
                    botaoEditar.setAttribute("data-id", _data.id);
                    botaoEditar.setAttribute('data-toggle', 'tooltip');
                    botaoEditar.setAttribute('title', 'Editar Categoria: ' + _data.nome);


                    var botaoApagar = document.createElement("button");

                    botaoApagar = document.createElement("button");

                    botaoApagar.classList.add("btn", "btn-danger", "mr-2", "botao-apagar");
                    botaoApagar.innerHTML = "<i class=\"fas fa-trash\"></i>";
                    botaoApagar.setAttribute("data-id", _data.id);
                    botaoApagar.setAttribute('data-toggle', 'tooltip');
                    botaoApagar.setAttribute('title', 'Apagar Categoria: ' + _data.nome);

                    colunaAcao.appendChild(botaoEditar);
                    colunaAcao.appendChild(botaoApagar);

                    linha.appendChild(colunaCodigo);
                    linha.appendChild(colunaNome);
                    linha.appendChild(colunaAcao);

                    document.getElementById("lista-categorias").appendChild(linha);
                }
            },
            error: function (data) {
                console.log("Erro ao ObterTodos(Categoria)");
                error;
            }

        });
    }

    function limparCampos() {
        $("#campo-nome").val("");

    }



    obterTodos();
});