//service - funcao construtora
//cria o objeto por meio de uma funcao construtora
/*
    var Pessoa = function(nome, idade){
        this.nome = nome;
        this.idade= idade;
    };

    var carlos = {};
    Pessoa.call(carlos, "Carlos", 25);
    console.log(carlos);

    o item acima é equivalente a:

    var carlos = new Pessoa("Carlos", 25);
    console.log(carlos);
 */
app.service("operadorasAPI", function ($http, config) {
    this.getOperadoras = function () {
        return $http.get(config.baseUrl + "operadora/listar");
    };
});