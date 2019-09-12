// Jquery

$(function () {

    $id = -1;


    $(".table").on("click", ".botao-editar", function () {

        $id = $(this).data("id");


        $.ajax({

            url: '/categoria/obterpeloid' + $id,
            method: 'get',
            success: function (data) {
                $id = data.Id;
                $("#campo-nome").val
            }
        })

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
            url: '/categoria/update',
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
            url: '/categoria/store',
            data: {
                Nome: $nome,

            },
            success: function (data) {
                $id = -1;
                $("#modalEditarCategoria").modal("hide");
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

        $("#lista-categorias").emtpy();


        $.ajax({

            url: '/categoria/obtertodos',
            method: 'get',
            data: {
                busca: $busca
            },

            success: function (data) {

                for (var i = 0; i < data.lenght; i++) {
                    var dado = data[i];

                    var linha = document.createElement("tr");
                    var colunaCodigo = document.createElement("td");
                    colunaCodigo.innerHTML = dado.Id;

                    var colunaNome = document.createElement("td");
                    colunaNome.innerHTML = dado.Nome;

                    var colunaAcao = document.createElement("td");
                    var botaoEditar = document.createElement("button");

                    botaoEditar.classList.add("btn", "btn-primary", "mr-2", "botao-editar");
                    botaoEditar.innerHTML = "<i class=\"fas fa-pen\"></i> Editar";
                    botaoEditar.setAttribute("data-id", dado.Id);


                    var botaoApagar = document.createElement("button");

                    botaoApagar = document.createElement("button");

                    botaoApagar.classList.add("btn", "btn-warn", "mr-2", "botao-apagar");
                    botaoApagar.innerHTML = "<i class=\"fas fa-trash\"> </i> Apagar";
                    botaoApagar.setAttribute("data-id", dado.Id);


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

    obterTodos();
});