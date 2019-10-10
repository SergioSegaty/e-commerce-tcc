$(() => {
    $id = -1;
    $idUsuario = -1;
    $senhaUsuario = "";

                    
    $('#campo-end-cep').inputmask('99999-999');
     

    buscarDadosUsuario = function () {

        $.ajax({

            url: '/usuario/obterusuarioativo',
            method: 'get',
            success: function (data) {
                console.log(data);
                $idUsuario = data.id;
                $senhaUsuario = data.senha;

                document.getElementById('titulo-nome-usuario').innerHTML = 'Usuario: ' + data.nomeCompleto;
                $('#campo-nome').val(data.nomeCompleto);
                $('#campo-email').val(data.login);
            }
        });
    };

    $('#btn-alterar-usuario').on("click", function () {

        var senha = $("#campo-senha").val();
        var login = $('#campo-email').val();
        var nome = $('#campo-nome').val();

        console.log("senhaTabela: " + $senhaUsuario + ", senhaCampo: " + senha);

        if (senha != $senhaUsuario) {
            notifyAlert(3, 'Senha errada', 2);
        }
        else {
            $.ajax({
                url: '/usuario/alterar',
                method: 'post',
                data: {
                    Id: $idUsuario,
                    Login: login,
                    Senha: senha,
                    NomeCompleto: nome
                },
                success: function (data) {
                    notifyAlert(1, 'Cadastro Alterado com Sucesso', 2);
                    location.reload();
                },
                error: function (data) {
                    notifyAlert(3, 'Falha ao Alterar', 2);
                }

            });
        }


    });

    //Fazer:
    //Pegar endereco pelo idusuario e mostrar na view e dps fazer atualizar o endereco ou criar

    buscarEnderecoUsuario = function () {
        $.ajax({
            url: '/usuario/obterenderecousuario',
            method: 'get',
            success: function (data) {
                console.log(data);
                let endereco = data[0];
                let i = document.createElement('i');

                document.getElementById('btn-alterar-endereco').setAttribute('onclick', 'this.blur()');
                if (data.length === 0) {
                    i.setAttribute('class', 'fas fa-save', 'ml-10');

                    document.getElementById('btn-alterar-endereco').appendChild(i);
                    document.getElementById('btn-alterar-endereco').innerHTML = '<i class="fas fa-save"> Cadastrar Endereço </i>';
                    document.getElementById('btn-alterar-endereco').setAttribute('data-id', -1);

                } else {
                    document.getElementById('btn-alterar-endereco').setAttribute('data-id', endereco.id);
                    i.setAttribute('class', 'fas fa-refresh', 'ml-10');
                    $('#campo-end-cep').val(endereco.cep);
                    $('#campo-end-estado').val(endereco.cidade.idEstado);
                    PreencherCidades(endereco.cidade.idEstado);
                    setTimeout(() => {
                        $("#campo-end-cidade option[value=" + endereco.cidade.id + "]").attr('selected', 'selected');
                    }, 0100);
                    $('#campo-end-bairro').val(endereco.bairro);
                    $('#campo-end-numero').val(endereco.numero);
                    $('#campo-end-complemento').val(endereco.complemento);
                    $('#campo-end-rua').val(endereco.rua);

                    document.getElementById('btn-alterar-endereco').appendChild(i);
                    document.getElementById('btn-alterar-endereco').innerHTML = '<i class="fas fa-refresh"> Atualizar Endereço </i>';
                    
                }
            }
        });
    }


    $('#btn-alterar-endereco').on('click', function () {
        $enderecoCep = $('#campo-end-cep').inputmask('unmaskedvalue');
        $enderecoEstado = $('#campo-end-estado').val();
        $enderecoCidade = $('#campo-end-cidade').val();
        $enderecoBairro = $('#campo-end-bairro').val();
        $enderecoNumero = $('#campo-end-numero').val();
        $enderecoRua = $('#campo-end-rua').val();
        $enderecoComp = $('#campo-end-complemento').val();
        $idEndereco_ = $(this).data('id');

        if ($idEndereco_ === -1) {
            $.ajax({
                url: '/endereco/adicionar',
                method: 'post',
                data: {
                    IdCidade: $enderecoCidade,
                    IdEstado: $enderecoEstado,
                    IdUsuario: $idUsuario,
                    CEP: $enderecoCep,
                    Logradouro: "",
                    Bairro: $enderecoBairro,
                    Numero: $enderecoNumero,
                    Complemento: $enderecoComp,
                    Rua: $enderecoRua,
                },
                success: function (data) {
                    notifyAlert(1, 'Cadastro de Endereço feito com Sucesso', 2);
                }
            });
        }
        else {
            $.ajax({
                url: '/endereco/alterar',
                method: 'post',
                data: {
                    Id: $idEndereco_,
                    IdCidade: $enderecoCidade,
                    IdEstado: $enderecoEstado,
                    IdUsuario: $idUsuario,
                    CEP: $enderecoCep,
                    Logradouro: "",
                    Bairro: $enderecoBairro,
                    Numero: $enderecoNumero,
                    Complemento: $enderecoComp,
                    Rua: $enderecoRua
                },
                success: function (data) {
                    notifyAlert(1, 'Endereço Atualizado com Sucesso', 2);
                }
            });
        }
    });

    //Fazer alterar o endereco
    $('#btn-alterar-endereco').on('click', function () {
        $idEndereco = $(this).data('id');
    });

    buscarEnderecoUsuario();

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
                    maxlength: 50,
                },
                usuarioDataNascimento: {
                    required: true
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
                    minlength: 9,
                    maxlength: 9
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



    buscarDadosUsuario();
});