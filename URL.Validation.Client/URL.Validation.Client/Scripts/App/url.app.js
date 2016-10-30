angular.module('URLApp', []).
    controller('URLController', function ($scope, $http, $location, $window) {
        $scope.url = '';
        $scope.message = '';
        $scope.result = "color-default";
        $scope.isViewLoading = false;
        //get called when user submits the form
        $scope.submitForm = function () {
            $scope.isViewLoading = true;
            $http(
            {
                method: 'Get',
                url: '/Home/DomainIsAvailable?url='+$scope.url,
            }).success(function (data, status, headers, config) {
                $scope.errors = [];
                if (data.success === true) {
                    $scope.cust = {};
                    $scope.message = 'Le lien saisie est disponible';
                    $scope.result = "color-green";
                }
                else {
                    $scope.errors = data.errors;
                }
            }).error(function (data, status, headers, config) {
                $scope.errors = [];
            });
            $scope.isViewLoading = false;
        }
    }).config(function ($locationProvider) {
        //default = 'false'
        $locationProvider.html5Mode(true);
    });