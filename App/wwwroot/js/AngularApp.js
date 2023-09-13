var app = angular.module('app', []);
angular.module('app').controller("UpdateMapController", function ($scope, $window, $http, $interval) {

    $scope.isLoading = false;
    $scope.locations = null;

    $scope.updateLocations = function() {
        $scope.isLoading = true;
        var req = {
            method: 'Get',
            url: '/api/admin/cars/statusofcars',
            headers: {
                'Content-Type': 'application/json',
            }
        }
        $http(req).then(function (success) {
            $scope.isLoading = false;
            $scope.locations = success.data;
            $window.locations = $scope.locations;
            $window.updateMarkers();
        }, function (error) {
            $scope.isLoading = false;
          
        });


    }
    // call the func for first time
    $scope.updateLocations();

    $scope.setViewOfMap=function(input) {
        $window.setViewOfMap(input);
    }

    // call func in loop
    $interval(function() {
            $scope.updateLocations();
        },
        10000);

});