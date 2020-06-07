var app = angular.module('apimodule', []);

app.service('logservice', function ($http) {
    this.save = function (sub) {
        console.log("aaaaaaaaaaa", sub);
        return $http({
            method: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Data/SaveCourseType?strJson=" + sub

        });
    };
    this.update = function (sub, id) {
        console.log("aaaaaaaaaaa", sub);
        return $http({
            method: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: "/Data/UpdateCourseType?strJson=" + sub + "&id=" + id

        });
    };
    this.delete = function (sub, id) {
        console.log("aaaaaaaaaaa", sub);
        return $http({
            method: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Data/DeleteCourseType?strJson=" + sub + "&id=" + id

        });
    };
    this.load = function () {
        console.log("ppppppppppppppp");
        return $http({
            method: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Data/GetAllCourseType"

        });
    };

});

 
app.controller('MainCtrl', function ($scope, $http, $window, logservice) {

    let vm = this,
        addressCollection = [],
        isEditing = false;

    // functions that are not attached to the view model
    let add = function () {
        let isValiForSaving = false;
        for (let propertyName in vm.lecture) {
            if (vm.lecture[propertyName].length > 0) {
                isValiForSaving = true;
            }
        }

        if (isValiForSaving) {
            let newPerson = {};

            if (!angular.equals({}, vm.lecture)) {
                if (isEditing !== false) {

                    console.log("aa", isEditing);
                    console.log("data", vm.lecture);

                    var editlecture = vm.lecture;

                    var JsonEditString = JSON.stringify(vm.lecture);

                    var updateData = logservice.update(JsonEditString, isEditing)
                    var result = false;

                    updateData.then(function (d) {

                        console.log("Update - Succss", editlecture);
                        console.log("vm.lecture", vm.lecture);



                        addressCollection[isEditing] = editlecture;
                        isEditing = false;
                        result = true;

                    }, function (error) {
                        result = false;
                        console.log("Oops! Something went wrong while fetching the data.");
                        alert("Oops! Something went wrong while fetching the data.");
                    });

                    //if (result === true) {
                    //    console.log("Res");
                    //    addressCollection[isEditing] = vm.lecture;
                    //    isEditing = false;
                    //};

                } else {
                    newPerson = vm.lecture;
                    console.log("xxxxx", newPerson);
                    var JsonString = JSON.stringify(newPerson);
                    var savejson = vm.lecture;

                    var saveData = logservice.save(JsonString)

                    saveData.then(function (d) {

                        console.log("Succss");
                        console.log("NewPERSON", newPerson);
                        addressCollection.push(savejson);

                    }, function (error) {
                        console.log("Oops! Something went wrong while fetching the data.");
                    });


                }

                vm.addresses = addressCollection;
                vm.lecture = {};
            }
        }
    },
        edit = function (editPerson) {
            isEditing = addressCollection.indexOf(editPerson);
            vm.lecture = angular.copy(editPerson);
        },
        remove = function (removePerson) {
            let index = addressCollection.indexOf(removePerson);
            var JsonString = JSON.stringify(removePerson);
            var savejson = removePerson;

            var deleteData = logservice.delete(JsonString, index)

            deleteData.then(function (d) {

                console.log("Succss-Delete");
                console.log("NewPERSON", removePerson, "-", index);


                addressCollection.splice(index, 1);
                if (addressCollection.length === 0) {
                    vm.lecture = {};
                    vm.addresses = undefined;
                }

            }, function (error) {
                console.log("Oops! Something went wrong while fetching the data.");
            });



        },
        reset = function () {
            vm.lecture = {};
            vm.search = '';
            isEditing = false;
        },
        load = function () {
            vm.lecture = {};
            vm.search = '';
            isEditing = false;
            let newData = {};

            var loadData = logservice.load()
            loadData.then(function (d) {

                console.log("Succss");

                var len = d.data.length;
                console.log("length", d.data.length);
                for (var i = 0; i < len; i++) {
                    console.log(i, "---", d.data[i]);
                    addressCollection.push(d.data[i]);
                }
                vm.addresses = addressCollection;
                vm.lecture = {};
            }, function (error) {
                console.log("Oops! Something went wrong while fetching the data.");
            });



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
    vm.pageLoad = function () {
        load();
    };
    vm.pageLoad();
});
