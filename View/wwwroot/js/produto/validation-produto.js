$(() => {
    $('#form-cadastro-produto').validate({
        rules: {
            nome: {
                required: true,
                minlength: 4,
                maxlength: 20,
            },
            categoria: {
                required: true,
            },
            preco: {
                required: true,
                minlength: 3,
                maxlength: 10
            },
            peso: {
                required: true,
                minlength: 3,
                maxlength: 10
            },
            cor: {


            },
            descricao: {

            }
        },
        messages: {
            nome: {
                required: 'Este campo é obrigatório',
                minlength: 'Este campo deve ter no mínimo 4 caractéres',
                maxlength: 'Este campo deve ter no máximo 20 caractéres'
            },
            categoria: {
                required: 'Este campo é obrigatório',
            },
            preco: {
                required: 'Este campo é obrigatório',
                minlength: 'Este campo deve ter no mínimo 3 caractéres',
                maxlength: 'Este campo deve ter no máximo 10 caractéres'
            },
            peso: {
                required: 'Este campo é obrigatório',
                minlength: 'Este campo deve ter no mínimo 3 caractéres',
                maxlength: 'Este campo deve ter no máximo 10 caractéres'
            },

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
