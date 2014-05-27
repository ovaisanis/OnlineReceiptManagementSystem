
var app = angular.module('customersApp', ['ngRoute']);

//This configures the routes and associates each route with a view and a controller
app.config(function ($routeProvider) {
    $routeProvider
         .when('/',
            {
                //controller: '',
                templateUrl: '/OnlineRecieptManagement/app/partials/f_views/dashboard.html'
            })
        .when('/receipts',
            {
                controller: 'ProductServiceDashboardController',
                templateUrl: '/OnlineRecieptManagement/app/partials/f_views/receipts.html'
            })
         .when('/createreceipt',
            {
                controller: 'ProductServiceController',
                templateUrl: '/OnlineRecieptManagement/app/partials/f_views/create-receipt.html'
            })
        .otherwise({ redirectTo: '/' });
});