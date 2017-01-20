// factory
angular
    .module('app')
    .factory('storeFactory', store_Factory);

store_Factory.$inject = ['$http', '$q'];

function store_Factory($http, $q) {
    
    var storeFactoryObj = {
        GetHostServerURL:getHostServerURL,
        GetStoreById: getStore,
        DeleteStore: deleteStore,
        SaveStore: saveStore,
        SearchStoreName: searchStoreByName,
        GetAllStores: getAllStores
    };

    return storeFactoryObj;
    /* recommended */
    function getHostServerURL() {
        return apiLinks().HostUrl;
    }
    function getStore(id) {
        
        var listStoreURLs = apiLinks().StoreManagementList();
        return $http.get(filterArray(listStoreURLs, "GetStoreById").URL + "?id=" + id)
            .then(SuccessCallback)
            .catch(FailureCallback);
    }
    function deleteStore(id) {
        var listStoreURLs = apiLinks().StoreManagementList();
        var deleteURL = filterArray(listStoreURLs, "DeleteStore").URL;
        return $http.delete(filterArray(listStoreURLs, "DeleteStore").URL, { params: { 'id': id } })
            .then(SuccessCallback)
            .catch(FailureCallback);
    }
    function getAllStores() {
        
        var listStoreURLs = apiLinks().StoreManagementList();
        return $http.get(filterArray(listStoreURLs, "GetAllStores").URL)
            .then(SuccessCallback)
            .catch(FailureCallback);
    }
    function searchStoreByName(storeName) {
        var listStoreURLs = apiLinks().StoreManagementList();
        return $http.get(filterArray(listStoreURLs, "FilterStoresByName").URL + "?strStoreName=" + storeName)
            .then(SuccessCallback)
            .catch(FailureCallback);
    }


    function saveStore(storeObj) {
        debugger;
        storeObj.StoreLogo = storeObj.StoreLogo.replace('/Upload/Store/', '')
        if (storeObj.StoreID > 0) {
            return editStore(storeObj);
        } else {
            return addStore(storeObj);
        }
    }
    //Add
    function addStore(storeObjToAdd) {

        var listStoreURLs = apiLinks().StoreManagementList();
        return $http.post(filterArray(listStoreURLs, "AddStore").URL, storeObjToAdd)
            .then(SuccessCallback)
            .catch(FailureCallback);
    }
    //Edit
    function editStore(storeObjToUpdate) {

        var listStoreURLs = apiLinks().StoreManagementList();
        return $http.post(filterArray(listStoreURLs, "EditStore").URL, storeObjToUpdate)
            .then(SuccessCallback)
            .catch(FailureCallback);
    }














    
    ///Promise Call backs(successs and error)
    function SuccessCallback(data, status, headers, config) {
        debugger;
        return data.data;
    }
    //catch block MUST return a rejected promise
    function FailureCallback(e) {
        var newMessage = 'XHR Failed for store request'
        if (e.data && e.data.description) {
            newMessage = newMessage + '\n' + e.data.description;
        }
        e.data.description = newMessage;
        return $q.reject(e);
    }
}