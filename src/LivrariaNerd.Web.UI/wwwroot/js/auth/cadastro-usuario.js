$(() => {
       
    $('#form-cadastro-usuario').validate({

        rules: {
            name: {
                required: true,
                minlength: 6,
                maxlength: 40,
            },
            password: {
                required: true,
                minlength: 6,
                maxlength: 20
            },
            PasswordCheck: {
                required: true,
                minlength: 6,
                maxlength: 20,
                equalTo: '#campo-senha-cadastro-usuario'
            }
        },
        messages: {
            name: {
                required: 'Este campo é obrigatório',
                minlength: 'Nome deve conter no mínimo 6 caractéres',
                maxlength: 'Nome deve conter no máximo 40 caractéres'
            },
            password: {
                required: 'Este campo é obrigatório',
                minlength: 'Senha é fraca',
                maxlength: 'Senha tem um máximo de 20 caractéres'
            },
            PasswordCheck: {
                required: 'Este campo é obrigatório',
                minlength: 'Senha é fraca',
                maxlength: 'Senha tem um máximo de 20 caractéres',
                equalTo: 'As senhas não são iguais'
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

    $('#btn-cadastro-usuario').on('click', function () {
        $('#form-cadastro-usuario').validate();

        $valido = $('#form-cadastro-usuario').valid();
        //TODO: checkar  validação

        if ($valido) {

            $.ajax({
                url: '/auth/store',
                method: 'post',
                data: {
                    Login: $email,
                    Senha: $senha,
                    NomeCompleto: $nome
                },
                success: function (data) {
                    window.location.href = "../Auth";
                }
            })
        }
    });

});