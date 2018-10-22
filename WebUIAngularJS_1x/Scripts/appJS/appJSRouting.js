
/// <reference path="../angular.min.js" />
/// <reference path="../angular-route.min.js" />

var appRouting = angular.module('routeDemo', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $locationProvider.hashPrefix('');
        $locationProvider.html5Mode(true);
        $routeProvider.caseInsensitiveMatch = true;
        $routeProvider
            .when("/home", {
                templateUrl: "Templates/home.html",
                controller: "homeController"
            })
            .when("/contact", {
                template: "<h1>Contact details with Inline templates</h1>"
            })
            .when("/courses", {
                templateUrl: "Templates/courses.html",
                controller: "coursesController"
            })
            .when("/students", {
                templateUrl: "Templates/students.html",
                controller: "studentsController"
            })
            .when("/students/:id", {
                templateUrl: "Templates/studentDetails.html",
                controller: "studentDetailsController"
            })
            .otherwise({ redirectTo: "/home" });
    }])
    .controller("homeController", function ($scope) {
        $scope.message = "Home Page !!!";
    })
    .controller("coursesController", function ($scope) {
        $scope.message = "Course Page !!!";
        $scope.courses = ["C#.NET", "ASP.NET", "SQL Server", "AngularJS"];
    })
    .controller("studentsController", function ($scope, $http, $route) {
        $scope.message = "Student Page !!!";

        $scope.reloadData = function () {
            debugger;
            $route.reload();
        }

        var successCallback = function (response) {
            $scope.employees = response.data;
        };
        var errorCallback = function (reason) {
            $scope.error = reason.status;
        };

        $http.get("http://localhost:53830/api/Employee")
            .then(successCallback, errorCallback);
    })
    .controller("studentDetailsController", function ($scope, $http, $routeParams) {
        $scope.message = "Student Details Page !!";

        var successCallback = function (response) {
            $scope.employee = response.data;
        };
        var errorCallback = function (reason) {
            $scope.error = reason.status;
        };

        //http://localhost:53830/api/Employee/1

        $http({
            url: "http://localhost:53830/api/Employee",
            params: { id: $routeParams.id },
            method: "GET"
        }).then(successCallback, errorCallback);

    })