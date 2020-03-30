angular.module("listaTelefonica").config(function ($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('');
    $routeProvider.when("/contatos", {
        templateUrl: "view/contatos.html",
        controller: "ListaTelefonicaController",
        resolve: {
            contatos: function (contatosAPI) {
                return contatosAPI.getContatos();
            },
            operadoras: function (operadorasAPI) {
                return operadorasAPI.getOperadoras();
            }
        }
    });
    $routeProvider.when("/novoContato", {
        templateUrl: "view/novoContato.html",
        controller: "novoContatoCtrl",
        resolve: {
            operadoras: function (operadorasAPI) {
                return operadorasAPI.getOperadoras();
            }
        }
    });
    $routeProvider.when("/detalhesContato/:id", {
        templateUrl: "view/detalhesContato.html",
        controller: "detalhesContatoCtrl",
        resolve: {
            contato: function (contatosAPI, $route) {//para passar o id precisa passar o objeto de roteamento (route)
                return contatosAPI.getContato($route.current.params.id);//usando o current.param.id
            }
        }
    });
    $routeProvider.when("/error", {
        templateUrl: "view/error.html"
    });
    $routeProvider.otherwise({ redirectTo: "/contatos" });
});
