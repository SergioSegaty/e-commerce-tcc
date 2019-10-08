$(() => {




    $('.btn-finalizar-pagamento').on('click', function () {

        var totalTotal = 0;
        $('#body-tabela-final').empty();


        $.ajax({

            url: '/pedido/obtertodospedidospeloidusuario',
            method: 'get',
            success: function (data) {
                for (var i = 0; i < data.length; i++) {

                    _data = data[i];

                    var linha = document.createElement('tr');

                    // Colunas
                    var colunaNome = document.createElement('td');
                    var colunaQuantidade = document.createElement('td');
                    var colunaPreco = document.createElement('td');
                    var colunaTotal = document.createElement('td');
                    //Fim Colunas

                    //Colocando as classes
                    colunaNome.setAttribute('class', 'text-left');
                    colunaQuantidade.setAttribute('class', 'text-center');
                    colunaPreco.setAttribute('class', 'text-center');
                    colunaTotal.setAttribute('class', 'text-center');

                    //Colocando os Dados
                    colunaNome.innerHTML = _data.produto.nome;
                    colunaPreco.innerHTML = _data.produto.preco;
                    colunaQuantidade.innerHTML = _data.quantidade;
                    colunaTotal.innerHTML = _data.precoTotal;

                    //Juntando Elementos
                    linha.appendChild(colunaNome);
                    linha.appendChild(colunaQuantidade);
                    linha.appendChild(colunaPreco);
                    linha.appendChild(colunaTotal);


                    // Colocando na Tabela
                    document.getElementById('tabela-final').appendChild(linha);


                    totalTotal += _data.produto.precoTotal;
                }


            }
        });


        $('#modalFinalPagamento').modal("show");


    });


    $('#tabela-carrinho').on('click', '.diminuir-quantidade', function () {
        $id = $(this).data('id');

        $.ajax({
            url: '/pedido/obterpeloid?id=' + $id,
            method: 'get',
            success: function (data) {
                data.quantidade--;
                if (data.quantidade < 1) {
                    data.quantidade = 1;
                }
                $.ajax({
                    url: '/pedido/modificarquantidade',
                    method: 'post',
                    data: data,
                    success: function (data) {
                        PreencherTabela();
                    }
                })
            }
        });
    });

    $('#tabela-carrinho').on('click', '.aumentar-quantidade', function () {
        $id = $(this).data('id');

        $.ajax({
            url: '/pedido/obterpeloid?id=' + $id,
            method: 'get',
            success: function (data) {
                data.quantidade++;
                if (data.quantidade < 1) {
                    data.quantidade = 1;
                }
                $.ajax({
                    url: '/pedido/modificarquantidade',
                    method: 'post',
                    data: data,
                    success: function (data) {
                        PreencherTabela();
                    }
                })
            }
        });
    });

    $('#tabela-carrinho').on('click', '.remover', function () {
        $id = $(this).data('id');

        $.ajax({
            url: '/pedido/removerdocarrinho',
            method: 'post',
            data: {
                id: $id
            },
            success: function (data) {
                PreencherTabela();
            }
        });
    });

    PreencherTabela = function () {
        $('#tabela-carrinho').empty();
        $.ajax({
            url: '/pedido/obtertodospedidospeloidusuario',
            method: 'get',
            success: function (data) {
                var precoTotal = 0;

                //THead (parte de cima da table)
                var header = document.getElementById('tabela-carrinho').createTHead(); // if already exists, return the existing one and doesnt create a new one

                let theadTr = document.createElement('tr');

                let thImagem = document.createElement('th');
                thImagem.innerHTML = 'Imagem';

                let thNome = document.createElement('th');
                thNome.innerHTML = 'Nome';
                thNome.setAttribute('scope', 'col');

                let thPreco = document.createElement('th');
                thPreco.innerHTML = 'Preco'
                thPreco.setAttribute('scope', 'col');

                let thQuantidade = document.createElement('th');
                thQuantidade.innerHTML = 'Quantidade';
                thPreco.setAttribute('scope', 'col');
                thPreco.setAttribute('width', '15%');

                let thRemover = document.createElement('th');
                thRemover.setAttribute('width', '10%');

                theadTr.appendChild(thImagem);
                theadTr.appendChild(thNome);
                theadTr.appendChild(thPreco);
                theadTr.appendChild(thQuantidade);
                theadTr.appendChild(thRemover);

                header.appendChild(theadTr);

                for (let i = 0; i < data.length; i++) {
                    let _data = data[i];


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
                    tdPreco.innerHTML = "R$ " + _data.precoUnidade;

                    let tdQuantidade = document.createElement('td');
                    let spanQuantidade = document.createElement('span');
                    spanQuantidade.innerHTML = _data.quantidade;

                    let botaoMenos = document.createElement('button');
                    let botaoMais = document.createElement('button');

                    botaoMais.classList.add('aumentar-quantidade');
                    botaoMais.classList.add('btn');
                    botaoMais.classList.add('btn-primary');
                    botaoMais.classList.add('ml-5');

                    botaoMenos.classList.add('diminuir-quantidade');
                    botaoMenos.classList.add('btn');
                    botaoMenos.classList.add('btn-primary');
                    botaoMenos.classList.add('mr-5');

                    let plusIcon = document.createElement('i');
                    plusIcon.classList.add('icon');
                    plusIcon.classList.add('wb-plus');

                    let minusIcon = document.createElement('i');
                    minusIcon.classList.add('icon');
                    minusIcon.classList.add('wb-minus');

                    botaoMais.appendChild(plusIcon);
                    botaoMenos.appendChild(minusIcon);

                    botaoMais.setAttribute('data-id', _data.id);
                    botaoMenos.setAttribute('data-id', _data.id);

                    tdQuantidade.appendChild(botaoMenos);
                    tdQuantidade.appendChild(spanQuantidade);
                    tdQuantidade.appendChild(botaoMais);

                    let tdRemover = document.createElement('td');

                    let btnRemover = document.createElement('button');
                    btnRemover.classList.add('btn');
                    btnRemover.classList.add('btn-danger');
                    btnRemover.classList.add('align-bottom');
                    btnRemover.classList.add('fas');
                    btnRemover.classList.add('fa-trash');
                    btnRemover.classList.add('remover');
                    btnRemover.setAttribute('data-id', _data.id);
                    btnRemover.setAttribute('data-toggle', 'tooltip');
                    btnRemover.setAttribute('title', 'Remover ' + _data.produto.nome +' do Carrinho.');



                    tdRemover.appendChild(btnRemover);

                    tr.appendChild(tdImagem);
                    tr.appendChild(tdNome);
                    tr.appendChild(tdPreco);
                    tr.appendChild(tdQuantidade);
                    tr.appendChild(tdRemover);

                    document.getElementById('tabela-carrinho').appendChild(tr);

                    precoTotal += _data.quantidade * _data.precoUnidade;



                }

                //Parte de baixo (tfoot) onde aparece o preco total
                var footer = document.getElementById('tabela-carrinho').createTFoot(); // if already exists, return the existing one and doesnt create a new one

                let tfootTr = document.createElement('tr');

                let thTotal = document.createElement('th');
                thTotal.innerHTML = 'Sub-Total';

                //Sao criadas varias THs aleatorias para preencher espaco
                let th2 = document.createElement('th');
                let th3 = document.createElement('th');
                let thPrecoTotal = document.createElement('th');
                thPrecoTotal.innerHTML = "R$ " + precoTotal;
                let th4 = document.createElement('th');

                tfootTr.appendChild(th2);
                tfootTr.appendChild(th3);
                tfootTr.appendChild(th4);
                tfootTr.appendChild(thTotal);
                tfootTr.appendChild(thPrecoTotal);

                footer.appendChild(tfootTr);
            }
        });
    }

    PreencherTabela();
});