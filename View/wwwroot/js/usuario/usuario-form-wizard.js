jQuery(function ($) {
    $('#exemploWizard').wizard();


    formConta = $('#formConta');
    formPagamento = $('formPagamento');
    formFinalizado = $('formFeito');

    (function () {

        formConta.formValidation({
            framework: 'bootstrap',
            fields: {
                cep: {
                    validators: {
                        notEmpty: {
                            message: 'Por favor, preencha o Cep',
                        },
                        stringLength: {
                            min: 8,
                            max: 8,
                            message: 'O Cep deve ter 8 caractéres',
                        },
                        regexp: {
                            regexp: /^[0-9]+$/,
                            message: 'O Cep só pode conter númericos',
                        }
                    }

                },
                estado: {
                    validators: {
                        notEmpty: {
                            message: 'Selecione um Estado'
                        }
                    }
                },
                cidade: {
                    validators: {
                        notEmtpy: {
                            message: 'Selecione uma Cidade'
                        }
                    }
                },
                endereco: {
                    validators: {
                        notEmpty: {
                            message: 'Preencha o campo de Endereço',
                        },
                        stringLength: {
                            min: 5,
                            max: 35,
                            message: 'Endereço precisa ter entre 5 a 35 caractéres'
                        }
                    }
                },
                numero: {
                    validators: {
                        notEmpty: {
                            message: 'Preencha o número da Residência'
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
                }
            }

        })

    });

});


