function filterArray(array,apiName) {
    var apiDetails = new Object();
    var returnedAPIs = array.filter(function (item) {
        return item.name == apiName;
    });
    if (returnedAPIs.length > 0)
        apiDetails = returnedAPIs[0].data;
    return apiDetails;
}