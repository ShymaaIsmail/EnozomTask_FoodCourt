/* recommended */

// controller calling the store factory
angular
    .module('app.admin')
    .controller('storeController', store_Controller);
store_Controller.$inject = ['storeFactory', '$scope','NgTableParams','$templateCache','$state','$stateParams','$http'];

function store_Controller(storeFactory, $scope, NgTableParams, $templateCache, $state, $stateParams, $http) {
    // adopt the ControllerAs method 
    //as opposed to the traditional method of binding all variables and functions to the $scope object.
    var vm = this;//view model.
    vm.tableParams = null;
    vm.StoreList = [];
    vm.FilteredStoreList = [];
    vm.formdata = new FormData();
    vm.storeImgFile = {};

    //vm.tableParams = new NgTableParams({}, { dataset: {} });
    //Popup titles
    vm.header = 'Add /Edit Store';
    vm.store = { StoreID:0 ,StoreName: '', StoreDescription: '' };


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

    vm.GetStoreByID = function (storeId) {
        var obj = storeFactory.GetStoreById(storeId);
        return obj.result;
    }
    vm.DeleteStorePopUp = function (storeId) {
        return storeFactory.DeleteStore(storeId)
              .then(function (data) {
                  if (data.result > 0) {
                      $state.transitionTo($state.current, $stateParams, { reload: true, inherit: false, notify: true });
                      $(".modal-backdrop").hide();
                  }
              });
    }

    vm.SearchStores = function (seachName) {
        return storeFactory.SearchStoreName(seachName)
          .then(function (data) {
              vm.FilteredStoreList = data.result;
              return vm.FilteredStoreList;
          });
    }
    vm.SaveStoreData = function (storeObj) {
        debugger;
        var isValid=vm.StoreForm.$valid;
        if (isValid) {
            return storeFactory.SaveStore(storeObj)
              .then(function (data) {
                  if (data.result > 0) {
                      $state.transitionTo($state.current, $stateParams, { reload: true, inherit: false, notify: true });
                      $(".modal-backdrop").hide();
                  }
              });
        } else {
            // vm.StoreForm.$validate();
           // vm.$validate();

        }
    }


    /////////////View Events Handling//////////////////////////////////////////
    vm.AddStorePoUp = function () {
        vm.store = {};
        $("#AddEditeModal").modal("show");
    }
    vm.EditStorePoUp = function (storeObj) {
        vm.store = storeObj;
        $("#AddEditeModal").modal("show");

    }
   
 

    ////////////////////////////////File Upload//////////////////////////////////////////////////////////////
    vm.getStoreImage = function ($files) {
        debugger;
        if ($files && $files.length > 0) {
            vm.storeImgFile = $files[0];
            vm.uploadImageStore();
        }
    }
    vm.uploadImageStore = function () {
        debugger;
        var data = new FormData();
        data.append("file", vm.storeImgFile);
        var urlUpload = vm.HostUrl() + '/api/fileupload/UploadFiles';
        $http.post(urlUpload, data, {
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        }).success(function (data, status, headers, config) {
            debugger;
            vm.ImagePreview = vm.store.StoreLogo =  data;
        }).error(function (data, status, headers, config) {
            debugger;
        });
    }
    ////Resolve start-up logic for a controller in an activate function
    activate();

    function activate() {
        //get Stores list
      
        return vm.getStores().then(function () {

        });

        //Testing controller methods
        //return getStores().then(function () {
        //});
        //  vm.DeleteStoreByID(2);
       // vm.SearchStores("kar").then(function () {
       //});
         //var storeModelToAdd = {StoreID:0,StoreName:"New store Act test",StoreLogo:"test.png",StoreDescription:"new test desc"};
        // var storeModelToEdit = { StoreID: 17, StoreName: "Kareem P Store", StoreLogo: "Pkareem.png", StoreDescription: ":) kareem store" }; 
       //  vm.SaveStoreData(storeModelToAdd);
      //  vm.SaveStoreData(storeModelToEdit);
    }

    ///////////////////////////////////////////////////////////////////////

    
   
}

