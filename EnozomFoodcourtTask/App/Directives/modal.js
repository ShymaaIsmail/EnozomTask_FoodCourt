
angular
    .module('app').directive('modal', function () {
    return {
        restrict: 'EA',
        scope: {
            title: '=modalTitle',
            header: '=modalHeader',
            body: '=modalBody',
            footer: '=modalFooter',
            callbackbuttonleft: '&ngClickLeftButton',
            callbackbuttonright: '&ngClickRightButton',
            handler: '=lolo'
        },
        templateUrl: '/App/Directives/partialmodal.html',
        transclude: true,
        controller: function ($scope) {
            $scope.handler = 'pop';
        },
    };
});

