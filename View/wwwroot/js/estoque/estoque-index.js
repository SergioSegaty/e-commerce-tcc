var status = {
    "statuses": [
        { "id": 1, "val": "em estoque" },
        { "id": 2, "val": "sem estoque" },
        { "id": 3, "val": "cancelado" },
    ]
};

jQuery(function ($) {
    $('#tabela-estoque').footable({
        "columns": [
            { "name": "id", "title": "Código", "breakpoints": "xs sm", "type": "number", "style": { "width": 80, "maxWidth": 80 } },
            { "name": "", "title": "Nome", "type": "text" },
            { "name": "quantidade", "title": "Quantidade", "type": "number", "style": { "width": 80, "maxWidth": 80, "text-align": "center" }, }
        ],
        "rows": $.get('/estoque/obtertodos', (data) => {

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


