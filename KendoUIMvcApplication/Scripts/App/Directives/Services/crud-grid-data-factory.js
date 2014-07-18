app.factory('crudGridDataFactory', ['$http', '$resource', function ($http, $resource) {
    return function (type) {
        //var host = $location.host();
        //if (host === "localhost")
        //    host += ":" + $location.port();
        //var url = $location.protocol() + "://" + host + "/api/";
        return $resource('/api/' + type + '/:id', { id: '@id' }, { 'update': { method: 'PUT' } }, { 'query': { method: 'GET', isArray: false } });
    };
}]);