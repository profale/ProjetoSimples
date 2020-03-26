app.controller("ListaTelefonicaController", function ($scope, $http, $filter, contatosAPI, operadorasAPI, serialGenerator) {
    $scope.mensagem = "Lista Telefonica";

    var carregarContatos = function () {
       contatosAPI.getContatos().then(function (response, status) {
            //sconsole.log(response.data);
            response.data.forEach(function(item) {
                item.serial = serialGenerator.generate();
            });
            $scope.contatos = response.data;
            }).catch(function (response) {
                $scope.error = "Não foi possível carregar os dados.";
        });

    };

    var carregarOperadoras = function () {
        operadorasAPI.getOperadoras().then(function (response, status) {
            console.log(response.data);
            $scope.operadoras = response.data;
        });
    };

        $scope.adicionarContato = function (contato) {
        //push -> inseri no final de um array
        //é ruim de passar parametro
        //tentar evitar
        //$scope.contatos.push({
        //    nome: $scope.nome,
        //    telefone: $scope.telefone
        //});
        //$scope.contatos.push({
        //    nome: nome,
        //    telefone: telefone
        //});
        //$scope.contatos.push(contato);

        //maneira correta
        //$scope.contatos.push(angular.copy(contato));

        $scope.contato.serial = serialGenerator.generate();
        $scope.contato.data = new Date();
        contatosAPI.saveContato(contato).then(function (data) {
            delete $scope.contato;
            $scope.contatoForm.$setPristine();
            carregarContatos();
        }).catch(function (data) {
            $scope.mensagem = "Ocorreu um erro: " + data;
            });
    };

    carregarContatos();
    carregarOperadoras();
});
//app.controller("ListaTelefonicaController", function ($scope, $filter, contatosAPI, operadorasAPI, serialGenerator) { //ou uppercaseFilter no lugar de $filter
//    $scope.titulo = "Lista Telefônica";

//    //aplicando o filter no controller
//    $scope.contatos = [];
//    $scope.operadors = [];
//    $scope.contato = {
//        data: 1034218800000
//    };
//    //$scope.contatos = [
//    //    //{ nome: uppercaseFilter("Pedro"), telefone: "9999-8888", data: new Date(), cor: "blue", operadora: { nome: "Oi", codigo: 14, categoria: "Celular" } },
//    //    { nome: $filter('uppercase')("Pedro"), telefone: "9999-8888", data: new Date(), cor: "blue", operadora: { nome: "Oi", codigo: 14, categoria: "Celular"} },
//    //    { nome: "Ana", telefone: "9999-8877", data: new Date(), cor: "yellow", operadora: { nome: "Vivo", codigo: 15, categoria: "Celular" } },
//    //    { nome: "Maria", telefone: "9999-8866", data: new Date(), cor: "red", operadora: { nome: "Tim", codigo: 41, categoria: "Celular" }}
//    //];

//    //$scope.operadoras = [
//    //    { nome: "Oi", codigo: 14, categoria: "Celular", preco: 2 },
//    //    { nome: "Vivo", codigo: 15, categoria: "Celular", preco: 1 },
//    //    { nome: "Tim", codigo: 41, categoria: "Celular", preco: 3 },
//    //    { nome: "GVT", codigo: 25, categoria: "Fixo", preco: 1 },
//    //    { nome: "Embratel", codigo: 21, categoria: "Fixo", preco: 2 }
//    //];

//    var carregarContatos = function () {
//       contatosAPI.getContatos().then(function (response, status) {
//            //sconsole.log(response.data);
//            response.data.forEach(function(item) {
//                item.serial = serialGenerator.generate();
//            });
//            $scope.contatos = response.data;
//            }).catch(function (response) {
//                $scope.error = "Não foi possível carregar os dados.";
//        });

//    };

//    var carregarOperadoras = function () {
//        operadorasAPI.getOperadoras().then(function (response, status) {
//            console.log(response.data);
//            $scope.operadoras = response.data;
//        });
//    };

//    $scope.adicionarContato = function (contato) {
//        //push -> inseri no final de um array
//        //é ruim de passar parametro
//        //tentar evitar
//        //$scope.contatos.push({
//        //    nome: $scope.nome,
//        //    telefone: $scope.telefone
//        //});
//        //$scope.contatos.push({
//        //    nome: nome,
//        //    telefone: telefone
//        //});
//        //$scope.contatos.push(contato);

//        //maneira correta
//        //$scope.contatos.push(angular.copy(contato));
       
//        $scope.contato.serial = serialGenerator.generate();
//        $scope.contato.data = new Date();
//        contatosAPI.saveContato(contato).then(function (data) {
//            delete $scope.contato;
//            $scope.contatoForm.$setPristine();
//            carregarContatos();
//        }).catch(function (data) {
//            $scope.mensagem = "Ocorreu um erro: " + data;
//            });
//    };

//    $scope.classe1 = "selecionado";
//    $scope.classe2 = "negrito";

//    $scope.apagarContatos = function (contatos) {
//        //console.log(contatos);
//        //permiti passar uma funcao que recebe um elemento e analisa esse contato e so faz return se o contato estiver selecionado
//        $scope.contatos = contatos.filter(function (contato) {
//            if (!contato.selecionado) return contato;
//        });
//    };

//    $scope.isContatoSelecionado = function (contatos) {
//        //some -> faz de forma similiar ao filter
//        return isContatoSelecionado = contatos.some(function (contato) {
//            return contato.selecionado;
//        });
//    };

//    $scope.ordenarPor = function (campo) {
//        $scope.criterioDeOrdenacao = campo;
//        $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
//    };

//    carregarContatos();
//    carregarOperadoras();
//});