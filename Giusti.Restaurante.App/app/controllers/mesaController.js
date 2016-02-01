'use strict';

app.controller("mesaController", function ($scope, $http, $routeParams) {
    $scope.heading = "Mesa";
    $scope.mesas = [];
    $scope.mesa = {};

    //GET API
    var url = '/api/mesa';
    $scope.getMesas = function () {

        $http.get(url).success(function (data) {
            $scope.mesas = data;
        }).error(function (jqxhr, textStatus) {
            $scope.showAlert(jqxhr.message);
        })
    };

    //GET API
    $scope.getMesa = function () {
        if (!angular.isUndefined($routeParams.id)) {
            $scope.id = $routeParams.id;
        }

        $http.get(url + '/' + $scope.id).success(function (data) {
            $scope.mesa = data;
        }).error(function (jqxhr, textStatus) {
            $scope.showAlert(jqxhr.message);
        });
    };

    $scope.AbrirMesa = function () {
        $scope.mesaOld = angular.copy($scope.mesa);
        $scope.mesa.situacao = '1';
        $scope.mesa.pedidos = [{ 'situacao': '0' }];
        $scope.putMesa();
    }

    $scope.FecharMesa = function () {
        $scope.mesaOld = angular.copy($scope.mesa);
        $scope.mesa.situacao = '2';
        $scope.mesa.pedidos[0].situacao = '1';
        $scope.putMesa();
    }

    $scope.LiberarMesa = function () {
        $scope.mesaOld = angular.copy($scope.mesa);
        $scope.mesa.situacao = '0';
        $scope.mesa.pedidos = [];
        $scope.putMesa();
    }

    $scope.CancelarItem = function (pedidoPrato) {
        $scope.mesaOld = angular.copy($scope.mesa);
        pedidoPrato.situacao = '2';
        $scope.putMesa();
    }

    $scope.EntregarItem = function (pedidoPrato) {
        $scope.mesaOld = angular.copy($scope.mesa);
        pedidoPrato.situacao = '1';
        $scope.putMesa();
    }

    //PUT API
    $scope.putMesa = function () {

        $http.put(url + '/' + $scope.id, JSON.stringify($scope.mesa)).success(function (data) {
            $scope.mesa = data;
        }).error(function (jqxhr, textStatus) {
            angular.copy($scope.mesaOld, $scope.mesa);
            $scope.showAlert(jqxhr.message);
        });
    };

    //ALERT
    $scope.showAlert = function (alerts) {
        try {
            var messages = JSON.parse(alerts).Messages;
            var message = '';
            for (var i = 0; i < messages.length; i++) {
                message += messages[i].Message;
            }
            alert(message);

        } catch (e) {
            alert(alerts);
        }
    };
});