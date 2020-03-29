angular.module("listaTelefonica").controller("novoContatoCtrl", function ($scope, contatosAPI, serialGenerator, $location, operadoras) {
    //operadoras -> objeto de transporte
    $scope.operadoras = operadoras.data;//listo somente os dados das operadoras

	$scope.adicionarContato = function (contato) {
        contato.serial = serialGenerator.generate();
        
        var d = new Date(contato.data);
        contato.data = d.toLocaleString();
        contatosAPI.saveContato(contato).then(function (data) {
			delete $scope.contato;
			$scope.contatoForm.$setPristine();
			$location.path("/contatos");//depois de adicionar volta para a pagina de conatos.html
		});
	};
});