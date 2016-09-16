angular.module('myApp1', [])
.controller('orderCtrl', function ($scope, $http,$filter) {
    $scope.Order = {};
    $scope.orderModel = {};
    $scope.message = '';
    $scope.result = "color-default";
    $scope.isViewLoading = false;
    $scope.ListOrders = null;
    $scope.Details = null;
    $scope.edit = true;
    $scope.det = false;
    $scope.error = false;
    $scope.incomplete = false;
    $scope.customers = {};
    $scope.products = {},
    getallData();
    getcustomerlist();
    getproductlist();

    $scope.editOrder = function (id) {
        if (id == 'new') {
            $scope.edit = true;
            $scope.incomplete = true;
            $scope.Order = {};
        } else {
            $scope.edit = false;
            $scope.Order.OrderId = $scope.ListOrders[id].OrderId;
            $scope.Order.DateTime = $scope.ListOrders[id].DateTime;
            $scope.Order.person = {};
            $scope.Order.person.PersonId = $scope.ListOrders[id].person.PersonId;
            $scope.Order.person.Name = $scope.ListOrders[id].person.Name;
            $scope.Order.products = [];
            $scope.Order.products = $scope.ListOrders[id].products;
        }
    };

    //******=========Get All Orders=========******
    function getallData() {
        //debugger;
        $http.get('/Order/GetAllData', { cache: false })
         .success(function (data, status, headers, config) {
             $scope.ListOrders = data;
         })
         .error(function (data, status, headers, config) {
             $scope.message = 'Unexpected Error while loading data!!';
             $scope.result = "color-red";
             console.log($scope.message);
         });
    };

    //******=========Get All The Customers=========******
    function getcustomerlist() {
        $http.get('/Order/GetCustomerList', { cache: false })
        .success(function (data, status, headers, config) {
            //debugger;
            $scope.customers = data;
            console.log(data);
        })
       .error(function (data, status, headers, config) {
           $scope.message = 'Unexpected Error while loading data!!';
           $scope.result = "color-red";
           console.log($scope.message);
       });
    };
    //******=========Get All The Products=========******
    function getproductlist() {
        $http.get('/Order/GetProductList')
        .success(function (data, status, headers, config) {
            //debugger;
            $scope.products = data;
            console.log(data);
        })
       .error(function (data, status, headers, config) {
           $scope.message = 'Unexpected Error while loading data!!';
           $scope.result = "color-red";
           console.log($scope.message);
       });
    };
    //******=========On-Click The Update Button function=========******
    $scope.UpdateOrder = function () {
        if ($scope.edit) {
            $scope.CreateNewOrder();
        }
        else {
            $scope.EditOrder();
        }
    };
    //******=========Create New Order=========******
    $scope.CreateNewOrder = function () {
        $scope.isViewLoading = true;
        $http({
            method: 'POST',
            url: '/Order/Insert',
            data: $scope.Order
        }).success(function (data, status, headers, config) {
            if (data.success === true) {
                $scope.message = 'Form data Saved!';
                $scope.result = "color-green";
                //getallData();
                $scope.Order.OrderId = data.OrderId;
                $scope.ListOrders.push($scope.Order);
                $scope.Order = {};
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
        //getallData();
        $scope.isViewLoading = false;
    };
    //******=========Edit Order=========******
    $scope.EditOrder = function () {
        //debugger;
        $scope.isViewLoading = true;
        $http({
            method: 'POST',
            url: '/Order/Update',
            data: $scope.Order
        }).success(function (data, status, headers, config) {
            if (data.success === true) {
                //refresh the list
                var id2find = $scope.Order.OrderId;
                var founditem = $filter('filter')($scope.ListOrders, { OrderId: id2find }, true)[0];
                var index = $scope.ListOrders.indexOf(founditem);
                $scope.ListOrders[index] = $scope.Order;
                $scope.Order = {};
                $scope.message = 'Form data Updated!';
                $scope.result = "color-green";
                //getallData();
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

    //******=========Get The Order Details=========******
    $scope.getDetails = function (orderModel) {
        //debugger;
        $scope.det = false;
        $http.get('/Order/Details/' + orderModel.OrderId, { cache: false })
         .success(function (data, status, headers, config) {
             $scope.det = true;
             $scope.Details = data;
         })
         .error(function (data, status, headers, config) {
             $scope.message = 'Unexpected Error while loading data!!';
             $scope.result = "color-red";
             console.log($scope.message);
         });
    };
    //******=========Delete Order=========******
    $scope.deleteOrder = function (orderModel) {
        //debugger;
        var IsConf = confirm('You are about to delete ' + orderModel.person.Name + '. Are you sure?');
        if (IsConf) {
            $http({
                method: 'POST',
                url: '/Order/Delete',
                data: orderModel
            })
           .success(function (data, status, headers, config) {
               if (data.success === true) {
                   $scope.message = orderModel.person.Name + ' deleted from record!!';
                   $scope.result = "color-green";
                   //getallData();
                   var index = $scope.ListOrders.indexOf(orderModel);
                   $scope.ListOrders.splice(index, 1);
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
            //getallData();
            //$scope.isViewLoading = false;
        }
    };
    $scope.Sort = function (s) {
        $scope.reverse = ($scope.propertyName === s) ? !$scope.reverse : false;
        $scope.propertyName = s;
    };
})
.config(function ($locationProvider) {
    $locationProvider.html5Mode(true);
});