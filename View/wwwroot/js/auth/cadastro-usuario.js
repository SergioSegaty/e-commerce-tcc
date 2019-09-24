$(() => {

    $('#btn-cadastro-usuario').on('click', function () {
        $senhaCheck = $('#campo-senha-check-cadastro-usuario').val();
        $senha = $('#campo-senha-cadastro-usuario').val();
        $nome = $('#campo-nome-cadastro-usuario').val();
        $email = $('#campo-email-cadastro-usuario').val();

        //TODO: checkar  validação

        if ($senhaCheck == $senha && $senha != '') {

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
        } else {
            //TODO: Se a senha e a senha Check forem diferentes, mandar algo para o usuario saber
            alert('senhas diferentes ou nula');
        }
    });

});