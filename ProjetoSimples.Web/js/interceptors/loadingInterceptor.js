angular.module("listaTelefonica").factory("loadingInterceptor", function ($q, $rootScope, $timeout) {
    return {
        request: function (config) {
            //a cada request incluir uma variavel loading iniciando true
            $rootScope.loading = true;
            return config;
        },
        requestError: function (rejection) {
            $rootScope.loading = false;
            return $q.reject(rejection);
        },
        response: function (response) {
            $timeout(function () {
                $rootScope.loading = false;
            }, 500);
            return response;
        },
        responseError: function (rejection) {
            $rootScope.loading = false;
            return $q.reject(rejection);
        }
    };
});