//factory - tipo de serviço
//fabrica - cria um objeto
angular.module("listaTelefonica").factory("contatosAPI"/*registra*/, function ($http, config) {
    var _getContatos = function () /*funcao privada*/{
        return $http.get(config.baseUrl + "contato/listar");
    };

    var _getContato = function (id) {
        //var req = {
        //    method: 'GET',
        //    url: config.baseUrl + "contato/obter/" + id,
        //    headers: { 'Access-Control-Allow-Origin': '*', 'Access-Control-Allow-Methods': 'POST, GET, OPTIONS, PUT', 'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept' },
        //    data: data
        //}
        //return req;
        return $http.get(config.baseUrl + "contato/obter/" + id, { headers: { 'Access-Control-Allow-Origin': '*' } });
    };

    var _saveContato = function (contato) {
        return $http.post(config.baseUrl + "contato/cadastrar", contato);
    };
    //faz o return pq a funcao é invocada
    return {
        getContatos: _getContatos,
        getContato: _getContato,
        saveContato: _saveContato
    }
});