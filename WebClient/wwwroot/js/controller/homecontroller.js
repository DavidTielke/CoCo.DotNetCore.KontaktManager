angular
    .module('KontaktManager')
    .controller('homecontroller', ['$scope', '$http', function ($scope, http) {
        $scope.amountChildren = 5;
        $scope.amountAdults = 4;

        $scope.Selected = function (person) {
            person.Lastname = "Clicked";
        }

        $scope.refreshAdults = function () {
            http.get('http://localhost:5000/api/Persons/Adults')
                .then(data => {
                    $scope.adults = data.data;
                    $scope.amountAdults = data.data.length;
                }, () => {
                    $scope.adults = [];
                    $scope.amountAdults = 0;
                });
        }

        $scope.refreshChildren = function () {
            http.get('http://localhost:5000/api/Persons/Children')
                .then(data => {
                    $scope.children = data.data;
                    $scope.amountChildren = data.data.length;
                }, () => {
                    $scope.children = [];
                    $scope.amountChildren = 0;
                });
        };

        $scope.refreshAdults();
        $scope.refreshChildren();
    }]);
