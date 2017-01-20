
var SiteStoreRoute = (function () {
    "use strict";
    var vm = {
        GetStoreRouteList: storeNavigationRouteList
    };
    return vm;


    // This function return Employee Management module routes
    function storeNavigationRouteList() {
        return [
              
                {
                    name: 'site.storeNavigation',
                    config: {
                        url: '/storeNavigation',
                        templateUrl: '/App/Site/Store/Stores.html',
                        controller: 'storeNavigationController',
                        controllerAs:'storeNavigate'
                    }
                }
        ];
    };
});