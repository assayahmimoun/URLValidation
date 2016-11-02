(function () {
    angular.module('URLApp', ['vcRecaptcha'])

	.controller('URLController', ['vcRecaptchaService', '$scope', '$http', function (vcRecaptchaService, $scope, $http) {
	    $scope.url = '';
	    $scope.message = '';
	    $scope.result = "error";
	    $scope.isViewLoading = false;
	    $scope.publicKey = "---------- Set your public key generate by your account google --------------";
	    //get called when user submits the form
	    $scope.submitForm = function () {
	        /* vcRecaptchaService.getResponse() gives you the g-captcha-response */

	        if (vcRecaptchaService.getResponse() === "") { //if string is empty
	            $scope.message = 'Merci de résoudre la captcha et valider';
	        } else {
	            var urlModel = {  //prepare payload for request
	                'URL': $scope.url,
	                'RecaptchaResponse': vcRecaptchaService.getResponse()  //send g-captcah-reponse to our server
	            }

	            $scope.isViewLoading = true;
	            $http.post('/Home/DomainIsAvailable', urlModel).success(function (data, status, headers, config) {
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
	    }
	}])
})()
