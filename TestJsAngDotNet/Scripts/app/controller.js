(function () {
    "use strict";

    angular.module("TestAngApp").controller("Controller", function ($scope) {
        $scope.elements = [{ id: 0, name: 'test1' }, { id: 1, name: 'test1234' }];
        $scope.element = $scope.elements[0];
        $scope.elementInfo = {};

        $scope.$watch("element", function (newValue, oldValue) {
            if (newValue === oldValue) {
                return;
            }

            $scope.onSelect(newValue);
        });

        // открыть соединение через вебсокет
        $scope.websocket = function () {
            var result = new WebSocket('ws:/localhost:53394/WebSocketHandler.ashx');

            result.onopen = function () {
                result.send(JSON.stringify({ action: 10 }));
            };

            result.onmessage = function (message) {
                var data = JSON.parse(message.data);

                switch (data.action) {
                    case 10: {
                        $scope.fillSelector(data.data);
                    }
                    case 20: {
                        $scope.fillInfo(data.data);
                    }
                }
            };

            return result;
        }();

        $scope.onSelect = function (value) {
            $scope.websocket.send(JSON.stringify({ action: 20, data: value }));
        };
        $scope.fillSelector = function (value) {
            $scope.$apply(function () {
                $scope.elements = value;
                $scope.element = $scope.elements[0];
            })
        };
        $scope.fillInfo = function (value) {
            $scope.$apply(function () { $scope.elementInfo = value; })
        };
    });
})();