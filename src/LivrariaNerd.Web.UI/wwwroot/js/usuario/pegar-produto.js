$(() => {
    $id = -1;
    // Pegando os elementos do DOM para alterar

    $categoriaTituloBC = document.getElementById('bc-titulo-produto');
    $imagemProduto = document.getElementById('imagem-produto');
    $nomeProduto = document.getElementById('nome-produto');
    $precoProduto = document.getElementById('preco-produto');
    $categoriaProduto = document.getElementById('categoria-produto');
    $tituloProduto = document.getElementById('titulo-produto');


    obterProduto = function () {

        $.ajax({
            url: 'produto/obterpeloid?=' + $id,
            method: 'get',
            success: function (data){
                if (data != null) {

                    $categoriaTituloBC.innerHtml = data.NomeCategoria;
                    $imagemProduto = "/" + data.imagemCaminhoWwwroot;
                    $nomeProduto.innerHtml = data.nome;
                    $precoProduto.innerHtml = data.preco;
                    $categoriaProduto.innerHtml = data.NomeCategoria;
                    $tituloProduto.innerHtml = data.nome;
                    
                } else {
                    notiftyAlert(3, 'Produto Não encontrado', 2);
                }
            },

        });

    };


});

