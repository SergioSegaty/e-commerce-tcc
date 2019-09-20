$(() => {
    $('#cadastro-cidade-form').validate({
        rules: {
            nome: {
                required: true,
                minlength: 4,
                maxlength: 19
            },
            estado: {
                required: true
            }
        },
        messages: {
            nome: {
                required: 'Este campo é obrigatório.',
                minlength: 'Este campo deve conter no mínimo 4 caracteres.',
                maxlength: 'Este campo deve conter no máximo 19 caracteres.'
            },
            estado: {
                required: 'Este campo é obrigatório.'
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