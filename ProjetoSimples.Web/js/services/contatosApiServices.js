//factory - tipo de serviço
//fabrica - cria um objeto
angular.module("listaTelefonica").factory("contatosAPI"/*registra*/, function ($http, config) {
    var _getContatos = function () /*funcao privada*/{
        return $http.get(config.baseUrl + "contato/listar");
    };
    var _saveContato = function (contato) {
        return $http.post(config.baseUrl + "contato/cadastrar", contato);
    };
    //faz o return pq a funcao é invocada
    return {
        getContatos: _getContatos,
        saveContato: _saveContato
    }
});