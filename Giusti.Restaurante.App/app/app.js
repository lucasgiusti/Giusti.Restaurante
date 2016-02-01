var app = angular.module("app", ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/', { templateUrl: '/templates/mesa/mesas.html', controller: 'mesaController' });
        $routeProvider.when('/:id', { templateUrl: '/templates/mesa/mesa.html', controller: 'mesaController' });
        $routeProvider.when('/menu/:id', { templateUrl: '/templates/menu/menu.html', controller: 'menuController' });
        $locationProvider.html5Mode(true);
    });

app.filter('Situacao', function () {
    return function (input) {
        if (input == '0') {
            return 'Livre';
        }
        else if (input == '1') {
            return 'Aberta';
        }
        else if (input == '2') {
            return 'Fechada';
        }
    };
});