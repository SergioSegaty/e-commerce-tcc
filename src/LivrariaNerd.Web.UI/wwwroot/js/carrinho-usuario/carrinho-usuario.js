$(() => {

    $.ajax({
        url: '/pedido/obtertodospedidospeloidusuario',
        method: 'get',
        success: function (data) {
            var precoTotal = 0;
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

                precoTotal += _data.quantidade * _data.precoUnidade;
            }  

            //Parte de baixo (tfoot) onde aparece o preco total
            var footer = document.getElementById('tabela-carrinho').createTFoot(); // if already exists, return the existing one and doesnt create a new one

            let tfootTr = document.createElement('tr');

            let thTotal = document.createElement('th');
            thTotal.innerHTML = 'Total';

            //Sao criadas varias THs aleatorias para preencher espaco
            let th2 = document.createElement('th');
            let th3 = document.createElement('th');
            let thPrecoTotal = document.createElement('th');
            thPrecoTotal.innerHTML = precoTotal;
            let th4 = document.createElement('th');

            tfootTr.appendChild(thTotal);
            tfootTr.appendChild(th2);
            tfootTr.appendChild(th3);
            tfootTr.appendChild(thPrecoTotal);
            tfootTr.appendChild(th4);

            footer.appendChild(tfootTr);
        }
    });
});