$(function () {

    $idStoreOrEditEstoque

    $('#tabela-estoque').select2({
        ajax: {
            url: '/estoque/obterTodos',
            dataType: 'json'
        }
    });
});