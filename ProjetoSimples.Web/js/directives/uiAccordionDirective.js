angular.module("listaTelefonica").directive("uiAccordions", function () {
    return {
        //controller mantem os estados de todos os accordions. vai ter o scope dos accordions
        controller: function ($scope, $element, $attrs) {
            var accordions = [];

            this.registerAccordion = function (accordion) {
                //registra o accordion
                accordions.push(accordion);
            };

            this.closeAll = function () {
                accordions.forEach(function (accordion) {
                    accordion.isOpened = false;
                });
            };
        }
    };
});
angular.module("listaTelefonica").directive("uiAccordion", function () {
    return {
        templateUrl: "/view/accordion.html",
        transclude: true,
        scope: {
            title: "@"
        },
        require: "^uiAccordions",//^prefixando o elemento uiAccordions
        link: function (scope, element, attrs, ctrl) {
            //ctrl.helloWorld();
            ctrl.registerAccordion(scope);
            //funcao a ser informada no ng-click do html do accordion
            scope.open = function () {
                ctrl.closeAll();
                scope.isOpened = true;
            };
        }
    };
});