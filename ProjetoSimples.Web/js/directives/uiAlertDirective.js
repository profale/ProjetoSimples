angular.module("app").directive("uiAlert", function () {
	return {
		templateUrl: "/view/alert.html",
        replace: true,
        //A - restrita ao atributo do elemento
        //E - restrita ao elemento
        //C - restrita a classe do elemento
        //M - restrita ao comentário do elemento
		restrict: "AE",
		scope: {
            title: "@", //vincula o valor do atributo diretamente a uma propriedade
                       //do scope da diretiva
            //message: "=" não precisa usar quando habilitar o ng-transclude
		},
		transclude: true //encapsula elementos dentro de uma diretiva
	};
});