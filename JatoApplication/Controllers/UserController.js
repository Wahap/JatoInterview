app.controller('userController', function PostController($scope, userFactory) {
    $scope.users = [];
    $scope.user = null;
    $scope.editMode = false;
    $scope.Member;
    $scope.userAuthentication = "Fail";
    $scope.GeneralMessage = "";
    $scope.showAlert = false;
    $scope.Result;

    $('#divMessage').hide();
    $('#divOperations').hide();

    // initialize your users data
    $scope.login = function (Member) {


        if ($('#txtuserName').val() == null) {

            $scope.GeneralMessage = 'Username is reqiured,';
            $scope.showAlert = true;
        }
        if ($('#txtPassword').val() == '') {

            $scope.GeneralMessage = 'Password is reqiured, ';
            $scope.showAlert = true;
        }

        if ($('#txtPassword').val() != '' && $('#txtuserName').val() != '') {

            userFactory.login({ username: Member.userName, password: Member.Password }).success(function (data) {

                $scope.userAuthentication = 'Pass';
                $scope.showAlert = false;
                $('#divLogin').hide();
                $('#divOperations').show();

            }).error(function () {

                $scope.userAuthentication = 'Fail';
                $scope.GeneralMessage = "Please Check Your Username & Password";
                $scope.showAlert = true;
                $('#divMessage').show();
                $('#divLogin').show();
                $('#divOperations').hide();

            });

        }
    }

    // --------------- REGISTER NEW MEMEBER  -------------------
    $scope.RegisterMember = function (NewMember) {



        userFactory.registerNewMember(NewMember).success(function (data) {

            $scope.GeneralMessage = "User Created Please Login";

            // $('#divMessage').show();
            $('#myModal').modal('toggle');
        }).error(function () {
        });

    }


});