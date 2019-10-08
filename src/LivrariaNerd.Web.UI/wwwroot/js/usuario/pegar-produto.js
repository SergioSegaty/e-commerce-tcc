$(() => {

    // $('#rating-example').raty();

    $('#adicionar-carrinho').on('click', function () {
        $idProduto = $(this).data('id');

        $.ajax({
            url: '/produto/obterpeloid?id=' + $idProduto,
            method: 'get',
            success: function (data) {
                $.ajax({
                    url: '/pedido/adicionaraocarrinho',
                    method: 'post',
                    data: data,
                    success: function (data) {
                        notifyAlert(1, 'Produto adicionado ao carrinho', 2);
                    }
                });
            }
        });
    });
});

