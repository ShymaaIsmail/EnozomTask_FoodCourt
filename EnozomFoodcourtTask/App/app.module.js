////////app js file is to create angular app module and inject any sub modules.

(function () {
    // declaring the module in one file /Immediately Invoked Function
    angular.module('app',
        [
            'app.site',
            'app.admin'
        ]);
})();