/*#######################################################################
  
  Dan Wahlin
  http://twitter.com/DanWahlin
  http://weblogs.asp.net/dwahlin
  http://pluralsight.com/training/Authors/Details/dan-wahlin

  Normally like the break AngularJS controllers into separate files.
  Kept them together here since they're small and it's easier to look through them.
  example. 

  #######################################################################*/


//This controller retrieves data from the customersService and associates it with the $scope
//The $scope is ultimately bound to the customers view
app.controller('CustomersController', function ($scope, customersService) {

    //I like to have an init() for controllers that need to perform some initialization. Keeps things in
    //one place...not required though especially in the simple example below
    init();

    function init() {
        $scope.customers = customersService.getCustomers();
    }

    $scope.insertCustomer = function () {
        var firstName = $scope.newCustomer.firstName;
        var lastName = $scope.newCustomer.lastName;
        var city = $scope.newCustomer.city;
        customersService.insertCustomer(firstName, lastName, city);
        $scope.newCustomer.firstName = '';
        $scope.newCustomer.lastName = '';
        $scope.newCustomer.city = '';
    };

    $scope.deleteCustomer = function (id) {
        customersService.deleteCustomer(id);
    };
});

//This controller retrieves data from the customersService and associates it with the $scope
//The $scope is bound to the order view
app.controller('CustomerOrdersController', function ($scope, $routeParams, customersService) {
    $scope.customer = {};
    $scope.ordersTotal = 0.00;

    //I like to have an init() for controllers that need to perform some initialization. Keeps things in
    //one place...not required though especially in the simple example below
    init();

    function init() {
        //Grab customerID off of the route        
        var customerID = ($routeParams.customerID) ? parseInt($routeParams.customerID) : 0;
        if (customerID > 0) {
            $scope.customer = customersService.getCustomer(customerID);
        }
    }

});

//This controller retrieves data from the customersService and associates it with the $scope
//The $scope is bound to the orders view
app.controller('OrdersController', function ($scope, customersService) {
    $scope.customers = [];

    //I like to have an init() for controllers that need to perform some initialization. Keeps things in
    //one place...not required though especially in the simple example below
    init();

    function init() {
        $scope.customers = customersService.getCustomers();
    }
});

app.controller('NavbarController', function ($scope, $location) {
    $scope.getClass = function (path) {
        if ($location.path().substr(0, path.length) == path) {
            return true
        } else {
            return false;
        }
    }
});

//This controller is a child controller that will inherit functionality from a parent
//It's used to track the orderby parameter and ordersTotal for a customer. Put it here rather than duplicating 
//setOrder and orderby across multiple controllers.
app.controller('OrderChildController', function ($scope) {
    $scope.orderby = 'product';
    $scope.reverse = false;
    $scope.ordersTotal = 0.00;

    init();

    function init() {
        //Calculate grand total
        //Handled at this level so we don't duplicate it across parent controllers
        if ($scope.customer && $scope.customer.orders) {
            var total = 0.00;
            for (var i = 0; i < $scope.customer.orders.length; i++) {
                var order = $scope.customer.orders[i];
                total += order.orderTotal;
            }
            $scope.ordersTotal = total;
        }
    }

    $scope.setOrder = function (orderby) {
        if (orderby === $scope.orderby)
        {
            $scope.reverse = !$scope.reverse;
        }
        $scope.orderby = orderby;
    };

});

var headers = {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': ['GET', 'POST', 'OPTIONS', 'PUT', 'DELETE'],
    'Access-Control-Allow-Headers': 'Content-Type',
    'Access-Control-Allow-Credendtials': 'true',
    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
}

app.controller('LoginController', function ($scope, $http) {
    
    $scope.credentials = {
        username: '',
        password: ''
    };

    $scope.login = function (credentials) {
        //jQuery.support.cors = true;

        var data1 = {
            Username: 'aaakh',
            Password: 'thuuu'
        };

        

        $.support.cors = true;
        $.ajax({
            url: 'http://localhost:22011/api/login',
            type: 'POST',
            data: data1,
            //contentType: "application/json;charset=utf-8",
            dataType: "json",
            //contentType: "application/x-www-form-urlencoded",
            success: function (data) {
                alert('Contacts added successfully.   ' + data.responseText);

            },
            error: function (data) {
                alert('Problem in adding contacts:' + data.responseText);
            }
        });


        //var http = new XMLHttpRequest();
        //var url = "http://localhost:22011/api/login";
        //var params = '{"Username":"waseem","Password":"waqar"}';
        //http.open("POST", url, true);

        ////Send the proper header information along with the request
        //http.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        //http.setRequestHeader("Content-length", params.length);
        //http.setRequestHeader("Connection", "close");
        ////http.setRequestHeader("Content-type", "application/json;charset=utf-8");

        //http.onreadystatechange = function () {//Call a function when the state changes.
        //    if (http.readyState == 4 && http.status == 200) {
        //        alert(http.responseText);
        //    }
        //}
        //http.send(params);



        //$.ajax({
        //    url: "http://localhost:22011/api/login",
        //    type: "GET",
        //    success: function (data) {
        //        //Grab our data from Ground Control
        //        alert(data);
        //    },
        //    error: function (event) {
        //        //If any errors occurred - detail them here
        //        alert("Transmission failed. (An error has occurred)");
        //    }
        //});

        //alert(credentials);
        //var jsonData = { Username: 'faisal', Password: "111" };
        //$http({ method: 'post', url: 'http://localhost:1787/api/login', data: jsonData, contentType: "application/json;charset=utf-8", }).
        //   success(function (data, status, headers, config) {
        //       //this callback will be called asynchronously, when the response is available
        //       alert(data);
        //   }).
        //   error(function (data, status, headers, config) {
        //       //called asynchronously if an error occurs or server returns response with an error status.
        //       alert("error");
        //   });
       
    };
});
