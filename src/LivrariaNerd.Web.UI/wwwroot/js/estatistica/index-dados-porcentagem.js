$(() => {

    ObterQuantidadeDePedidos = function () {
        $.ajax({
            url: '/Estatistica/obterquantidadepedidos',
            method: 'get',
            async: true,
            success: function (data) {
                console.log(data);

                let pDesseMes = document.createElement('p');

                let spanQuantidadePedido = document.createElement('span');

                let divQuantidadePedido = document.createElement('div');

                let spanNomePedido = document.createElement('span');

                let iIconBtn = document.createElement('i');

                let btnIconCart = document.createElement('button');

                let segundaDivQuantidadePedido = document.createElement('div');

                let terceiraDivQuantidadePedido = document.createElement('div');

                let quartaDivQuantidadePedido = document.createElement('div');

                pDesseMes.classList.add('blue-grey-400');
                pDesseMes.classList.add('font-weight-100');
                pDesseMes.classList.add('m-0'); 

                spanQuantidadePedido.classList.add('font-size-40');
                spanQuantidadePedido.classList.add('font-weight-100');

                divQuantidadePedido.classList.add('content-text');
                divQuantidadePedido.classList.add('text-center');
                divQuantidadePedido.classList.add('mb-0');

                spanNomePedido.classList.add('ml-15');
                spanNomePedido.classList.add('font-weight-400');

                iIconBtn.classList.add('icon');
                iIconBtn.classList.add('wb-shopping-cart');

                btnIconCart.type = 'button';
                btnIconCart.classList.add('btn');
                btnIconCart.classList.add('btn-floating');
                btnIconCart.classList.add('btn-sm');
                btnIconCart.classList.add('btn-warning');

                segundaDivQuantidadePedido.classList.add('card-block');
                segundaDivQuantidadePedido.classList.add('bg-white');
                segundaDivQuantidadePedido.classList.add('p-20');

                terceiraDivQuantidadePedido.classList.add('card');
                terceiraDivQuantidadePedido.classList.add('card-shadow');

                quartaDivQuantidadePedido.classList.add('col-xl-3');
                quartaDivQuantidadePedido.classList.add('col-md-6');
                quartaDivQuantidadePedido.classList.add('info-panel');

                pDesseMes.innerHTML = 'Quantidade De Novos Pedidos';
                spanQuantidadePedido.innerHTML = data.quantidade;
                spanNomePedido.innerHTML = 'Pedidos';

                divQuantidadePedido.appendChild(spanQuantidadePedido);
                divQuantidadePedido.appendChild(pDesseMes);    

                btnIconCart.appendChild(iIconBtn);

                segundaDivQuantidadePedido.appendChild(btnIconCart);
                segundaDivQuantidadePedido.appendChild(spanNomePedido);
                segundaDivQuantidadePedido.appendChild(divQuantidadePedido);

                terceiraDivQuantidadePedido.appendChild(segundaDivQuantidadePedido);
                quartaDivQuantidadePedido.appendChild(terceiraDivQuantidadePedido);

                document.getElementById('cards-custom-loja').append(quartaDivQuantidadePedido);
            }
        })
    }

    ObterTotalRendimento = function () {
        $.ajax({
            url: '/Estatistica/obtertotalrendimento',
            method: 'get',
            async: true,
            success: function (rendimento) {
                console.log(rendimento);

                let pDesseMesRendimento = document.createElement('p');

                let spanQuantiaRendimento = document.createElement('span');

                let divQuantiaRendimento = document.createElement('div');

                let spanNomeRendimento = document.createElement('span');

                let iIconBtn = document.createElement('i');

                let btnIconCart = document.createElement('button');

                let segundaDivQuantiaRendimento = document.createElement('div');

                let terceiraDivQuantiaRendimento = document.createElement('div');

                let quartaDivQuantiaRendimento = document.createElement('div');

                pDesseMesRendimento.classList.add('blue-grey-400');
                pDesseMesRendimento.classList.add('font-weight-100');
                pDesseMesRendimento.classList.add('m-0'); 

                spanQuantiaRendimento.classList.add('font-size-40');
                spanQuantiaRendimento.classList.add('font-weight-100');

                divQuantiaRendimento.classList.add('content-text');
                divQuantiaRendimento.classList.add('text-center');
                divQuantiaRendimento.classList.add('mb-0');

                spanNomeRendimento.classList.add('ml-15');
                spanNomeRendimento.classList.add('font-weight-400');

                iIconBtn.classList.add('icon');
                iIconBtn.classList.add('fa-dollar');

                btnIconCart.type = 'button';
                btnIconCart.classList.add('btn');
                btnIconCart.classList.add('btn-floating');
                btnIconCart.classList.add('btn-sm');
                btnIconCart.classList.add('btn-danger');

                segundaDivQuantiaRendimento.classList.add('card-block');
                segundaDivQuantiaRendimento.classList.add('bg-white');
                segundaDivQuantiaRendimento.classList.add('p-20');

                terceiraDivQuantiaRendimento.classList.add('card');
                terceiraDivQuantiaRendimento.classList.add('card-shadow');

                quartaDivQuantiaRendimento.classList.add('col-xl-3');
                quartaDivQuantiaRendimento.classList.add('col-md-6');
                quartaDivQuantiaRendimento.classList.add('info-panel');

                pDesseMesRendimento.innerHTML = "Rendimentos Do Mês";
                spanQuantiaRendimento.innerHTML = 'R$' + rendimento.total;
                spanNomeRendimento.innerHTML = 'Rendimentos';

                divQuantiaRendimento.appendChild(spanQuantiaRendimento);
                divQuantiaRendimento.appendChild(pDesseMesRendimento);

                btnIconCart.appendChild(iIconBtn);

                segundaDivQuantiaRendimento.appendChild(btnIconCart);
                segundaDivQuantiaRendimento.appendChild(spanNomeRendimento);
                segundaDivQuantiaRendimento.appendChild(divQuantiaRendimento);

                terceiraDivQuantiaRendimento.appendChild(segundaDivQuantiaRendimento);
                quartaDivQuantiaRendimento.appendChild(terceiraDivQuantiaRendimento);

                document.getElementById('cards-custom-loja').append(quartaDivQuantiaRendimento);
            }
        });
    }

    ObterQuantidadeProduto = function () {
        $.ajax({
            url: '/Estatistica/obtertotalproduto',
            method: 'get',
            async: true,
            success: function (produto) {
                console.log(produto);

                let pDesseMesProduto = document.createElement('p');

                let spanQuantidadeProduto = document.createElement("span");

                let divQuantidadeProduto = document.createElement("div");

                let spanNomeProduto = document.createElement("span");

                let iIconBtn = document.createElement("i");

                let btnIconCart = document.createElement("button");

                let segundaDivQuantidadeProduto = document.createElement("div");

                let terceiraDivQuantidadeProduto = document.createElement("div");

                let quartaDivQuantidadeProduto = document.createElement("div");

                pDesseMesProduto.classList.add('blue-grey-400');
                pDesseMesProduto.classList.add('font-weight-100');
                pDesseMesProduto.classList.add('m-0'); 

                spanQuantidadeProduto.classList.add("font-size-40");
                spanQuantidadeProduto.classList.add("font-weight-100");

                divQuantidadeProduto.classList.add("content-text");
                divQuantidadeProduto.classList.add("text-center");
                divQuantidadeProduto.classList.add("mb-0");

                spanNomeProduto.classList.add("ml-15");
                spanNomeProduto.classList.add("font-weight-400");

                iIconBtn.classList.add("icon");
                iIconBtn.classList.add("fa-shopping-bag");

                btnIconCart.type = "button";
                btnIconCart.classList.add("btn");
                btnIconCart.classList.add("btn-floating");
                btnIconCart.classList.add("btn-sm");
                btnIconCart.classList.add("btn-success");

                segundaDivQuantidadeProduto.classList.add("card-block");
                segundaDivQuantidadeProduto.classList.add("bg-white");
                segundaDivQuantidadeProduto.classList.add("p-20");

                terceiraDivQuantidadeProduto.classList.add("card");
                terceiraDivQuantidadeProduto.classList.add("card-shadow");

                quartaDivQuantidadeProduto.classList.add("col-xl-3");
                quartaDivQuantidadeProduto.classList.add("col-md-6");
                quartaDivQuantidadeProduto.classList.add("info-panel");

                pDesseMesProduto.innerHTML = 'Total De Produtos Adicionados Este Mês';
                spanQuantidadeProduto.innerHTML = produto.quantidade;
                spanNomeProduto.innerHTML = "Produtos";

                divQuantidadeProduto.appendChild(spanQuantidadeProduto);
                divQuantidadeProduto.appendChild(pDesseMesProduto);

                btnIconCart.appendChild(iIconBtn);

                segundaDivQuantidadeProduto.appendChild(btnIconCart);
                segundaDivQuantidadeProduto.appendChild(spanNomeProduto);
                segundaDivQuantidadeProduto.appendChild(divQuantidadeProduto);

                terceiraDivQuantidadeProduto.appendChild(segundaDivQuantidadeProduto);
                quartaDivQuantidadeProduto.appendChild(terceiraDivQuantidadeProduto);

                document.getElementById("cards-custom-loja").append(quartaDivQuantidadeProduto);
            }
        });
    }

    ObterQuantidadeUsuario = function () {
        $.ajax({
            url: '/Estatistica/obterquantidadeusuario',
            method: 'get',
            async: true,
            success: function (Usuario) {
                console.log(Usuario);

                let pDesseMesUsuario = document.createElement('p');

                let spanQuantidadeUsuario = document.createElement("span");

                let divQuantidadeUsuario = document.createElement("div");

                let spanNomeUsuario = document.createElement("span");

                let iIconBtn = document.createElement("i");

                let btnIconCart = document.createElement("button");

                let segundaDivQuantidadeUsuario = document.createElement("div");

                let terceiraDivQuantidadeUsuario = document.createElement("div");

                let quartaDivQuantidadeUsuario = document.createElement("div");

                pDesseMesUsuario.classList.add('blue-grey-400');
                pDesseMesUsuario.classList.add('font-weight-100');
                pDesseMesUsuario.classList.add('m-0'); 

                spanQuantidadeUsuario.classList.add("font-size-40");
                spanQuantidadeUsuario.classList.add("font-weight-100");

                divQuantidadeUsuario.classList.add("content-text");
                divQuantidadeUsuario.classList.add("text-center");
                divQuantidadeUsuario.classList.add("mb-0");

                spanNomeUsuario.classList.add("ml-15");
                spanNomeUsuario.classList.add("font-weight-400");

                iIconBtn.classList.add("icon");
                iIconBtn.classList.add("fa-group");

                btnIconCart.type = "button";
                btnIconCart.classList.add("btn");
                btnIconCart.classList.add("btn-floating");
                btnIconCart.classList.add("btn-sm");
                btnIconCart.classList.add("btn-primary");

                segundaDivQuantidadeUsuario.classList.add("card-block");
                segundaDivQuantidadeUsuario.classList.add("bg-white");
                segundaDivQuantidadeUsuario.classList.add("p-20");

                terceiraDivQuantidadeUsuario.classList.add("card");
                terceiraDivQuantidadeUsuario.classList.add("card-shadow");

                quartaDivQuantidadeUsuario.classList.add("col-xl-3");
                quartaDivQuantidadeUsuario.classList.add("col-md-6");
                quartaDivQuantidadeUsuario.classList.add("info-panel");

                pDesseMesUsuario.innerHTML = 'Novos Usuarios Cadastrados';
                spanQuantidadeUsuario.innerHTML = Usuario.quantidade;
                spanNomeUsuario.innerHTML = "Usuarios";

                divQuantidadeUsuario.appendChild(spanQuantidadeUsuario);
                divQuantidadeUsuario.appendChild(pDesseMesUsuario);

                btnIconCart.appendChild(iIconBtn);

                segundaDivQuantidadeUsuario.appendChild(btnIconCart);
                segundaDivQuantidadeUsuario.appendChild(spanNomeUsuario);
                segundaDivQuantidadeUsuario.appendChild(divQuantidadeUsuario);

                terceiraDivQuantidadeUsuario.appendChild(segundaDivQuantidadeUsuario);
                quartaDivQuantidadeUsuario.appendChild(terceiraDivQuantidadeUsuario);

                document.getElementById("cards-custom-loja").append(quartaDivQuantidadeUsuario);
            }
        });
    }

    ObterProdutosRecentes = function () {
        $.ajax({
            url: 'Estatistica/obterpedidorecente',
            method: 'get',
            async: true,
            success: function (dataPedidos) {
                console.log(dataPedidos);
                for (let i = 0; i < dataPedidos.lenght; i++) {
                    var _dado = dataPedidos[i];
                     
                    let linhaTr = document.createElement('tr');

                    let imagemProduto = document.createElement('img');
                    imagemProduto.setAttribute('src', _dado.imagem);

                    let colunaImagem = document.createElement('td');
                    colunaImagem.appendChild(imagemProduto);

                    let colunaNomeProduto = document.createElement('td');
                    colunaNomeProduto.innerHTML = _dado.nomeProduto;

                    let colunaClienteNome = document.createElement('td');
                    colunaClienteNome.innerHTML = _dado.clienteNome;

                    let colunaDataCompra = document.createElement('td');
                    colunaDataCompra.innerHTML = _dado.dataCompra;

                    let spanStatus = document.createElement('span')
                    spanStatus.classList.add('badge');

                    if (_dado.status === 'PAGO') {
                        spanStatus.classList.add('badge-success');
                    }
                    else if (_dado.status === 'PENDENTE') {
                        spanStatus.classList.add('badge-badge-warning');
                    }
                    else {
                        spanStatus.classList.add('badge-default');
                    }
                    spanStatus.classList.add('font-weight-100');
                    spanStatus.innerHTML = _dado.status;
                    

                    let colunaStatusPedido = document.createElement('td');
                    colunaStatusPedido.appendChild(spanStatus);

                    let colunaCodigo = document.createElement('td');
                    colunaCodigo.innerHTML = _dado.codigo;

                    linhaTr = appendChild(colunaImagem);
                    linhaTr = appendChild(colunaNomeProduto);
                    linhaTr = appendChild(colunaClienteNome);
                    linhaTr = appendChild(colunaDataCompra);
                    linhaTr = appendChild(colunaStatusPedido);
                    linhaTr = appendChild(colunaCodigo);

                    document.getElementById('tabela-conteudo-estatistica').append(linhaTr);
                }
            },
            error: function (data) {
                console.log('Deu ruim')
            }
        });
    }

    //Chamadas
    ObterQuantidadeDePedidos();
    ObterTotalRendimento();
    ObterQuantidadeProduto();
    ObterQuantidadeUsuario();
    ObterProdutosRecentes();
});