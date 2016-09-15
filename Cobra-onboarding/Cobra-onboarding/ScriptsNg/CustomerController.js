angular.module('myApp', [])//['ngAnimate', 'ngSanitize', 'ui.bootstrap'])
.controller('customersCtrl', function ($scope, $http, $filter) {
    $scope.Customer = {};
    $scope.custModel = {};
    $scope.message = '';
    $scope.result = "color-default";
    $scope.isViewLoading = false;
    $scope.ListCustomer = null;
    $scope.Details = null;
    $scope.edit = true;
    $scope.det = false;
    $scope.error = false;
    $scope.incomplete = false;
    //$scope.animationsEnabled = true;
    getallData();

    $scope.editUser = function (id) {
        if (id == 'new') {
            $scope.edit = true;
            $scope.incomplete = true;
            $scope.Customer = {};
        } else {
            $scope.edit = false;
            $scope.Customer.Id = $scope.ListCustomer[id].Id;
            $scope.Customer.Name = $scope.ListCustomer[id].Name;
            $scope.Customer.Address1 = $scope.ListCustomer[id].Address1;
            $scope.Customer.Address2 = $scope.ListCustomer[id].Address2;
            $scope.Customer.City = $scope.ListCustomer[id].City;
            $scope.Customer.OrderHeaders = $scope.ListCustomer[id].OrderHeaders;
        }
    };

    //******=========Get All Customer=========******
    function getallData(){
        //debugger;
        $http.get('/Customer/GetAllData', { cache: false })
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

    //******=========On-Click The Update Button function=========******
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

                //getallData();
                $scope.Customer.Id = data.Id;
                $scope.ListCustomer.push($scope.Customer);
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
        //getallData();
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
                //refresh the list
                var id2find = $scope.Customer.Id;
                var founditem = $filter('filter')($scope.ListCustomer, { Id: id2find }, true)[0];
                var index = $scope.ListCustomer.indexOf(founditem);
                $scope.ListCustomer[index] = $scope.Customer;
                $scope.Customer = {};
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

    //******=========Get The Customer Details=========******
    $scope.getDetails = function (custModel) {       
        //debugger;
        $scope.det = false;
        $scope.Details = null;
        $http.get('/Customer/Details/' + custModel.Id, { cache: false })
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
    //******=========Open the Customer Details popup win=========******
    //$scope.open = function () {
    //    var modalInstance = $uibModal.open({
    //        animation: $ctrl.animationsEnabled,
    //        ariaLabelledBy: 'modal-title',
    //        ariaDescribedBy: 'modal-body',
    //        templateUrl: 'Details.html',
    //        controller: 'ModalInstanceCtrl',
    //        controllerAs: '$ctrl',
    //        resolve: {
    //            Details: function () {
    //                return $scope.Details;
    //            }
    //        }
    //    });

    //    $scope.cancel = function (){
    //        $scope.dismiss({$value: 'cancel'});
    //    };

    //******=========Delete Customer=========******
    $scope.deleteCustomer = function (custModel) {
        //debugger;
        var IsConf = confirm('You are about to delete ' + custModel.Name + '. Are you sure?');
        if (IsConf) {
            $http({
                method: 'POST',
                url: '/Customer/Delete',
                data: custModel
            })
           .success(function (data, status, headers, config) {
               if (data.success === true) {
                   $scope.message = custModel.Name + ' deleted from record!!';
                   $scope.result = "color-green";
                   //getallData();
                   var index = $scope.ListCustomer.indexOf(custModel);
                   $scope.ListCustomer.splice(index,1);
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
//.config(function ($locationProvider,$routeProvider) {
//    $locationProvider.html5Mode(true);
//    $routeProvider
//    .when("/", {
//        controller: 'customersCtrl',
//        templateUrl: "Index.cshtml",
//    })
//    .when('/Details', {
//        controller: 'customersCtrl',
//        templateUrl: 'Particals/Details.html'
//    })
//    .otherwise({ redirectTo: '/' });
//});
