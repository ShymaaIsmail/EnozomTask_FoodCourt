var apiLinks = (function () {
    "use strict";

    // for api host url
    var hostUrl = "http://localhost:39153";
    //area name api
    var apiUrl = hostUrl + "/api/";

    var StoreManagementList = {};
    var URLs = {
        HostUrl:hostUrl,
        // store api controller  api urls
        StoreManagementList: StoreManagementURLList
    };

    return URLs;

    // This function return  store api controller  api urls
    function StoreManagementURLList() {
        return [
            // Get Store list
             {
                 name: 'GetAllStores',
                 data: {
                     Method: 'GET',
                     URL: apiUrl + 'Store/GetAll'
                 }
             },
             //SearchByName
              {
                  name: 'FilterStoresByName',
                  data: {
                      Method: 'GET',
                      URL: apiUrl + 'Store/SearchByName'
                  }
              },
                //GetById
              {
                  name: 'GetStoreById',
                  data: {
                      Method: 'GET',
                      URL: apiUrl + 'Store/GetById'
                  }
              },
             //AddStore
              {
                  name: 'AddStore',
                  data: {
                      Method: 'POST',
                      URL: apiUrl + 'Store/AddStore'
                  }
              },
              //EditStore
               {
                   name: 'EditStore',
                   data: {
                       Method: 'POST',
                       URL: apiUrl + 'Store/EditStore'
                   }
               },
               //DeleteStore
                {
                    name: 'DeleteStore',
                    data: {
                        Method: 'Delete',
                        URL: apiUrl + 'Store/DeleteStore'
                    }
                }
        ];
    };
});
