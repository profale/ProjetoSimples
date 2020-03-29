angular.module("listaTelefonica").controller("ListaTelefonicaController", function ($scope, serialGenerator, contatos, operadoras) {
    $scope.app = "Lista Telefônica";
    $scope.contatos = contatos.data;
    $scope.operadoras = operadoras.data

    var generateSerial = function (contatos) {
        contatos.forEach(function (item) {
            item.serial = serialGenerator.generate();
        });
    };
    
    $scope.apagarContatos = function (contatos) {
        //console.log(contatos);
        //permiti passar uma funcao que recebe um elemento e analisa esse contato e so faz return se o contato estiver selecionado
        $scope.contatos = contatos.filter(function (contato) {
            if (!contato.selecionado) return contato;
        });
    };

    $scope.isContatoSelecionado = function (contatos) {
        //some -> faz de forma similiar ao filter
        return contatos.some(function (contato) {
            return contato.selecionado;
        });
    };

    $scope.ordenarPor = function (campo) {
        $scope.criterioDeOrdenacao = campo;
        $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
    };

    generateSerial($scope.contatos);
});
