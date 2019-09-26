$(() => {

    ObterTodosOsProdutos = function () {
        $('#lista-produto').empty();

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

                    li.setAttribute('data-type', _data.nomeCategoriaProduto);
                    li.setAttribute('id', _data.codigo);

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

    ObterTodosOsProdutos();
});