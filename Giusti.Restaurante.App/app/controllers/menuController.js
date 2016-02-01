'use strict';

app.controller("menuController", function ($scope, $http, $routeParams) {
    $scope.heading = "Pratos";
    $scope.pratos = [];
    $scope.mesa = {};

    //GET API
    var url = '/api/prato';
    $scope.getPratos = function () {
    
        $http.get(url).success(function (data) {
            $scope.pratos = data;
            $scope.getMesa();
        }).error(function (jqxhr, textStatus) {
            $scope.showAlert(jqxhr.message);
        })
    };

    //GET API
    var urlMesa = '/api/mesa';
    $scope.getMesa = function () {
        if (!angular.isUndefined($routeParams.id)) {
            $scope.id = $routeParams.id;
        }

        $http.get(urlMesa + '/' + $scope.id).success(function (data) {
            $scope.mesa = data;
        }).error(function (jqxhr, textStatus) {
            $scope.showAlert(jqxhr.message);
        });
    };

    //GET API
    var urlCategoria = '/api/categoria';
    $scope.getCategorias = function () {
        $http.get(urlCategoria).success(function (data) {
            $scope.categorias = data;
        }).error(function (jqxhr, textStatus) {
            $scope.showAlert(jqxhr.message);
        });
    };

    $scope.getPratoMesa = function (pratoId) {
        var total = 0;
        
            for (var i = 0; i < $scope.mesa.pedidos[0].pedidoPratos.length; i++) {
                var prato = $scope.mesa.pedidos[0].pedidoPratos[i];
                if (prato.situacao != '2' && prato.pratoId == pratoId) {
                    total++;
                }
            }
        return total;
    };

    $scope.incluiOpcoes = function(prato, opcoes){
        if(prato.opcoes){
            prato.opcoes = null;
        }
        else{
        prato.opcoes = opcoes;
        }
    };

    $scope.incluiPrato = function (prato) {
        $scope.mesaOld = angular.copy($scope.mesa);
        $scope.mesa.pedidos[0].pedidoPratos.push({ 'pedidoId': $scope.mesa.pedidos[0].id, 'pratoId': prato.id, 'opcoes': prato.opcoes, 'situacao': 0 });
        $scope.putMesa();
    };

    //PUT API
    $scope.putMesa = function () {
        
        $http.put(urlMesa + '/' + $scope.id, JSON.stringify($scope.mesa)).success(function (data) {
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