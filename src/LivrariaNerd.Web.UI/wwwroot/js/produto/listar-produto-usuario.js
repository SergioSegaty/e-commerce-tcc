$(() => {

    ObterTodosOsProdutos = function () {
        //$('#lista-produto').empty();

        $.ajax({
            url: '/categoria/obtertodos',
            method: 'get',
            success: function (data) {


                document.getElementById('titulo_categoria1').innerHTML = data[0].nome;
                document.getElementById('titulo_categoria2').innerHTML = data[1].nome;
                document.getElementById('titulo_categoria3').innerHTML = data[2].nome;
                document.getElementById('titulo_categoria4').innerHTML = data[3].nome;
            }
        });

        $.ajax({
            url: '/loja/obtertodosprodutosusuarios',
            method: 'get',
            success: function (data) {
                for (let i = 0; i < data.length; i++) {
                    _data = data[i];
                    let figcaption = document.createElement('figcaption');

                    let img = document.createElement('img');

                    let figure = document.createElement('figure');

                    let h4 = document.createElement('h4');

                    let divCardBlock = document.createElement('div');

                    let div = document.createElement('div');

                    let li = document.createElement('li');



                    figcaption.classList.add('overlay-panel');
                    figcaption.classList.add('overlay-background');
                    figcaption.classList.add('overlay-fade');
                    figcaption.classList.add('overlay-icon');

                    img.classList.add('overlay-figure');
                    img.classList.add('overlay-scale');


                    img.setAttribute('src', '/tema/global/photos/1.jpg');
                    img.setAttribute('class', 'img-loja ');

                    figure.classList.add('card-img-top');
                    figure.classList.add('overlay-hover');
                    figure.classList.add('overlay');

                    divCardBlock.classList.add('card-block');
                    h4.classList.add('card-title');
                    h4.innerHTML = _data.nomeProduto;

                    div.classList.add('card');
                    div.classList.add('card-shadow');

                    li.setAttribute('data-type', _data.nomeCategoriaProduto.toLowerCase());

                    divCardBlock.appendChild(h4);
                    figure.appendChild(img);
                    figure.appendChild(figcaption);
                    div.appendChild(figure);
                    div.appendChild(divCardBlock);
                    li.appendChild(div);

                }

                $('#exampleFilter').isotope({
                    itemSelector: '.nav-item',
                    getSortData: {
                        name: '.name',
                        category: '[data-filter]'
                    },
                    // layout mode options
                    masonry: {
                        columnWidth: 200
                    }
                });
            }
        })
    }

    ObterProdutos = function () {
        $('#exampleResponsive1').empty();


        $.ajax({

            url: '/produto/obtertodospelacategoria?=1',
            method: 'get',
            success: function (data) {
                for (let i = 0; i < data.length; i++) {
                    _data = data[i];

                    // Criando botoes
                    let botaoComprar = document.createElement('button');
                    let botaoDesejo = document.createElement('button');
                    // Icone
                    let iconeComprar = document.createElement('i');
                    let iconeDesejo = document.createElement('i');

                    iconeComprar.classList.add('icon', 'fa-cart-plus');
                    iconeDesejo.classList.add('icon', 'wb-eye');

                    botaoComprar.classList.add('btn', 'btn-warning', 'align-bottom', 'mr-5', 'btn-floating', 'botao-comprar');
                    botaoDesejo.classList.add('btn', 'btn-danger', 'align-bottom', 'btn-floating', 'botao-desejo');

                    // Criando as FigCap e o titulo
                    let figuraCap = document.createElement('figcaption');

                    figuraCap.classList.add('vertical-align', 'overlay-panel', 'overlay-background', 'overlay-fade');

                    let a = document.createElement('a');
                    a.setAttribute('href', '/loja/produto?id=' + _data.id);

                    botaoComprar.setAttribute('data-id', _data.id);
                    botaoComprar.setAttribute('data-toggle', 'tooltip');
                    botaoComprar.setAttribute('title', 'Adicionar Produto Ao Carrinho');

                    botaoDesejo.setAttribute('data-toggle', 'tooltip');
                    botaoDesejo.setAttribute('title', 'Vizualizar Produto');


                    botaoComprar.appendChild(iconeComprar);
                    botaoDesejo.appendChild(iconeDesejo);
                    a.appendChild(botaoDesejo);
                    
                    figuraCap.appendChild(botaoComprar);
                    figuraCap.appendChild(a);

                    titulo = document.createElement('h4');
                    titulo.innerHTML = _data.nome;



                    // Criando as Figuras
                    let figura = document.createElement('figure');

                    figura.classList.add('overlay');
                    figura.classList.add('overlay-hover');
                    figura.classList.add('animation-hover');


                    let imagem = document.createElement('img');
                    imagem.setAttribute('src', _data.imagemCaminhoWwwroot);
                    imagem.setAttribute('class', 'img-loja');

                    figura.appendChild(titulo);                    
                    figura.appendChild(imagem);
                    figura.appendChild(figuraCap);

                    document.getElementById('exampleResponsive1').append(figura);



                }

                // Slick(Carousel) na Categoria 1
                $("#exampleResponsive1").slick({
                    dots: true,
                    infinite: false,
                    speed: 500,
                    slidesToShow: 4,
                    slidesToScroll: 4,
                    responsive: [{
                        breakpoint: 1024,
                        settings: {
                            slidesToShow: 3,
                            slidesToScroll: 3,
                            infinite: true,
                            dots: true
                        }
                    }, {
                        breakpoint: 600,
                        settings: {
                            slidesToShow: 2,
                            slidesToScroll: 2
                        }
                    }, {
                        breakpoint: 480,
                        settings: {
                            slidesToShow: 1,
                            slidesToScroll: 1
                        } // You can unslick at a given breakpoint now by adding:
                        // settings: "unslick"
                        // instead of a settings object

                    }]
                });
                // Carousel Settings - Para o hardcode // Copiar exemplo para o Programático; 
               
            }

        });
    }

    ObterProdutos2 = function () {


        $.ajax({

            url: '/produto/obtertodospelacategoria?=2',
            method: 'get',
            success: function (data) {
                if (data.length != 0) {
                    console.log(data);
                    $('#exampleResponsive2').empty();

                    for (let i = 0; i < data.length; i++) {
                        _data = data[i];

                        // Criando botoes
                        let botaoComprar = document.createElement('button');
                        let botaoDesejo = document.createElement('button');
                        // Icone
                        let iconeComprar = document.createElement('i');
                        let iconeDesejo = document.createElement('i');

                        iconeComprar.classList.add('icon', 'fa-cart-plus');
                        iconeDesejo.classList.add('icon', 'wb-eye');


                        botaoComprar.classList.add('btn', 'btn-warning', 'align-bottom', 'mr-5', 'btn-floating', 'botao-comprar');
                        botaoDesejo.classList.add('btn', 'btn-danger', 'align-bottom', 'btn-floating', 'botao-desejo');

                        // Criando as FigCap e o titulo
                        let figuraCap = document.createElement('figcaption');

                        figuraCap.classList.add('vertical-align', 'overlay-panel', 'overlay-background', 'overlay-fade');

                        botaoComprar.setAttribute('data-id', _data.id);
                        botaoDesejo.setAttribute('data-id', _data.id);

                        botaoComprar.appendChild(iconeComprar);
                        botaoDesejo.appendChild(iconeDesejo);

                        let a = document.createElement('a');
                        a.setAttribute('href', '/loja/produto?id=' + _data.id);

                        a.appendChild(botaoDesejo);
                        figuraCap.appendChild(botaoComprar);
                        figuraCap.appendChild(a);

                        titulo = document.createElement('h4');
                        titulo.innerHTML = _data.nome;

                        // Criando as Figuras
                        let figura = document.createElement('figure');

                        figura.classList.add('overlay');
                        figura.classList.add('overlay-hover');
                        figura.classList.add('animation-hover');


                        imagem = document.createElement('img');
                        imagem.setAttribute('class', 'img-loja');
                        imagem.setAttribute('src', _data.imagemCaminhoWwwroot);

                        figura.appendChild(titulo);
                        figura.appendChild(imagem);
                        figura.appendChild(figuraCap);

                        document.getElementById('exampleResponsive2').append(figura);



                    }
                    // Carousel Settings - Para o hardcode // Copiar exemplo para o Programático; 
                    $('#exampleResponsive2').slick({
                        dots: true,
                        infinite: false,
                        speed: 500,
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        responsive: [{
                            breakpoint: 1024,
                            settings: {
                                slidesToShow: 3,
                                slidesToScroll: 3,
                                infinite: true,
                                dots: true
                            }
                        }, {
                            breakpoint: 600,
                            settings: {
                                slidesToShow: 2,
                                slidesToScroll: 2
                            }
                        }, {
                            breakpoint: 480,
                            settings: {
                                slidesToShow: 1,
                                slidesToScroll: 1
                            } // You can unslick at a given breakpoint now by adding:
                            // settings: "unslick"
                            // instead of a settings object

                        }]
                    });
                } else {
                    $('#exampleResponsive2').slick({
                        dots: true,
                        infinite: false,
                        speed: 500,
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        responsive: [{
                            breakpoint: 1024,
                            settings: {
                                slidesToShow: 3,
                                slidesToScroll: 3,
                                infinite: true,
                                dots: true
                            }
                        }, {
                            breakpoint: 600,
                            settings: {
                                slidesToShow: 2,
                                slidesToScroll: 2
                            }
                        }, {
                            breakpoint: 480,
                            settings: {
                                slidesToShow: 1,
                                slidesToScroll: 1
                            } // You can unslick at a given breakpoint now by adding:
                            // settings: "unslick"
                            // instead of a settings object

                        }]
                    });
                }

            }
        });
    }

    ObterProdutos3 = function () {


        $.ajax({

            url: '/produto/obtertodospelacategoria?=3',
            method: 'get',
            success: function (data) {
                if (data.length > 1) {
                    $('#exampleResponsive3').empty();
                    for (let i = 0; i < data.length; i++) {
                        _data = data[i];


                        // Criando botoes
                        let botaoComprar = document.createElement('button');
                        let botaoDesejo = document.createElement('button');
                        // Icone
                        let iconeComprar = document.createElement('i');
                        let iconeDesejo = document.createElement('i');

                        iconeComprar.classList.add('icon', 'fa-cart-plus');
                        iconeDesejo.classList.add('icon', 'wb-eye');


                        botaoComprar.classList.add('btn', 'btn-warning', 'align-bottom', 'mr-5', 'btn-floating', 'botao-comprar');
                        botaoDesejo.classList.add('btn', 'btn-danger', 'align-bottom', 'btn-floating', 'botao-desejo');

                        let a = document.createElement('a');
                        a.setAttribute('href', '/loja/produto?id=' + _data.id);
                        // Criando as FigCap e o titulo
                        let figuraCap = document.createElement('figcaption');

                        figuraCap.classList.add('vertical-align', 'overlay-panel', 'overlay-background', 'overlay-fade');

                        botaoComprar.setAttribute('data-id', _data.id);
                        botaoDesejo.setAttribute('data-id', _data.id);

                        botaoComprar.appendChild(iconeComprar);
                        botaoDesejo.appendChild(iconeDesejo);
                        a.appendChild(botaoDesejo);

                        figuraCap.appendChild(botaoComprar);
                        figuraCap.appendChild(a);

                        titulo = document.createElement('h4');
                        titulo.innerHTML = _data.nome;

                        // Criando as Figuras
                        let figura = document.createElement('figure');

                        figura.classList.add('overlay');
                        figura.classList.add('overlay-hover');
                        figura.classList.add('animation-hover');


                        imagem = document.createElement('img');
                        imagem.setAttribute('src', _data.imagemCaminhoWwwroot);
                        imagem.setAttribute('class', 'img-loja');

                        figura.appendChild(titulo);
                        figura.appendChild(imagem);
                        figura.appendChild(figuraCap);

                        document.getElementById('exampleResponsive3').append(figura);

                    }


                    // Carousel Settings - Para o hardcode // Copiar exemplo para o Programático; 
                    $('#exampleResponsive3').slick({
                        dots: true,
                        infinite: false,
                        speed: 500,
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        responsive: [{
                            breakpoint: 1024,
                            settings: {
                                slidesToShow: 3,
                                slidesToScroll: 3,
                                infinite: true,
                                dots: true
                            }
                        }, {
                            breakpoint: 600,
                            settings: {
                                slidesToShow: 2,
                                slidesToScroll: 2
                            }
                        }, {
                            breakpoint: 480,
                            settings: {
                                slidesToShow: 1,
                                slidesToScroll: 1
                            } // You can unslick at a given breakpoint now by adding:
                            // settings: "unslick"
                            // instead of a settings object

                        }]
                    });
                }
                else {
                    $('#exampleResponsive3').slick({
                        dots: true,
                        infinite: false,
                        speed: 500,
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        responsive: [{
                            breakpoint: 1024,
                            settings: {
                                slidesToShow: 3,
                                slidesToScroll: 3,
                                infinite: true,
                                dots: true
                            }
                        }, {
                            breakpoint: 600,
                            settings: {
                                slidesToShow: 2,
                                slidesToScroll: 2
                            }
                        }, {
                            breakpoint: 480,
                            settings: {
                                slidesToShow: 1,
                                slidesToScroll: 1
                            } // You can unslick at a given breakpoint now by adding:
                            // settings: "unslick"
                            // instead of a settings object

                        }]
                    });
                }
            }

        });
    }
    ObterProdutos4 = function () {


        $.ajax({

            url: '/produto/obtertodospelacategoria?=4',
            method: 'get',
            success: function (data) {
                if (data.length > 1) {
                    $('#exampleResponsive4').empty();
                    for (let i = 0; i < data.length; i++) {
                        _data = data[i];


                        // Criando botoes
                        let botaoComprar = document.createElement('button');
                        let botaoDesejo = document.createElement('button');
                        // Icone
                        let iconeComprar = document.createElement('i');
                        let iconeDesejo = document.createElement('i');

                        iconeComprar.classList.add('icon', 'fa-cart-plus');
                        iconeDesejo.classList.add('icon', 'wb-eye');


                        botaoComprar.classList.add('btn', 'btn-warning', 'align-bottom', 'mr-5', 'btn-floating', 'botao-comprar');
                        botaoDesejo.classList.add('btn', 'btn-danger', 'align-bottom', 'btn-floating', 'botao-desejo');

                        // Criando as FigCap e o titulo
                        let figuraCap = document.createElement('figcaption');

                        figuraCap.classList.add('vertical-align', 'overlay-panel', 'overlay-background', 'overlay-fade');

                        botaoComprar.setAttribute('data-id', _data.id);
                        botaoDesejo.setAttribute('data-id', _data.id);

                        botaoComprar.appendChild(iconeComprar);
                        botaoDesejo.appendChild(iconeDesejo);


                        let a = document.createElement('a');
                        a.setAttribute('href', '/loja/produto?id=' + _data.id);

                        a.appendChild(botaoDesejo);

                        figuraCap.appendChild(botaoComprar);
                        figuraCap.appendChild(a);

                        titulo = document.createElement('h4');
                        titulo.innerHTML = _data.nome;

                        // Criando as Figuras
                        let figura = document.createElement('figure');

                        figura.classList.add('overlay');
                        figura.classList.add('overlay-hover');
                        figura.classList.add('animation-hover');


                        imagem = document.createElement('img');
                        imagem.setAttribute('src', _data.imagemCaminhoWwwroot);
                        imagem.setAttribute('class', 'img-loja');

                        figura.appendChild(titulo);
                        figura.appendChild(imagem);
                        figura.appendChild(figuraCap);

                        document.getElementById('exampleResponsive4').append(figura);

                    }


                    // Carousel Settings - Para o hardcode // Copiar exemplo para o Programático; 
                    $('#exampleResponsive4').slick({
                        dots: true,
                        infinite: false,
                        speed: 500,
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        responsive: [{
                            breakpoint: 1024,
                            settings: {
                                slidesToShow: 3,
                                slidesToScroll: 3,
                                infinite: true,
                                dots: true
                            }
                        }, {
                            breakpoint: 600,
                            settings: {
                                slidesToShow: 2,
                                slidesToScroll: 2
                            }
                        }, {
                            breakpoint: 480,
                            settings: {
                                slidesToShow: 1,
                                slidesToScroll: 1
                            } // You can unslick at a given breakpoint now by adding:
                            // settings: "unslick"
                            // instead of a settings object

                        }]
                    });
                }
                else {
                    $('#exampleResponsive4').slick({
                        dots: true,
                        infinite: false,
                        speed: 500,
                        slidesToShow: 3,
                        slidesToScroll: 3,
                        responsive: [{
                            breakpoint: 1024,
                            settings: {
                                slidesToShow: 3,
                                slidesToScroll: 3,
                                infinite: true,
                                dots: true
                            }
                        }, {
                            breakpoint: 600,
                            settings: {
                                slidesToShow: 2,
                                slidesToScroll: 2
                            }
                        }, {
                            breakpoint: 480,
                            settings: {
                                slidesToShow: 1,
                                slidesToScroll: 1
                            } // You can unslick at a given breakpoint now by adding:
                            // settings: "unslick"
                            // instead of a settings object

                        }]
                    });
                }
            }

        });
    }

    ObterProdutos();
    ObterProdutos2();
    ObterProdutos3();
    ObterProdutos4();

    ObterTodosOsProdutos();
    // clickar botao Categoria 1
    $('#exampleResponsive1').on('click', '.botao-comprar', function () {
        $idProduto = $(this).data('id');

        $.ajax({
            url: '/produto/obterpeloid?id=' + $idProduto,
            method: 'get',
            success: function (data) {
                $.ajax({
                    url: '/pedido/adicionaraocarrinho',
                    method: 'post',
                    data: data,
                    success: function (data) {
                        notifyAlert(1, 'Produto adicionado ao carrinho', 2);

                    }
                });
            }
        });
    });
    // clickar botao Categoria 2
    $('#exampleResponsive2').on('click', '.botao-comprar', function () {
        $idProduto = $(this).data('id');

        $.ajax({
            url: '/produto/obterpeloid?id=' + $idProduto,
            method: 'get',
            success: function (data) {
                $.ajax({
                    url: '/pedido/adicionaraocarrinho',
                    method: 'post',
                    data: data,
                    success: function (data) {
                        notifyAlert(1, 'Produto adicionado ao carrinho', 2);

                    }
                });
            }
        });
    });
    // clickar botao Categoria 3
    $('#exampleResponsive3').on('click', '.botao-comprar', function () {
        $idProduto = $(this).data('id');

        $.ajax({
            url: '/produto/obterpeloid?id=' + $idProduto,
            method: 'get',
            success: function (data) {
                $.ajax({
                    url: '/pedido/adicionaraocarrinho',
                    method: 'post',
                    data: data,
                    success: function (data) {
                        notifyAlert(1, 'Produto adicionado ao carrinho', 2);

                    }
                });
            }
        });
    });
    // clickar botao Categoria 4
    $('#exampleResponsive4').on('click', '.botao-comprar', function () {
        $idProduto = $(this).data('id');

        $.ajax({
            url: '/produto/obterpeloid?id=' + $idProduto,
            method: 'get',
            success: function (data) {
                $.ajax({
                    url: '/pedido/adicionaraocarrinho',
                    method: 'post',
                    data: data,
                    success: function (data) {
                        notifyAlert(1, 'Produto adicionado ao carrinho', 2);

                    }
                });
            }
        });
    });
});
