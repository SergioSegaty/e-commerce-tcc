$(() => {
    $id = -1;

    buscarDadosUsuario = function () {

        $.ajax({

            url: '/usuario/obterusuarioativo',
            method: 'get',
            success: function(data) {

                console.log(data);

            }


        });


    };





    // Validação do Form Usuario
    $(function () {

        $('#form-editar-usuario').validate({
            rules: {
                nomeUsuario: {
                    required: true,
                    minlength: 5,
                    maxlength: 35,
                },
                usuarioEmail: {
                    required: true,
                    minlength: 10,
                    maxlegnth: 50,
                },
                usuarioDataNascimento: {
                    required: true
                },
                usuarioCelular: {
                    required: true,
                    minlength: 4,
                    maxlength: 12
                },
                senha: {
                    required: true,
                    minlength: 5,
                    maxlength: 25
                },
                confSenha: {
                    required: true,
                    minlength: 5,
                    maxlength: 25,
                    equalTo: "#campo-senha"
                },

            },
            messages: {
                nomeUsuario: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Este campo deve ter no mínimo 5 caractéres',
                    maxlength: 'Este campo deve ter no máximo 35 caractéres'
                },
                usuarioEmail: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Este campo deve ter no mínimo 10 caractéres',
                    maxlength: 'Este campo deve ter no máximo 50 caractéres'
                },
                usuarioDataNascimento: {
                    required: 'Este campo é obrigatório',
                },
                usuarioCelular: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Este campo deve ter no mínimo 4 caractéres',
                    maxlength: 'Este campo deve ter no máximo 12 caractéres'
                },
                senha: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Senha fraca',
                    maxlength: 'Este campo deve ter no máximo 50 caractéres'
                },
                confSenha: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Senha fraca',
                    maxlength: 'Este campo deve ter no máximo 50 caractéres',
                    equalTo: 'As senhas são diferentes'
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
    // Fim validação do Form Usuario

    // Validação do Form Endereço

    $(function () {

        $('#form-editar-endereco').validate({

            rules: {
                usuarioCep: {
                    required: true,
                    minlength: 8,
                    maxlength: 8
                },
                usuarioEstado: {
                    required: true,
                },
                usuarioCidade: {
                    required: true,
                },
                usuarioBairro: {
                    required: true,
                    minlength: 5,
                    maxlength: 20
                },
                usuarioRua: {
                    required: true,
                    minlength: 5,
                    maxlength: 40
                },
                usuarioNumero: {
                    required: true,
                    minlength: 1,
                    maxlength: 6
                },
            },
            messages: {
                usuarioCep: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Este campo deve ter 8 caractéres',
                    maxlength: 'Este campo deve ter 8 caractéres',
                },
                usuarioEstado: {
                    required: 'Este campo é obrigatório',
                },
                usarioCidade: {
                    required: 'Este campo é obrigatório',
                },
                usuarioBairro: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Este campo deve ter no mínimo 5 caractéres',
                    maxlength: 'Este campo deve ter no máximo 20 caractéres'
                },
                usuarioRua: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Este campo deve ter no mínimo 5 caractéres',
                    maxlength: 'Este campo deve ter no máximo 40 caractéres'
                },
                usuarioNumero: {
                    required: 'Este campo é obrigatório',
                    minlength: 'Este campo deve ter no mínimo 4 caractéres',
                    maxlength: 'Este campo deve ter no máximo 12 caractéres'
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
    // Fim validação do Form Endereço

    // Botoes dos Formularios
    //Alterar Cadastro
    $('#btn-alterar-usuario').on('click', function () {

        $('#form-editar-usuario').validate();
    });
    //Alterar Endereco
    $('#btn-alterar-endereco').on('click', function () {

        $('#form-editar-endereco').validate();

    });

    //Popular os ComboBox
    PreencherEstados = function (idEstado) {

        $('#campo-end-estado').empty();

        let opcao = document.createElement('option');
        opcao.disabled = true;
        opcao.selected = true;
        opcao.value = -1;
        opcao.innerHTML = 'Selecione um Estado';

        document.getElementById('campo-end-estado').appendChild(opcao);

        $.ajax({

            url: '/estado/obtertodos',
            type: 'get',
            success: function (data) {
                for (let i = 0; i < data.length; i++) {
                    let _data = data[i];

                    let opcao = document.createElement('option');
                    if (idEstado != -1 && _data.id == idEstado) {
                        opcao.selected = true;
                    }
                    opcao.value = _data.id;
                    opcao.innerHTML = _data.nome;

                    document.getElementById('campo-end-estado').appendChild(opcao);
                }
            }
        });
    }

    PreencherCidades = function (idEstado) {
        $('#campo-end-cidade').empty();
        let idCidade = 0;
        let opcao = document.createElement('option');
        opcao.disabled;
        opcao.selected;
        opcao.value = -1;
        opcao.innerHTML = 'Selecione uma Cidade';

        document.getElementById('campo-end-cidade').appendChild(opcao);

        $.ajax({

            url: '/cidade/obtertodospeloestado?=' + idEstado,
            type: 'get',
            success: function (data) {
                for (let i = 0; i < data.length; i++) {
                    let _data = data[i];

                    let opcao = document.createElement('option');
                    if (idCidade != -1 && idCidade == _data.id) {
                        opcao.selected = true;
                    }

                    opcao.value = _data.id;
                    opcao.innerHTML = _data.nome;

                    document.getElementById('campo-end-cidade').appendChild(opcao);
                }
            }
        });

    }



    PreencherEstados(-1);

    $('#campo-end-estado').change(function () {
        idEstado = $('#campo-end-estado').val();

        PreencherCidades(idEstado);
    });

});