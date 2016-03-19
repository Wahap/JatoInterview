app.controller('UserOperationController', function PostController($scope, userOperationFactory) {
    $scope.editMode = false;
    $scope.showAlert = false;
    $scope.onlyNumbers = /^[0-9]{1,99}([,.][0-9]{1,99})?$/;

    $('#divMessage').hide();
    $('#divOperations').hide();



    //--------------- Sum ------------------------------
    $scope.Sum = function (Operation) {


        userOperationFactory.Sum({ number1: Operation.number1, number2: Operation.number2 }).success(function (data) {

            $scope.Result = data;

        }).error(function () {

            $scope.userAuthentication = 'Fail';

        });

    }

    //--------------- Sub ------------------------------
    $scope.Sub = function (Operation) {

        userOperationFactory.Sub({ number1: Operation.Subnumber1, number2: Operation.Subnumber2 }).success(function (data) {

            $scope.ResultSub = data;
        }).error(function () {

            console.log('Unexpected Error');

        });


    }
    //--------------- Multiply ------------------------------
    $scope.Multiply = function (Operation) {

        userOperationFactory.Multiply({ number1: Operation.MultiplyNumber1, number2: Operation.MultiplyNumber2 }).success(function (data) {

            $scope.MultiplyResult = data;

        }).error(function () {

            console.log('Unexpected Error');


        });

    }
    //--------------- Divide ------------------------------
    $scope.Divide = function (Operation) {


        userOperationFactory.Divide({ number1: Operation.DivideNumber1, number2: Operation.DivideNumber2 }).success(function (data) {

            $scope.DivideResult = data;

        }).error(function () {

            console.log('Unexpected Error');

        });

    }

});