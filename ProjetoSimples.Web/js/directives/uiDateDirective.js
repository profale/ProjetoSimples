angular.module("listaTelefonica").directive("uiDate", function ($filter) {
    return {
        //require
        require : "ngModel", //permiti ter acesso a api de ngModel e recebo como 4 paramentro ctrl da funcao link
        link: function (scope, element, attrs, ctrl) { //executada depois do template ter sido compilado, podemos utilizá-la para interagir com a DOM,
                                                        //tratando eventos ou mesmo para definir o comportamento associado com a lógica da diretiva.
            element.bind("keyup", function () { //sempre que digitar alguma coisa eu quero ver o viewValue
                //console.log(ctrl.$viewValue) permiti visualizar tudo que é digitado no campo
                //funcao para formatacao de data
                var _formatDate = function (date) {
                    date = date.replace(/[^0-9]+/g, ""); //limpar a data
                    if (date.length > 2) {
                        date = date.substring(0, 2) + "/" + date.substring(2);
                    }
                    if (date.length > 5) {
                        date = date.substring(0, 5) + "/" + date.substring(5, 9);
                    }
                    return date;
                };

                // console.log(ctrl.$viewValue); //permiti visualizar o q está sendo digitado
                //transformar o valor digitado usando a funcao $setViewValue
                ctrl.$setViewValue(_formatDate(ctrl.$viewValue));
                //render - faz a transformacao (renderizar)
                ctrl.$render();
            });         

            //interceptar o bind
            //no momento q tenho os 10 caracteres é q vai ser interagido com o seu scope
            ctrl.$parsers.push(function (value) {
                if (value.length === 10) {
                    var dateArray = value.split("/");
                    console.log(dateArray);
                    return new Date(dateArray[2], dateArray[1] - 1, dateArray[0]).getTime();
                }
            });

            ctrl.$formatters.push(function (value) {
                return $filter("date")(value, "dd/MM/yyyy");
            });
        }
    };
});