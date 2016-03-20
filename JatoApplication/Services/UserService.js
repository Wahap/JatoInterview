app.factory('userFactory', function ($http) {
    return {
        getUsersList: function () {
            url = baseAddress+"User/";
            return $http.get(url);
        },
        login: function (parameters) {
            return $http({
                method: 'GET',
                url: baseAddress + 'User/Login/',
                params: parameters
            })

        },

        registerNewMember: function (data) {
            return $http({
                method: 'Post',
                url: baseAddress + 'User/RegisterNewMember/',
                data: data
              
            })

        }
    
    };
});