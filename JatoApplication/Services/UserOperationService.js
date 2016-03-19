app.factory('userOperationFactory', function ($http) {
    return {
        getUsersList: function () {
            url = baseAddress + "UserOperation/";
            return $http.get(url);
        },
      

     
        Sum: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'UserOperation/Sum/',
                params: parameters
            })

        },
        Sub: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'UserOperation/Sub/',
                params: parameters
            })

        },
        Multiply: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'UserOperation/Multiply/',
                params: parameters
            })

        },
        Divide: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'UserOperation/Divide/',
                params: parameters
            })

        }

    };
});