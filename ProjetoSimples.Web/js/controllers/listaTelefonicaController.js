angular.module("listaTelefonica").controller("ListaTelefonicaController", function ($scope, serialGenerator, contatos, operadoras) {
    $scope.app = "Lista Telefônica";
    $scope.contatos = contatos.data;
    $scope.operadoras = operadoras.data

    var init = function () {
        calcularImpostos($scope.contatos);
        generateSerial($scope.contatos);
    };

    var calcularImpostos = function (contatos) {
        contatos.forEach(function (contato) {
            contato.operadora.precoComImposto = calcularImposto(contato.operadora.preco);
        });
    }

    var generateSerial = function (contatos) {
        contatos.forEach(function (item) {
            item.serial = serialGenerator.generate();
        });
    };

    
    var calcularImposto = function (preco) {
       var imposto = 1.2;
        return preco * imposto;
    }
    
    $scope.apagarContatos = function (contatos) {
        //console.log(contatos);
        //permiti passar uma funcao que recebe um elemento e analisa esse contato e so faz return se o contato estiver selecionado
        $scope.contatos = contatos.filter(function (contato) {
            if (!contato.selecionado) return contato;
        });
        $scope.verificarContatoSelecionado($sscope.contatos);
    };
    //dessa forma atual ele está consumindo muita performance, pois a cada ação na app ele faz N chamadas
    //var counter = 0;
    //$scope.isContatoSelecionado = function (contatos) {
    //    console.log(counter++);
    //    //some -> faz de forma similiar ao filter
    //    return contatos.some(function (contato) {
    //        return contato.selecionado;
    //    });
    //};
    //optimizando
    var counter = 0;
    $scope.verificarContatoSelecionado = function (contatos) {
        console.log(counter++);
        $scope.hasContatoSelecionado = contatos.some(function (contato) {
            return contato.selecionado;
        });
    }

    $scope.ordenarPor = function (campo) {
        $scope.criterioDeOrdenacao = campo;
        $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
    };

    init();
});
