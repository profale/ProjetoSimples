angular.module("listaTelefonica").directive("uiAlert", function () {
    return {
        //template: especifica o que deverá ser incluído dentro do elemento que estiver utilizando a diretiva
		templateUrl: "/view/alert.html",//muito similar ao ng-include
        replace: true, //substitui  o elemento pelo template da diretiva
        //A - restrita ao atributo do elemento
        //E - restrita ao elemento
        //C - restrita a classe do elemento
        //M - restrita ao comentário do elemento
		restrict: "AE", //restringe o modo de utilização da diretiva
		scope: {
            title: "@", //vincula o valor do atributo diretamente a uma propriedade
                       //do scope da diretiva
            //message: "=" não precisa usar quando habilitar o ng-transclude
		},
		transclude: true //encapsula elementos dentro de uma diretiva. Criando um scope nao isolado
	};
});