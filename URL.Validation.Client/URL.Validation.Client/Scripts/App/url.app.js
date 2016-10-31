angular.module('URLApp', []).
    controller('URLController', function ($scope, $http, $location, $window) {
        $scope.url = '';
        $scope.message = '';
        $scope.result = "error";
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
                if (data.Success === true) {
                    $scope.message = data.Message;
                    $scope.result = "color-green";
                }
                else {
                    $scope.message = data.Message;
                }
                $scope.isViewLoading = false;
            }).error(function (data, status, headers, config) {
                $scope.errors = [];
                $scope.isViewLoading = false;
            });
            
        }
    }).config(function ($locationProvider) {
        $locationProvider.html5Mode(true);
    });