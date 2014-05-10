/// <reference path="../Scripts/angular-1.1.4.js" />

/*#######################################################################
  
  Dan Wahlin
  http://twitter.com/DanWahlin
  http://weblogs.asp.net/dwahlin
  http://pluralsight.com/training/Authors/Details/dan-wahlin

  Normally like to break AngularJS apps into the following folder structure
  at a minimum:

  /app
      /controllers      
      /directives
      /services
      /partials
      /views

  #######################################################################*/

//var app = angular.module('customersApp', ['ngRoute']);

////This configures the routes and associates each route with a view and a controller
//app.config(function ($routeProvider) {
//    $routeProvider
//        .when('/customers',
//            {
//                controller: 'CustomersController',
//                templateUrl: '/OnlineRecieptManagement/app/partials/customers.html'
//            })
//        //Define a route that has a route parameter in it (:customerID)
//        .when('/customerorders/:customerID',
//            {
//                controller: 'CustomerOrdersController',
//                templateUrl: '/OnlineRecieptManagement/app/partials/customerOrders.html'
//            })
//        //Define a route that has a route parameter in it (:customerID)
//        .when('/orders',
//            {
//                controller: 'OrdersController',
//                templateUrl: '/OnlineRecieptManagement/app/partials/orders.html'
//            })
//        .otherwise({ redirectTo: '/customers' });
//});

var app = angular.module('customerOrm', ['ngRoute']);

//This configures the routes and associates each route with a view and a controller
app.config(function ($routeProvider) {
    $routeProvider
        .when('/',
            {
                controller: 'LoginController',
                templateUrl: '/OnlineRecieptManagement/Login.html'
            })
        //Define a route that has a route parameter in it (:customerID)
        //.when('/customerorders/:customerID',
        //    {
        //        controller: 'CustomerOrdersController',
        //        templateUrl: '/OnlineRecieptManagement/app/partials/customerOrders.html'
        //    })
        ////Define a route that has a route parameter in it (:customerID)
        //.when('/orders',
        //    {
        //        controller: 'OrdersController',
        //        templateUrl: '/OnlineRecieptManagement/app/partials/orders.html'
        //    })
        .otherwise({ redirectTo: '/customers' });
});




