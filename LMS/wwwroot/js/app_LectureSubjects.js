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
            for (let propertyName in vm.LectureSubjects) {
                if (vm.LectureSubjects[propertyName].length > 0) {
                    isValiForSaving = true;
                }
            }

            if (isValiForSaving) {
                let newPerson = {};

                if (!angular.equals({}, vm.LectureSubjects)) {
                    if (isEditing !== false) {
                        addressCollection[isEditing] = vm.LectureSubjects;
                        isEditing = false;
                    } else {
                        newPerson = vm.LectureSubjects;
                        addressCollection.push(newPerson);
                    }

                    vm.addresses = addressCollection;
                    vm.LectureSubjects = {};
                }
            }
        },
            edit = function (editPerson) {
                isEditing = addressCollection.indexOf(editPerson);
                vm.LectureSubjects = angular.copy(editPerson);
            },
            remove = function (removePerson) {
                let index = addressCollection.indexOf(removePerson);
                addressCollection.splice(index, 1);
                if (addressCollection.length === 0) {
                    vm.LectureSubjects = {};
                    vm.addresses = undefined;
                }
            },
            reset = function () {
                vm.LectureSubjects = {};
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
