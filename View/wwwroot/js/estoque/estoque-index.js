jQuery(function ($) {

    $('#tabela-estoque').footable({
        "columns": [
            { "name": "id", "title": "Código", "breakpoints": "xs sm", "type": "number", "style": { "width": 80, "maxWidth": 80 } },
            { "name": "nomeProduto", "title": "Nome", "type": "text" },
            { "name": "status", "title": "Status", "type": "text" },
            { "name": "quantidade", "title": "Quantidade", "type": "number", "style": { "width": 80, "maxWidth": 80, "text-align": "center" } }
        ],
        "rows": $.ajax({
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
});


