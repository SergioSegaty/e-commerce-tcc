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
                                    message: 'Este campo é necessario.'
                                }
                            }
                        },
                        cidade: {
                            validators: {
                                notEmtpy: {
                                    message: 'Este campo é necessario.'
                                }
                            }
                        },
                        cep: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é necessario.',
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
                        endereco: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é necessario.',
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
                                    message: 'Este campo é necessario.'
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
                                    max: 16,
                                    message: 'Cartão invalido'
                                }
                            }
                        },
                        cvv: {
                            validators: {
                                notEmpty: {
                                    message: 'Este campo é necessario.'
                                },
                                stringLength: {
                                    min: 3,
                                    max: 3,
                                    message: 'Somente 3 caracéres'
                                }
                            }
                        },
                        titular: {
                            validators: {
                                notEmtpy: {
                                    message: 'Este campo é necessário'
                                },

                            }
                        },
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
            },
            buttonsAppendTo: '.panel-body'
        });

        (0, _jquery.default)("#exampleWizardFormContainer").wizard(options);
    })();
});



