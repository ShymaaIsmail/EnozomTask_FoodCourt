
var storeRoute = (function () {
    "use strict";
    var vm = {
        GetStoreRouteList: storeRouteList
    };
    return vm;


    // This function return Employee Management module routes
    function storeRouteList() {
        return [
              
                {
                    name: 'admin.storeManagement',
                    config: {
                        url: '/storeManagement',
                        templateUrl: '/App/ControlPanel/Store/store-manage.html',
                        controller: 'storeController',
                        controllerAs:'storeManage'
                    }
                }
        ];
    };
});