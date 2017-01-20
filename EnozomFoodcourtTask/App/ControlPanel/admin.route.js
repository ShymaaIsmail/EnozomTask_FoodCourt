'use strict';
/**
 * Configure  for the admin routing state
 */
var app = angular.module('app.admin')
  .run(
    ['$rootScope', '$state', '$stateParams', '$http', '$window','$templateCache',
      function ($rootScope, $state, $stateParams, $http, $window, $templateCache) {

          $rootScope.$state = $state;
          $rootScope.$stateParams = $stateParams;

      }
    ]
  );
app.config(['$stateProvider', '$urlRouterProvider', routeConfigurator]);

///I use $stateProvider as i'm using ui-router as it's powerful than Angular's own ng-Router 
function routeConfigurator($stateProvider, $urlRouterProvider) {
    $stateProvider.state('admin', {
        abstract: true,

        url: '/admin',
        templateUrl: '/App/ControlPanel/Layout/app-admin.html'//,
        //data: {
        //    proxy: ''
        //}
    });
    //get all routes that are existed in control panel and register it to the $stateProvider
    var routes = getAdminRoutes();
    routes.forEach(function (r) {
        $stateProvider.state(r.name, r.config);
    });
    $urlRouterProvider.otherwise('admin/storeManagement');
}


// Retrieve all the routes 
function getAdminRoutes() {
    var routsList = [];
    routsList = routsList.concat(storeRoute().GetStoreRouteList());
    return routsList;
}

