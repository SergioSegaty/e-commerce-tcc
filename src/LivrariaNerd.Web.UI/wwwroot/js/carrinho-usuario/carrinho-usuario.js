$(() => {

    $.ajax({
        url: '/pedido/obtertodospedidospeloidusuario',
        method: 'get',
        success: function (data) {
            for (let i = 0; i < data.length; i++) {
                let _data = data[i];

                console.log(_data);

                let tr = document.createElement('tr');

                let tdImagem = document.createElement('td');
                let img = document.createElement('img');
                img.style.width = '75px';
                img.style.height = '75px';
                img.setAttribute('src', _data.produto.imagemCaminhoWwwroot);
                tdImagem.appendChild(img);


                let tdNome = document.createElement('td');
                tdNome.innerHTML = _data.produto.nome;

                let tdPreco = document.createElement('td');
                tdPreco.innerHTML = _data.precoUnidade;

                let tdQuantidade = document.createElement('td');
                tdQuantidade.innerHTML = _data.quantidade;
                tr.appendChild(tdImagem);
                tr.appendChild(tdNome);
                tr.appendChild(tdPreco);
                tr.appendChild(tdQuantidade);
                

                document.getElementById('tabela-carrinho').appendChild(tr);
            }     
        }
    });
});