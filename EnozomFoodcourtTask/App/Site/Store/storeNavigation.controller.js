/* recommended */

// controller calling the store factory
angular
    .module('app.site')
    .controller('storeNavigationController', store_Controller);
store_Controller.$inject = ['storeFactory', '$scope','NgTableParams'];

function store_Controller(storeFactory, $scope, NgTableParams) {
    // adopt the ControllerAs method 
    //as opposed to the traditional method of binding all variables and functions to the $scope object.
    var vm = this;//view model.
    vm.StoreList = [];
    vm.FilteredStoreList = [];
  
    vm.HostUrl = function () {
        return storeFactory.GetHostServerURL();
    }
    vm.getStores = function () {
        return storeFactory.GetAllStores()
          .then(function (data) {
              vm.StoreList = data.result;
              //set ng table data source
              //var self = vm;
              var data = vm.StoreList;
              vm.tableParams = new NgTableParams({}, { dataset: data });
              return vm.StoreList;
          });
    }
    vm.SearchStores = function (seachName) {
        return storeFactory.SearchStoreName(seachName)
          .then(function (data) {
              vm.FilteredStoreList = data.result;
              return vm.FilteredStoreList;
          });
    }
    ////Resolve start-up logic for a controller in an activate function
    activate();

    function activate() {
        //get Stores list
      
        return vm.getStores().then(function () {

        });

    }

    ///////////////////////////////////////////////////////////////////////

    
   
}

