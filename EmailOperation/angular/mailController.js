(function () {
    angular.module('mailApp')
    .controller('mailController', ['$scope', '$http', mailController]);

    function mailController($scope, $http) {
        console.log(11);
    }
})();