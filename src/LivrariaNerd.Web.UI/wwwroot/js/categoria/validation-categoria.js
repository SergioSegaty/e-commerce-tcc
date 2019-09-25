$(() => {
    $('#form-cadastro-categoria').validate({
        rules: {
            nome: {
                required: true,
                minlength: 2,
                maxlength: 30,
            }
        },
        messages: {
            nome: {
                required: 'Este campo é obrigatório',
                minlength: 'Este campo deve ter no mínimo 2 caractéres',
                maxlength: 'Este campo deve ter no máximo 30 caractéres'
            }
        },
        errorElement: 'em',
        errorPlacement: function (error, element) {

            error.addClass('help-block text-danger');
            if (element.prop('type') === ('checkbox')) {
                error.insertAfter(element.parent('label'));
            } else {
                error.insertAfter(element);
            }

        },
        highlight: function (element, errorClass, validClass) {
            $('.error').addClass('text-danger').removeClass('text-success');
            $(element).addClass('bordered border-danger invalid').removeClass('bordered border-success valid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).addClass('bordered border-success valid').removeClass('bordered border-danger invalid');
        }
    });

});
