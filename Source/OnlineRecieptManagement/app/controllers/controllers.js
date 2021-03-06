﻿/*#######################################################################
  
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

app.controller('LoginController', function ($scope, $http, $location) {
    
    $scope.credentials = {
        Username: '',
        Password: ''
    };

    $scope.login = function (credentials) {
   
        var userCredentials = {
            Username: credentials.Username,
            Password: credentials.Password
        };

        if ($scope.loginForm.$valid) {
           // alert("i am right");
        }

        $.support.cors = true;
        $.ajax({
            url: 'http://localhost:22011/api/login',
            type: 'POST',
            data: userCredentials,
            dataType: "json",           
            success: function (data) {

               // alert('Contacts added successfully.   ' + data.responseText);
                window.location = "/OnlineRecieptManagement/f_index.html";
            },
            error: function (data) {
                alert('Problem in adding contacts:' + data.responseText);            
               
            }
        });
    };
});

app.controller('SignupController', function ($scope, $http, $location) {

    $scope.signupDetails = {
        FirstName: '',
        LastName: '',
        Email:'',
        Password: '',
        ConfirmPassword:''

    };

    $scope.signup = function (signupDetails) {

        var userCredentials = {
            FirstName: signupDetails.FirstName,
            LastName: signupDetails.LastName,
            Email:signupDetails.Email,
            Password: signupDetails.Password
        };

        if ($scope.signupForm.$valid) {
            
        }
        //$scope.submitForm = function (isValid) {

        //    // check to make sure the form is completely valid
        //    if (isValid) {
        //        alert('our form is amazing');
        //    }
        //    else {
        //        alert('not good')
        //    }

        //};

        $.support.cors = true;
        $.ajax({
            url: 'http://localhost:22011/api/user',
            type: 'POST',
            data: userCredentials,
            dataType: "json",
            success: function (data) {

                //alert('Contacts added successfully.   ' + data.responseText);
                window.location = "/OnlineRecieptManagement/f_index.html";
            },
            error: function (data) {
                alert('Problem in adding contacts:' + data.responseText);

            }
        });
    };
});

app.controller('ProductServiceController', function ($scope, $http, $location) {

    $scope.productServices = {
        ServiceName: '',
        ServiceDescription: '',
        ServiceCategoryId: '',
        ServiceSubCategoryId: '',
        ServicePurchaseDate:'',
        UserId: '',
        ServiceTags: '',

        ReceiptDate: '',
        ReceiptSerialNumber: '',
        ReceiptTitle: '',
        ReceiptDescription: '',

        WarrantyTitle: '',
        WarrantyDescription: '',
        WarrantyExpireOn: '',
        WarrantyCardNumber: '',

        ReceiptUploadedFiles: [],

        WarrantyCardUploadedFiles: []
    };

    $scope.create = function (productServiceDetails) {

        /*var productServices = {
            ServiceName: ServiceName,
            ServiceDescription: '',
            ServiceCategoryId: '',
            ServiceSubCategoryId: '',
            UserId: '',
            ServiceTags: '',

            ReceiptDate: '',
            ReceiptSerialNumber: '',
            ReceiptTitle: '',
            ReceiptDescription: '',

            WarrantyTitle: '',
            WarrantyDescription: '',
            WarrantyExpireOn: '',
        };
        */

        //if ($scope.signupForm.$valid) {

        //}        

        //productServiceDetails.ReceiptUploadedFiles = $scope.productServices.ReceiptUploadedFiles;
        //productServiceDetails.WarrantyCardUploadedFiles = $scope.productServices.WarrantyCardUploadedFiles;


        $.support.cors = true;
        $.ajax({
            url: 'http://localhost:22011/api/productservice',
            type: 'POST',
            data: $scope.productServices,
            dataType: "json",
            success: function (data) {
                window.location = "#/receipts";
            },
            error: function (data) {
                alert('Problem in adding contacts:' + data.responseText);

            }
        });
    };

    $scope.receiptFilesChanged = function (elm) {

        $scope.receiptSelectedFiles = elm.files;
        $scope.$apply();
    }

    $scope.receiptFileUpload = function () {

        var fd = new FormData();
        angular.forEach($scope.receiptSelectedFiles, function (file) {
            fd.append('file', file);
        })

        //$http.defaults.headers.common['Api-Token'] = 'testtoken';

        $http.post('http://localhost:22011/api/fileupload', fd,
            {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }

            })
            .success(function (d) {
                console.log(d);
                if (d.response_type == 'ok') {
                    $scope.productServices.ReceiptUploadedFiles = $scope.productServices.ReceiptUploadedFiles.concat(d.response_object);
                    document.getElementById("receiptFileUpload").value = "";
                    $scope.receiptSelectedFiles = [];
                }
            })
            .error(function (e) {
                console.log(e);
            })
    }

    $scope.warrantyCardFilesChanged = function (elm) {

        $scope.warrantyCardSelectedFiles = elm.files;
        $scope.$apply();
    }

    $scope.warrantyCardFileUpload = function () {

        var fd = new FormData();
        angular.forEach($scope.warrantyCardSelectedFiles, function (file) {
            fd.append('file', file);
        })

        //$http.defaults.headers.common['Api-Token'] = 'testtoken';

        $http.post('http://localhost:22011/api/fileupload', fd,
            {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }

            })
            .success(function (d) {
                console.log(d);
                if (d.response_type == 'ok') {
                    $scope.productServices.WarrantyCardUploadedFiles = $scope.productServices.WarrantyCardUploadedFiles.concat(d.response_object);
                    document.getElementById("warrantyCardFileUpload").value = "";
                    $scope.receiptSelectedFiles = [];
                }
            })
            .error(function (e) {
                console.log(e);
            })
    }

    $scope.previewFile = function (link, title) {

        imageFile = document.getElementById('imgFile');
        document.getElementById('modalTitle').innerHTML = title;
        imageFile.src = link;
        imageFile.alt = title;
        imageFile.title = title;

        $('#modalPreviewImage').modal('show');
    }

    $scope.deleteFile = function (id, title) {

        alert("You cant delete file " + title + ". No file deletion functionality implemented yet.");
    }

});

app.controller('FileUploadController', function ($scope, $http, $location) {

    //$scope.receiptFiles = {
    //    Id: '',
    //    Title: '',
    //    Linlk: ''

    //};
    $scope.receiptFiles = [];

    $scope.previewFile = function (link, title) {

        imageFile = document.getElementById('imgFile');
        document.getElementById('modalTitle').innerHTML = title;
        imageFile.src = link;
        imageFile.alt = title;
        imageFile.title = title;

        $('#modalPreviewImage').modal('show');
        //alert(link);
    }

    $scope.deleteFile = function (id, title) {

        alert("You cant delete file " + title + ". No file deletion functionality implemented yet.");
    }

    $scope.filesChanged = function (elm) {

        $scope.files = elm.files;
        $scope.$apply();
    }

    $scope.upload = function () {

        var fd = new FormData();
        angular.forEach($scope.files, function(file){
            fd.append('file', file);
        })

        //$http.defaults.headers.common['Api-Token'] = 'testtoken';

        $http.post('http://localhost:22011/api/fileupload', fd,
            {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
                
            })
            .success(function(d){
                console.log(d);
                if (d.response_type == 'ok') {
                    $scope.receiptFiles = $scope.receiptFiles.concat(d.response_object);
                }
            })
            .error(function (e) {
                console.log(e);
            })
    
    }

});

app.controller('ProductServiceDashboardController', function ($scope, $http, $location) {

    
    $scope.productServicesRecords = [];

    $scope.$on('$viewContentLoaded', function (event) {

        /*
        $('#tbl_receipts').dataTable({
            "bPaginate": true,
            "bLengthChange": false,
            "bFilter": false,
            "bSort": true,
            "bInfo": true,
            "bAutoWidth": false
        });
        //*/
        
    });

    $scope.LoadData = function () {
        
        $.support.cors = true;
        $.ajax({
            url: 'http://localhost:22011/api/productservice',
            type: 'Get',
            success: function (data) {

                if (data.response_type == 'ok') {
                    console.log(data.response_object);
                    $scope.productServicesRecords = data.response_object;
                    $scope.$apply();
                }
            },
            error: function (data) {
                alert(data);

            }
        });

    }

    $scope.LoadData();

    //$scope.productServices = {

    //    Id: '',
    //    DateCreated: '',
    //    PurchaseDate: '',
    //    Cateogry: '',
    //    SubCategory: '',
    //    Product_Service: '',
    //    ReceiptAvailable: '',
    //    WarrantyCardAvailable: ''

    //};

    


    

    
});