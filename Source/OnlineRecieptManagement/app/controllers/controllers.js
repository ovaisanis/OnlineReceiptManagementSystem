/*#######################################################################
  
  Dan Wahlin
  http://twitter.com/DanWahlin
  http://weblogs.asp.net/dwahlin
  http://pluralsight.com/training/Authors/Details/dan-wahlin

  Normally like the break AngularJS controllers into separate files.
  Kept them together here since they're small and it's easier to look through them.
  example. 

  #######################################################################*/

app.controller('LoginController', function ($scope, $http) {
    
    $scope.credentials = {
        username: '',
        password: ''
    };
    $scope.login = function (credentials) {
       
        //alert(credentials);

        $http({ method: 'get', url: 'http://mugh-events.azurewebsites.net/api/events/' }).
           success(function (data, status, headers, config) {
               //this callback will be called asynchronously, when the response is available
               alert("success");
           }).
           error(function (data, status, headers, config) {
               //called asynchronously if an error occurs or server returns response with an error status.
               alert("error");
           });

         /* $rootScope.get('http://mugh-events.azurewebsites.net/api/events/').
           success(function (data) {
               alert(1);
              // $scope.events = data;
           });*/
    };
});
