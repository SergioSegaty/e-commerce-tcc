// Jquery

$(function () {

    $id = -1;


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


    $(".table").on("click", ".botao-apagar", function () {
        $id = $(this).data("id");
        $.ajax({
            url: '/categoria/apagar?id=' + $id,
            method: 'get',
            success: function (data) {
                obterTodos();
            },
            error: function (data) {
                console.log("Erro apagar");
            }
        });
    });


    $("#categoria-botao-salvar").on("click", function () {
        console.log("Clicou");


        if ($id == -1) {
            inserir();
        } else {
            alterar();
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
                obterTodos();
                limparCampos();
            },
            error: function (data) {
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
                limparCampos();
            },
            error: function (data) {
                console.log("ERROR");
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
                    var dado = data[i];

                    var linha = document.createElement("tr");

                    var colunaCodigo = document.createElement("td");
                    colunaCodigo.innerHTML = dado.id;

                    var colunaNome = document.createElement("td");
                    colunaNome.innerHTML = dado.nome;

                    var colunaAcao = document.createElement("td");
                    var botaoEditar = document.createElement("button");

                    botaoEditar.classList.add("btn", "btn-primary", "mr-2", "botao-editar");
                    botaoEditar.innerHTML = "<i class=\"fas fa-edit\"></i> Editar";
                    botaoEditar.setAttribute("data-id", dado.id);


                    var botaoApagar = document.createElement("button");

                    botaoApagar = document.createElement("button");

                    botaoApagar.classList.add("btn", "btn-danger", "mr-2", "botao-apagar");
                    botaoApagar.innerHTML = "<i class=\"fas fa-trash\"> </i> Apagar";
                    botaoApagar.setAttribute("data-id", dado.id);

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

    $(".table").on("click", ".botao-apagar", function () {

        $id = $(this).data("id");
        $.ajax({

            url: '/categoria/apagar/' + $id,
            method: 'get',
            success: function (data) {
                obterTodos();
            },
            error: function (data) {
                console.log("Deu erro");
            }
        });
    });

    obterTodos();
});