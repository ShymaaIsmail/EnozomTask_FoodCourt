'use strict';
/**
 * Configure  for the site routing state
 */
var app = angular.module('app.site')
  //.run(
  //  ['$rootScope', '$state', '$stateParams', '$http', '$window', '$templateCache',
  //    function ($rootScope, $state, $stateParams, $http, $window, $templateCache) {

  //        $rootScope.$state = $state;
  //        $rootScope.$stateParams = $stateParams;

  //    }
  //  ]
  //);
app.config(['$stateProvider', '$urlRouterProvider', routeConfigurator]);

///I use $stateProvider as i'm using ui-router as it's powerful than Angular's own ng-Router 
function routeConfigurator($stateProvider, $urlRouterProvider) {
    $stateProvider.state('site', {
        abstract: true,
        url: '/site',
        templateUrl: '/App/Site/Layout/app-site.html'
     
    });
    //get all routes that are existed in control panel and register it to the $stateProvider
    var routes = getSiteRoutes();
    routes.forEach(function (r) {
        $stateProvider.state(r.name, r.config);
    });
    $urlRouterProvider.otherwise('site/storeNavigation');
}


// Retrieve all the routes 
function getSiteRoutes() {
    var routsList = [];
    routsList = routsList.concat(SiteStoreRoute().GetStoreRouteList());
    return routsList;
}

