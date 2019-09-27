﻿$(() => {

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

                    let figure = document.createElement('figure');
                    figure.classList.add('overlay', 'overlay-hover', 'animation-hover', 'container');

                   
                }
            }

        });
    }

    // ObterProdutos();

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