(function () {
    'use strict';
    angular.module('apimodule', []);
})();

(function () {
    'use strict';

    angular.module('apimodule').controller('MainCtrl', CoreFunction);

    function CoreFunction() {
        let vm = this,
            addressCollection = [],
            isEditing = false;

        // functions that are not attached to the view model
        let add = function () {
            let isValiForSaving = false;
            for (let propertyName in vm.subjects) {
                if (vm.subjects[propertyName].length > 0) {
                    isValiForSaving = true;
                }
            }

            if (isValiForSaving) {
                let newPerson = {};

                if (!angular.equals({}, vm.subjects)) {
                    if (isEditing !== false) {
                        addressCollection[isEditing] = vm.subjects;
                        isEditing = false;
                    } else {
                        newPerson = vm.subjects;
                        addressCollection.push(newPerson);
                    }

                    vm.addresses = addressCollection;
                    vm.subjects = {};
                }
            }
        },
            edit = function (editPerson) {
                isEditing = addressCollection.indexOf(editPerson);
                vm.subjects = angular.copy(editPerson);
            },
            remove = function (removePerson) {
                let index = addressCollection.indexOf(removePerson);
                addressCollection.splice(index, 1);
                if (addressCollection.length === 0) {
                    vm.subjects = {};
                    vm.addresses = undefined;
                }
            },
            reset = function () {
                vm.subjects = {};
                vm.search = '';
                isEditing = false;
            };

        // view model attached click handlers
        vm.addClickHandler = function () {
            add();
        };

        vm.editClickHandler = function (editPerson) {
            edit(editPerson);
        };

        vm.removeClickHandler = function (removePerson) {
            remove(removePerson);
        };

        vm.resetClickHandler = function () {
            reset();
        };
    }
})();
