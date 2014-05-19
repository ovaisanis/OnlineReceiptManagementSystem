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

var app = angular.module('customersApp', ['ngRoute']);

//This configures the routes and associates each route with a view and a controller
app.config(function ($routeProvider) {
    $routeProvider
         .when('/login',
            {
                controller: 'LoginController',
                templateUrl: '/OnlineRecieptManagement/app/partials/login/signin.html'
            })
         .when('/signup',
            {
                //controller: 'LoginController',
                templateUrl: '/OnlineRecieptManagement/app/partials/login/signup.html'
            })
         .when('/about',
            {
                //controller: 'LoginController',
                templateUrl: '/OnlineRecieptManagement/app/partials/login/about.html'
            })         
        .when('/contact',
            {
                //controller: 'LoginController',
                templateUrl: '/OnlineRecieptManagement/app/partials/login/contact.html'
            })
        .when('/dashboard',
            {
               // controller: 'CustomersController',
                templateUrl: '/OnlineRecieptManagement/app/partials/dashboard/dashboard.html'
            })
        .when('/',
            {
                // controller: 'CustomersController',
                templateUrl: '/OnlineRecieptManagement/app/partials/welcome/welcome.html'
            })
        .when('/customers',
            {
                controller: 'CustomersController',
                templateUrl: '/OnlineRecieptManagement/app/partials/customers.html'
            })
        //Define a route that has a route parameter in it (:customerID)
        .when('/customerorders/:customerID',
            {
                controller: 'CustomerOrdersController',
                templateUrl: '/OnlineRecieptManagement/app/partials/customerOrders.html'
            })
        //Define a route that has a route parameter in it (:customerID)
        .when('/orders',
            {
                controller: 'OrdersController',
                templateUrl: '/OnlineRecieptManagement/app/partials/orders.html'
            })
        .otherwise({ redirectTo: '/' });
});




