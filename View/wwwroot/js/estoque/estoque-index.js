jQuery(function ($) {
    $('#tabela-estoque').footable({
        "columns": [
            { "name": "id", "title": "Código", "breakpoints": "xs sm", "type": "number", "style": { "width": 80, "maxWidth": 80 } },
            { "name": "nomeProduto", "title": "Nome", "type": "text" },
            { "name": "quantidade", "title": "Quantidade", "type": "number", "style": { "width": 80, "maxWidth": 80, "text-align": "center" } },
            {
                "name": "status", "title": "Status", "type": "text", "style": { "width": 100, "maxWidth": 120, "text-align": "center" },
                "formatter": function (status) {
                    if (status === 'Em Estoque')
                        return '<td class="badge badge-table badge-success">'+status+'</td>'
                    else if (status === 'Esgotado')
                        return '<td class="badge badge-table badge-warning">'+status+'</td>'
                    else if (status === 'Suspenso')
                        return '<td class="badge badge-table badge-danger">'+status+'</td>'
                }
            },
        ],
        "rows": $.get({
            url: '/estoque/obtertodosfootable',
            method: 'get'
        })
    });

    $('[name=status]').on('change', function () {
        var filtering = FooTable.get('#tabela-estoque').use(FooTable.Filtering);
        var filter = $(this).val();
        if (filter === 'none') { // if the value is "none" remove the filter
            filtering.removeFilter('status');
        } else { // otherwise add/update the filter.
            filtering.addFilter('status', filter, ['status']);
        }
        filtering.filter();
    });

    $('')
});
