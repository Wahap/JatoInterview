app.factory('userFactory', function ($http) {
    return {
        getUsersList: function () {
            url = baseAddress;
            return $http.get(url);
        },
        login: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'Login/',
                params: parameters
            })

        },

        registerNewMember: function (data) {
            return $http({
                method: 'Post',
                url: baseAddress + 'RegisterNewMember/',
                data: data
              
            })

        },
        Sum: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'Sum/',
                params: parameters
            })

        },
        Sub: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'Sub/',
                params: parameters
            })

        },
        Multiply: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'Multiply/',
                params: parameters
            })

        },
        Divide: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'Divide/',
                params: parameters
            })

        }
    
    };
});