angular.module("listaTelefonica").factory("errorInterceptor", function ($q, $location) {//implementacao do angular por padrao promisses/defered
    return {
        responseError: function (rejection) {
            //console.log(rejection);
            if (rejection.status === 400) {
                $location.path("/error");
            }
            if (rejection.status === 404) {
                $location.path("/error");
            }
            return $q.reject(rejection);
        }
    };
});