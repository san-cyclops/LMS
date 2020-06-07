var app = angular.module('APIModule', []);

app.service('logservice', function ($http) {
    this.getList = function (sub) {
        return $http({
            method: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/home/GetUserRS?userName=" + sub.UserName + "&password=" + sub.Password
           
        });
    };


});





app.controller('APIController', function ($scope, $http, $window,logservice) {
 
    $scope.login = function () {


        var sub = {
            UserName: $scope.UserName,
            Password: $scope.Password
        }
        var servCall = logservice.getList(sub);
        servCall.then(function (d) {
            console.log("Done");
            console.log(d.UserName);
            //$window.open('/Home/Index');
            window.location.href = '/Home/Index';
        }, function (error) {
            console.log("Oops! Something went wrong while fetching the data.");
        });
        

    };

       
   
    
});











