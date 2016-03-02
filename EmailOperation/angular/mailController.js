(function () {
    angular.module('mailApp')
    .controller('mailController', ['$scope', '$http', mailController]);

    function mailController($scope, $http) {
        vm = $scope;

        vm.useWebConfigMailServer = false;
        vm.useSSL = true;
        vm.useCredential = true;

        vm.username = "Gratex\\svc.orq2email";
        vm.password = "";


        vm.host = "smtp.gratex.com.au";
        vm.port = 25;


        vm.fromAddress = "nurulasad@gratex.com.au";

        vm.toAddress = "nurulasad@gratex.com.au";

        vm.mailSubject = "Test";

        vm.mailBody = "Mail body content";

        vm.result = '';

        vm.sendMail = function () {

            var mail = {};

            mail.useWebConfigMailServer = vm.useWebConfigMailServer;
            mail.useSSL = vm.useSSL;
            mail.useCredential = vm.useCredential;

            mail.username = vm.username;
            mail.password = vm.password;

            mail.host = vm.host;
            mail.port = vm.port;

            mail.from = vm.fromAddress;
            mail.to = vm.toAddress;
            mail.subject = vm.mailSubject;
            mail.body = vm.mailBody;

           



            $http.post('Home/SendMail', mail).then(function (result) {
                vm.result = result;
            }, function (error) {
                vm.result = result;
            });





        }

    }
})();