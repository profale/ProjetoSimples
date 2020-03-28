//value -> objeto de configuração
/*
 *  app.value("config", { 
    baseUrl: "http://localhost:49981/api/"
});
 */
angular.module("listaTelefonica").constant("config", { //ou constant no lugar de value, pois ele pode ser injetado no provider
    baseUrl: "http://localhost:49981/api/"
});