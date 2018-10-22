/// <reference path="../angular.min.js" />


var myApp = angular.module("myApp", []);

myApp.controller("myCtrl", function ($scope) {
    $scope.message = "AngularJS tutorials!"

    var employee = {
        firstName: "David",
        lastName: "Hasting",
        gender: "Male"
    };

    $scope.employee = employee;

});


var dataBindingApp = angular.module("dataBindingApp", []);

dataBindingApp.controller("dataCtrl", function ($scope) {

    $scope.message = "Hello AngularJS !!";

    var employee = {
        firstName: "David",
        lastName: "Hasting",
        gender: "Male"
    };

    $scope.employee = employee;

});

var eventsHandling = angular.module("eventsHandling", []);

eventsHandling.controller("eventCtrl", function ($scope) {

    var technologies = [
        { name: "C#.NET", likes: 0, dislikes: 0 },
        { name: "SQL", likes: 0, dislikes: 0 },
        { name: "ASP.NET", likes: 0, dislikes: 0 },
        { name: "AngularJS", likes: 0, dislikes: 0 }
    ];

    $scope.technologies = technologies;

    $scope.increementLikes = function (technology) {
        technology.likes++;
    };

    $scope.increementDislikes = function (technology) {
        technology.dislikes++;
    };

    $scope.message = "testing";

});

//Method chaining in AngularJS

var myApp = angular
    .module("myApp", [])
    .controller("myCtrl", function ($scope) {

        var employee = {
            firstName: "David",
            lastName: "Hasting",
            gender: "Male"
        };

        $scope.employee = employee;

        $scope.message = "AnuglarJS tutorials!!";

    });

var myFilterApp = angular
    .module("filtersApp", [])
    .controller("myCtrl", function ($scope) {

        var employees = [
            { name: "David", dateofBirth: new Date(1998, 1, 10), gender: "Male", salary: 55000.55 },
            { name: "John", dateofBirth: new Date(1988, 1, 10), gender: "Male", salary: 55000.666666 },
            { name: "Peter", dateofBirth: new Date(1978, 1, 10), gender: "Male", salary: 55000 },
            { name: "Castle", dateofBirth: new Date(1968, 1, 10), gender: "Male", salary: 55000 },
            { name: "Hana", dateofBirth: new Date(1958, 1, 10), gender: "Male", salary: 55000 },
            { name: "Alexandre", dateofBirth: new Date(1948, 1, 10), gender: "Male", salary: 55000 },
        ];

        $scope.employees = employees;
        $scope.rowLimit = 3;

    });


var myCustomFilters = angular
    .module("customFiltersApp", [])
    //filters moved into separate JS file
    .controller("myCtrl", function ($scope) {

        var employees = [
            { name: "David", dateofBirth: new Date(1998, 1, 10), gender: 1, salary: 55000.55 },
            { name: "John", dateofBirth: new Date(1988, 1, 10), gender: 2, salary: 55000.666666 },
            { name: "Peter", dateofBirth: new Date(1978, 1, 10), gender: 3, salary: 55000 },
            { name: "Castle", dateofBirth: new Date(1968, 1, 10), gender: 1, salary: 55000 },
            { name: "Hana", dateofBirth: new Date(1958, 1, 10), gender: 2, salary: 55000 },
            { name: "Alexandre", dateofBirth: new Date(1948, 1, 10), gender: 1, salary: 55000 }
        ];

        $scope.employees = employees;


    });

var myHttpServices = angular
    .module("httpServices", [])
    .controller("myCtrl", function ($scope, $http, $log) {
        //$http.get('http://localhost:53830/api/Employee')
        //    .then(function (response) {

        //        $scope.employees = response.data;

        //    })

        var successCBEmp = function (response) {
            $scope.employees = response.data;
            $log.info(response);
        };

        var errorCBEmp = function (reason) {
            $scope.errorDetails = reason.status + " , " + reason.data.Message;
            $log.info(reason);
        };

        $http({
            method: 'GET',
            url: 'http://localhost:53830/api/Employee'
        }).
            then(successCBEmp, errorCBEmp);

    });

var appCustSvc = angular
    .module("customServices", [])
    .controller("myCtrl", function ($scope, stringService) {

        $scope.transformString = function (input) {
            $scope.output = stringService.processString(input);
        };

    }); 


var appCustSvcDerive = angular
    .module("customServce", [])
    .controller("", function () {

    });

//var appCtrlAsDemo = angular
//    .module("CtrlAsDemo", [])
//    .controller("countryCtrl", function ($scope) {
//        $scope.name = "India";
//        $scope.cntryMessage = "Object from country!!";
//    })
//    .controller("stateCtrl", function ($scope) {
//        $scope.name = "Maharashtra";
//        $scope.stateMessage = "Object from state !!!";
//    })
//    .controller("cityCtrl", function ($scope) {
//        $scope.name = "Mumbai";
//        $scope.cityMessage = "Object from city!!!";
//    })
var appCtrlAsDemo = angular
    .module("CtrlAsDemo", [])
    .controller("countryCtrl", function ($scope) {
        this.name = "India";
        $scope.cntryMessage = "Object from country!!";
    })
    .controller("stateCtrl", function ($scope) {
        this.name = "Maharashtra";
        $scope.stateMessage = "Object from state !!!";
    })
    .controller("cityCtrl", function ($scope) {
        this.name = "Mumbai";
        $scope.cityMessage = "Object from city!!!";
    })