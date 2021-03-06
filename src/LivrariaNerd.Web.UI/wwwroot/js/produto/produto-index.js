﻿// JQuerry

$(function () {
    $idProduto = -1;
    $id = -1;
    $form = $('#form-cadastro-produto');
    $imageUplaod = $('.box');
    $busca = "";

    $('#campo-preco').maskMoney();

    // Image Drag&Drop Detection

    var isAdvancedUpload = function () {
        var div = document.createElement('div');
        return (('draggable' in div) || ('ondragstart' in div && 'ondrop' in div)) && 'FormData' in window && 'FileReader' in window;
    }();

    if (isAdvancedUpload) {

        var droppedFiles = false;

        $imageUplaod.on('drag dragstart dragover dragcenter dragleave drop', function (e) {

            e.preventDefault();
            e.stopPropagation();


        })

            .on('dragover dragcenter ', function () {

                $imageUplaod.addClass('is-dragover');

            })
            .on('dragleave dragend drop', function () {
                $imageUpload.removeClass('is-dragover');
            })
            .on('drop', function (e) {
                droppedFiles = e.originalEvent.dataTransfer.files;
            });

    }

    console.log("funcionou: " + isAdvancedUpload);

    $('#upload-imagem').on('change', function () {

        if ($('#upload-imagem').get(0).files.length === 0) {
            $('#popup-imagem').css('display', 'inline-block');
        } else {
            $('#popup-imagem').css('display', 'none');
        }

    });

    $("#botao-salvar-produto").on('click', () => {
        $valido = $form.valid();

        if ($('#upload-imagem').get(0).files.length === 0) {
            $('#popup-imagem').css('display', 'inline-block');
        } else {
            $('#popup-imagem').css('display', 'none');
        }


        if ($valido && $('#upload-imagem').get(0).files.length == 1) {

            if ($id == -1) {
                inserir();
                notifyAlert(1, 'Cadastrado com sucesso.', 2);
            } else {
                alterar();
                notifyAlert(1, 'Alterado com sucesso', 2);

                $("#id-produto-hidden").val($id);
                $("#form-cadastro-produto-upload-imagem").submit();
            }
        }

    });


    //Editar por botao
    $(".table").on('click', '.botao-editar', function () {

        $id = $(this).data('id');


        $.ajax({
            url: '/produto/obterpeloid?id=' + $id,
            method: 'get',
            success: function (data) {
                $('#campo-preco').val(data.preco);
                $('#campo-preco').maskMoney('mask');

                $('#campo-nome').val(data.nome);
                $('#campo-cor').val(data.cor);
                $('#campo-imagem').val(data.imagem);
                $('#campo-peso').val(data.peso);
                $('#campo-descricao').val(data.descricao);
                $('#cadastro-modal-produto').modal('show');

                PreencherSelect(data.idCategoria);
            }
        });

    });


    //Alerta Modal
    $('.table').on('click', '.botao-apagar', function () {
        $id = $(this).data('id');
        $('#alert-apagar-produto').modal('show');
    });

    //Apagar por botao
    $('#btn-apagar-produto').on('click', () => {

        $.ajax({
            url: '/estoque/obterpeloidproduto?idProduto=' + $id,
            method: 'get',
            success: function (data) {
                let idEstoque = data.id;
                console.log('Apagou Estoque');
                $.ajax({
                    url: '/estoque/apagar?id=' + idEstoque,
                    method: 'get',
                    success: function (data) {
                        console.log('Apagou Produto');
                        $.ajax({
                            url: '/produto/apagar?id=' + $id,
                            method: 'get',
                            success: function (data) {
                                notifyAlert(1, "Produto apagado com sucesso!", 1);
                                $id = -1;
                                $('#alert-apagar-produto').modal('hide');
                                obterTodos($busca);
                                debugger;
                            }
                        });
                    }
                });
            }
        });

    });

    //Campo Buscar
    $('#buscar-produto').on('keyup', function () {
        $busca = $(this).val();
        obterTodos($busca);
    });

    //Limpar Campos
    limparCampos = function () {

        $('#campo-nome').val("");
        $('#campo-select-categoria').val(-1);
        $('#campo-preco').val("");
        $('#campo-cor').val("");
        $('#campo-peso').val("");
        $('#campo-descricao').val("");
    }


    // Inserir
    inserir = function () {

        $nome = $('#campo-nome').val();
        $idCategoria = $('#campo-select-categoria').val();
        $preco = $('#campo-preco').maskMoney('unmasked')[0];
        $cor = $('#campo-cor').val();
        $imagem = $('#box-imagem').val();
        $peso = $('#campo-peso').val();
        $descricao = $('#campo-descricao').val();

        $.ajax({

            url: '/produto/adicionar',
            method: 'post',
            data: {
                Nome: $nome,
                IdCategoria: $idCategoria,
                Preco: $preco,
                Cor: $cor,
                Imagem: $imagem,
                Peso: $peso,
                Descricao: $descricao
            },
            success: function (data) {
                $id = data.id;

                $("#id-produto-hidden").val($id);
                $("#form-cadastro-produto-upload-imagem").submit();

                $.ajax({

                    url: '/estoque/adicionar',
                    method: 'post',
                    data: {
                        IdProduto: $id,
                        Quantidade: 1,
                        Status: 'Em Estoque',
                    },
                    success: function (data) {
                        $idProduto = -1;
                        notifyAlert(1, 'Cadastrado com sucesso', 2);
                    }
                });

                obterTodos($busca);
                $id = -1;
                $('#cadastro-modal-produto').modal('hide');
                limparCampos();

            },
            error: function () {
                notifyAlert(3, 'Errro ao Cadastrar Produto', 2);
            }

        });


    }

    // Alterar
    alterar = function () {

        $nome = $('#campo-nome').val();
        $idCategoria = $('#campo-select-categoria').val();
        $preco = $('#campo-preco').maskMoney('unmasked')[0];
        debugger;
        $cor = $('#campo-cor').val();
        $imagem = $('#box-imagem').val();
        $peso = $('#campo-peso').val();
        $descricao = $('#campo-descricao').val();

        $.ajax({

            url: '/produto/alterar',
            method: 'post',
            data: {
                Id: $id,
                Nome: $nome,
                IdCategoria: $idCategoria,
                Preco: $preco,
                Cor: $cor,
                Imagem: $imagem,
                Peso: $peso,
                Descricao: $descricao
            },
            success: function (data) {
                obterTodos($busca);
                $id = -1;
                $('#cadastro-modal-produto').modal('hide');
                limparCampos();
            },
        });
    }

    // ObterTodos
    obterTodos = function (busca) {
        $('#lista-produtos').empty();
        $.ajax({
            url: '/produto/obtertodos',
            method: 'get',
            data: {
                busca: busca
            },
            success: function (data) {

                for (let i = 0; i < data.length; i++) {
                    let _data = data[i];
                    var tr = document.createElement('tr');

                    var tdImagem = document.createElement('td');
                    var img = document.createElement('img');
                    img.setAttribute('src', _data.imagemCaminhoWwwroot);
                    img.setAttribute('width', '90');
                    img.setAttribute('height', '90');

                    tdImagem.appendChild(img);

                    var tdId = document.createElement('td');
                    tdId.innerHTML = _data.id;

                    var tdNome = document.createElement('td');
                    tdNome.innerHTML = _data.nome;

                    var tdCategoria = document.createElement('td');
                    tdCategoria.innerHTML = _data.categoria.nome;

                    var tdPreco = document.createElement('td');
                    var index = _data.preco.toString().length;


                    tdPreco.innerHTML = "R$ " + _data.precoString.toString();
                    index = 0;

                    var botaoEditar = document.createElement("button");

                    botaoEditar.classList.add("btn", "btn-primary", "mr-2", "botao-editar");
                    botaoEditar.innerHTML = "<i class=\"fas fa-edit\"></i>";
                    botaoEditar.setAttribute("data-id", _data.id);
                    botaoEditar.setAttribute('data-toggle', 'tooltip');
                    botaoEditar.setAttribute('title', 'Editar Produto: ' + _data.nome);


                    var botaoApagar = document.createElement("button");
                    botaoApagar.innerHTML = 'Apagar';
                    botaoApagar.classList.add('btn', 'btn-danger', 'botao-apagar');
                    botaoApagar.innerHTML = "<i class=\"fas fa-trash\"> </i>";
                    botaoApagar.setAttribute('data-id', _data.id);
                    botaoApagar.setAttribute('data-toggle', 'tooltip');
                    botaoApagar.setAttribute('title', 'Apagar Produto: ' + _data.nome);

                    var tdAcao = document.createElement('td');

                    tdAcao.appendChild(botaoEditar);
                    tdAcao.appendChild(botaoApagar);

                    tr.appendChild(tdImagem);
                    tr.appendChild(tdId);
                    tr.appendChild(tdNome);
                    tr.appendChild(tdPreco);
                    tr.appendChild(tdCategoria);
                    tr.appendChild(tdAcao);

                    document.getElementById('lista-produtos').append(tr);
                    console.log(_data);

                }

            },
            error: function () {
                notifyAlert(2, 'Erro ao obter os produtos', 2);
            }

        })
    }



    $('#botao-cadastrar-produto').on('click', () => {
        PreencherSelect(-1);
        limparCampos();
        $id = -1;
    })

    PreencherSelect = function (idCategoria) {

        $('#campo-select-categoria').empty();

        let option = document.createElement('option');
        option.disabled = true;
        option.selected = true;
        option.value = -1;
        option.innerHTML = 'Selecione uma Categoria';

        document.getElementById('campo-select-categoria').appendChild(option);


        $.ajax({

            url: '/categoria/obtertodos',
            method: 'get',
            success: function (data) {

                for (let i = 0; i < data.length; i++) {

                    let _data = data[i];

                    let option = document.createElement('option');
                    if (idCategoria != -1 && _data.id == idCategoria) {
                        option.selected = true;
                    }
                    option.value = _data.id;
                    option.innerHTML = _data.nome;

                    document.getElementById('campo-select-categoria').appendChild(option);

                }
            }

        });

    }

    obterTodos($busca);

});
