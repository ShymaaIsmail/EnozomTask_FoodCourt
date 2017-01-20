////////App js file is to create angular app module and inject any sub modules.

(function () {
    // declaring the module in one file /Immediately Invoked Function
    angular.module('app.site',
        [
         'ui.router',
    'ui.bootstrap',
    'ui.utils',
    'ui.load',
    'ngTable'

        ]);
})();