angular.module("listaTelefonica").filter("name", function () {
    return function (input) { //input(pode ser qq nome) - o que vai se propor a transformar
        var listaDeNomes = input.split(" ");
        //map -> pega a lista de nomes e para cada elemento que tiver (nome) ira derivar um novo array
        var listaDeNomesFormatada = listaDeNomes.map(function (nome) {
            //expressao regular -> se for compativel com da ou de
            if (/(da|de)/.test(nome)) return nome;
            return nome.charAt(0).toUpperCase() + nome.substring(1).toLowerCase();
        });
        
        //console.log(input);
        return listaDeNomesFormatada.join(" "); //pego o array e coloco entre cada elemento dele o espaço em branco
    };
});