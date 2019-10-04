$(() => {

    ObterTodosOsProdutos = function () {
        //$('#lista-produto').empty();

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

                    document.getElementById('lista-produto').appendChild(li);
                    console.log(data);
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

                    console.log(_data);

                    // Criando botoes
                    let botaoComprar = document.createElement('button');
                    let botaoDesejo = document.createElement('button');
                    // Icone
                    let iconeComprar = document.createElement('i');
                    let iconeDesejo = document.createElement('i');

                    iconeComprar.classList.add('icon', 'fa-cart-plus');
                    iconeDesejo.classList.add('icon', 'wb-heart');


                    botaoComprar.classList.add('btn', 'btn-warning', 'align-bottom', 'mr-5', 'btn-floating', 'botao-comprar');
                    botaoDesejo.classList.add('btn', 'btn-danger', 'align-bottom', 'btn-floating', 'botao-desejo');

                    // Criando as FigCap e o titulo
                    let figuraCap = document.createElement('figcaption');

                    figuraCap.classList.add('vertical-align', 'overlay-panel', 'overlay-background', 'overlay-fade');

                    botaoComprar.setAttribute('data-id', _data.id);
                    botaoDesejo.setAttribute('data-id', _data.id);

                    botaoComprar.appendChild(iconeComprar);
                    botaoDesejo.appendChild(iconeDesejo);

                    figuraCap.appendChild(botaoComprar);
                    figuraCap.appendChild(botaoDesejo);

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
                // Carousel Settings - Para o hardcode // Copiar exemplo para o Programático; 
                $('#exampleResponsive4').slick({
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
            }

        });
    }

    ObterProdutos();

    ObterTodosOsProdutos();

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
                    success: function(data){
                        alert('adicionado ao carrinho')
                    }
                });
            }
        });
    });

});

/*
 *
 * // Criando botoes e alterando eles
                    let botaoComprar = document.createElement('button');
                    let botaoDesejo = document.createElement('button');
                    let iconeComprar = document.createElement('i');
                    let iconeDesejo = document.createElement('i');

                    iconeComprar.classList.add('icon');
                    iconeComprar.classList.add('fa-cart-plus');

                    botaoComprar.classList.add('btn');
                    botaoComprar.classList.add('btn-warning');
                    botaoComprar.classList.add('align-bottom');
                    botaoComprar.classList.add('mr-5');

                    // Criando as FigCap e o titulo
                    let figuraCap = document.createElement('figcaption');

                    figuraCap.classList.add('vertical-align');
                    figuraCap.classList.add('overlay-panel');
                    figuraCap.classList.add('overlay-background');
                    figuraCap.classList.add('overlay-fade');

                    figuraCap.appendChild(botaoComprar);
                    figuraCap.appendChild(botaoDesejo);

                    titulo = document.createElement('h4');
                    titulo.innerHTML = _data.nome;

                    // Criando as Figuras
                    let figura = document.createElement('figure');

                    figura.classList.add('overlay');
                    figura.classList.add('overlay-hover');
                    figura.classList.add('animation-hover');


                    imagem = document.createElement('img');
                    imagem.setAttribute('src', '/img/witcher_action_figure.jpg');

                    figura.appendChild(titulo);
                    figura.appendChild(imagem);
                    figura.appendChild(figuraCap);

                    document.getElementById('exampleResponsive1').appendChild(figura);
 *
 * */