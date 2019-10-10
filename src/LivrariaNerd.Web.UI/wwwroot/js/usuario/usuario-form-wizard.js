(function (global, factory) {
    if (typeof define === "function" && define.amd) {
        define("/forms/wizard", ["jquery", "Site"], factory);
    } else if (typeof exports !== "undefined") {
        factory(require("jquery"), require("Site"));
    } else {
        var mod = {
            exports: {}
        };
        factory(global.jQuery, global.Site);
        global.formsWizard = mod.exports;
    }
})(this, function (_jquery, _Site) {
    "use strict";

    _jquery = babelHelpers.interopRequireDefault(_jquery);
    (0, _jquery.default)(document).ready(function ($$$1) {
        (0, _Site.run)();
    });

    // Example Wizard Form Container
    // -----------------------------
    // http://formvalidation.io/api/#is-valid-container


    (function () {
        var defaults = Plugin.getDefaults("wizard");

        var options = _jquery.default.extend(true, {}, defaults, {
            onInit: function onInit() {
                (0, _jquery.default)('#exampleFormContainer').formValidation({
                    framework: 'bootstrap',
                    fields: {
                        estado: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório'
                                }
                            }
                        },
                        campoCidade: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório'
                                }
                            }
                        },
                        cep: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório',
                                },
                                stringLength: {
                                    min: 9,
                                    max: 9,
                                    message: 'O Cep deve ter 8 caractéres',
                                },
                                regexp: {
                                    regexp: /^[0-9 -]+$/,
                                    message: 'O Cep só pode conter númericos',
                                }
                            }
                        },
                        endereco: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório',
                                },
                                stringLength: {
                                    min: 5,
                                    max: 35,
                                    message: 'Endereço precisa ter entre 5 a 35 caractéres'
                                }
                            }
                        },
                        numeroEnd: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório'
                                },
                                stringLength: {
                                    min: 2,
                                    max: 10,
                                    message: 'Número tem entre 2 a 10 caractéres'
                                },
                                regexp: {
                                    regexp: /^[0-9]+$/,
                                    message: 'Somente números'
                                }
                            }
                        },
                        number: {
                            validators: {
                                notEmpty: {
                                    message: 'Cartão invalido'
                                },
                                stringLength: {
                                    min: 16,
                                    max: 25,
                                    message: 'Cartão invalido'
                                }
                            }
                        },
                        cvv: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório'
                                },
                                stringLength: {
                                    min: 3,
                                    max: 3,
                                    message: 'Somente 3 caractéres'
                                }
                            }
                        },
                        titularCartao: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório'
                                },

                            }
                        },
                        bairro: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório'
                                },
                                stringLength: {
                                    min: 4,
                                    max: 30,
                                    message: 'Este campo deve ter entre 4 e 30 caractéres'
                                }
                            }
                        },
                        cpfTitular: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é obrigatório'
                                },
                                stringLength: {
                                    min: 14,
                                    max: 14,
                                    message: 'Cpf inválido'
                                }
                            }
                        }
                    },
                    err: {
                        clazz: 'invalid-feedback'
                    },
                    control: {
                        // The CSS class for valid control
                        valid: 'is-valid',
                        // The CSS class for invalid control
                        invalid: 'is-invalid'
                    },
                    row: {
                        invalid: 'has-danger'
                    }
                });
            },
            validator: function validator() {
                var fv = (0, _jquery.default)('#exampleFormContainer').data('formValidation');
                var $this = (0, _jquery.default)(this); // Validate the container

                fv.validateContainer($this);
                var isValidStep = fv.isValidContainer($this);

                if (isValidStep === false || isValidStep === null) {
                    return false;
                }

                return true;
            },
            onFinish: function onFinish() {// $('#exampleFormContainer').submit();
                $('.modal').modal('hide');
                swal({
                    title: "Sucesso!",
                    text: "A sua compra está sendo analisada!",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonClass: "btn-success",
                    confirmButtonText: 'OK',
                    closeOnConfirm: false
                });

            },
            buttonsAppendTo: '.panel-body'
        });

        (0, _jquery.default)("#exampleWizardFormContainer").wizard(options);
    })();




});


$(() => {

    $('#campo-end-cep').inputmask('99999-999');
    $('#campo-cpf-titular').inputmask('999.999.999-99');
    $('#campo-cartao-numero').inputmask('9999-9999-9999-9999');



    buscarEnderecoUsuario = function () {

        $.ajax({
            url: '/usuario/obterenderecousuario',
            method: 'get',
            success: function (d) {
                data = d[0];
                console.log(data.numero);
                $('#campo-end-numero').val(data.numero);
                $('#campo-end').val(data.rua);
                $('#campo-end-cep').val(data.cep);
                $('#campo-end-bairro').val(data.bairro);
                $('#campo-end-rua').val(data.rua);
                $('#campo-end-complemento').val(data.complemento);
                $('#campo-end-estado').val(data.cidade.idEstado);
                PreencherCidades(data.cidade.idEstado);
                setTimeout(() => {
                    $("#campo-end-cidade option[value=" + data.cidade.id + "]").attr('selected', 'selected');
                }, 0100);
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

    buscarEnderecoUsuario();

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

