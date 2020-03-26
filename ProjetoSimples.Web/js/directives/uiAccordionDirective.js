angular.module("app").directive("uiAccordions", function () {
    return {
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
angular.module("app").directive("uiAccordion", function () {
    return {
        templateUrl: "/view/accordion.html",
        transclude: true,
        scope: {
            title: "@"
        },
        require: "^uiAccordions",
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