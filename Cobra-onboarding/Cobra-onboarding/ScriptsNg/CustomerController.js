angular.module('myApp', [])
.controller('customersCtrl', function ($scope, $http) {
    $scope.Customer = {};
    $scope.custModel = {};
    $scope.message = '';
    $scope.result = "color-default";
    $scope.isViewLoading = false;
    $scope.ListCustomer = null;
    $scope.Details = null;
    $scope.edit = true;
    $scope.error = false;
    $scope.incomplete = false;
    getallData();

    $scope.editUser = function (id) {
        if (id == 'new') {
            $scope.edit = true;
            $scope.incomplete = true;
            $scope.Customer = {};
        } else {
            $scope.edit = false;
            //$scope.Customer = $scope.ListCustomer[id - 1];
            $scope.Customer.Id = $scope.ListCustomer[id - 1].Id;
            $scope.Customer.Name = $scope.ListCustomer[id - 1].Name;
            $scope.Customer.Address1 = $scope.ListCustomer[id - 1].Address1;
            $scope.Customer.Address2 = $scope.ListCustomer[id - 1].Address2;
            $scope.Customer.City = $scope.ListCustomer[id - 1].City;
            $scope.Customer.OrderHeaders = $scope.ListCustomer[id - 1].OrderHeaders;
        }
    };

    //******=========Get All Customer=========******
    function getallData() {
        //debugger;
        $http.get('/Customer/GetAllData')
         .success(function (data, status, headers, config) {
             $scope.ListCustomer = data;
         })
         .error(function (data, status, headers, config) {
             $scope.message = 'Unexpected Error while loading data!!';
             $scope.result = "color-red";
             console.log($scope.message);
         });
    };

    //******=========Get Single Customer=========******
    $scope.getCustomer = function (custModel) {
        $http.get('/Customer/GetbyID/' + custModel.Id)
        .success(function (data, status, headers, config) {
            //debugger;
            $scope.custModel = data;
            getallData();
            console.log(data);
        })
       .error(function (data, status, headers, config) {
           $scope.message = 'Unexpected Error while loading data!!';
           $scope.result = "color-red";
           console.log($scope.message);
       });
    };

    $scope.UpdateUser = function () {
        if ($scope.edit)
        {
            $scope.CreateNewCustomer();
        }
        else
        {
            $scope.EditCustomer();
        }
    };
    //******=========Create New Customer=========******
    $scope.CreateNewCustomer = function () {
        $scope.isViewLoading = true;
        $http({
            method: 'POST',
            url: '/Customer/Insert',
            data: $scope.Customer
        }).success(function (data, status, headers, config) {
            if (data.success === true) {
                $scope.message = 'Form data Saved!';
                $scope.result = "color-green";
                getallData();
                $scope.Customer = {};
                console.log(data);
            }
            else {
                $scope.message = 'Form data not Saved!';
                $scope.result = "color-red";
            }
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error while saving data!!' + data.errors;
            $scope.result = "color-red";
            console.log($scope.message);
        });
        getallData();
        $scope.isViewLoading = false;
    };
    //******=========Edit Customer=========******
    $scope.EditCustomer = function () {
        //debugger;
        $scope.isViewLoading = true;
        $http({
            method: 'POST',
            url: '/Customer/Update',
            data: $scope.Customer
        }).success(function (data, status, headers, config) {
            if (data.success === true) {
                $scope.Customer = {};
                $scope.message = 'Form data Updated!';
                $scope.result = "color-green";
                getallData();
                console.log(data);
            }
            else {
                $scope.message = 'Form data not Updated!';
                $scope.result = "color-red";
            }
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error while updating data!!' + data.errors;
            $scope.result = "color-red";
            console.log($scope.message);
        });
        $scope.isViewLoading = false;
    };

    //******=========Get The Customer Details=========******
    function getDetails(custModel) {
        //debugger;
        $http.get('/Customer/Details' + custModel.Id)
         .success(function (data, status, headers, config) {
             $scope.Details = data;
         })
         .error(function (data, status, headers, config) {
             $scope.message = 'Unexpected Error while loading data!!';
             $scope.result = "color-red";
             console.log($scope.message);
         });
    };
    //******=========Delete Customer=========******
    $scope.deleteCustomer = function (custModel) {
        //debugger;
        var IsConf = confirm('You are about to delete ' + custModel.CustName + '. Are you sure?');
        if (IsConf) {
            $http.delete('/Customer/Delete/' + custModel.Id)
           .success(function (data, status, headers, config) {
               if (data.success === true) {
                   $scope.message = custModel.CustName + ' deleted from record!!';
                   $scope.result = "color-green";
                   getallData();
                   console.log(data);
               }
               else {
                   $scope.message = 'Error on deleting Record!';
                   $scope.result = "color-red";
               }
           })
           .error(function (data, status, headers, config) {
               $scope.message = 'Unexpected Error while deleting data!!';
               $scope.result = "color-red";
               console.log($scope.message);
           });
        }
    };
})
.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});