

$(function () {

    ko.validation.init({
        errorElementClass: "wrong-field",
        decorateElement: true,
        errorClass: 'wrong-field'

    }, true);

    var modelCreateCategory = function () {
        var self = this;
        self.validateNow = ko.observable(false);
        self.Category_ID = ko.observable(),
        self.Category_Name = ko.observable().extend({
            required: {
                message: "category name is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            }
        });
        self.Category_Description = ko.observable().extend({
            required: {
                message: "category description is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            }
        });

            self.createCategory = function () {
                self.validateNow(true);
                $('div.alert-danger').hide();
                if (self.errors().length === 0) {
                    try {
                        $.ajax({
                            url: '/Category/AddCategory',
                            type: 'post',
                            dataType: 'json',
                            data: ko.toJSON(this), //Here the data wil be converted to JSON
                            contentType: 'application/json',
                            success: successCallback,
                            error: errorCallback
                        });
                    } catch (e) {
                        window.location.href = '/Category/Index/';
                    }
                } else {
                    self.errors.showAllMessages();
                    $('div.alert-danger').show();
                    //alert('Please enter category name');

                }


            };
        self.errors = ko.validation.group(self);
    };

    var viewModel = new modelCreateCategory();
    ko.applyBindings(viewModel);

});

function successCallback(data) {
    bootbox.alert("Category Added successfully!");
    window.location.href = '/Category/Index/';
}
function errorCallback(err) {
    window.location.href = '/Category/Index/';


}









