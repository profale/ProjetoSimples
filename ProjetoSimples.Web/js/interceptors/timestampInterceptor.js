angular.module("listaTelefonica").factory("timestampInterceptor", function () {//ajuda a burlar mecanismo de cache se existir
    return {
        request: function (config) {//contem os dados da request que será feita 
            //console.log(config.url);
            var url = config.url;
            console.log(url);
            var timestamp = new Date().getTime();
            config.url = url + "?timestamp=" + timestamp;
            if (url.indexOf('view') > -1) return config;
            console.log(config);
            return config;
        }
    };
});