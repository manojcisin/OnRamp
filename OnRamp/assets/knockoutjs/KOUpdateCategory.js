

var parsedSelectedCategory = $.parseJSON(selectedCategory);
$(function () {
    ko.validation.init({
        errorElementClass: "wrong-field",
        decorateElement: true,
        errorClass: 'wrong-field'

    }, true);
    var modelUpdate = function () {

        var self = this;
        self.validateNow = ko.observable(false);
        self.Category_ID = ko.observable(parsedSelectedCategory.Category_ID),
            self.Category_Name = ko.observable(parsedSelectedCategory.Category_Name).extend({
                required: {
                    message: "category name is required",
                    onlyIf: function () {
                        return self.validateNow();
                    }
                }
            });
        self.Category_Description = ko.observable(parsedSelectedCategory.Category_Description).extend({
            required: {
                message: "category description is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            }
        });

        self.updateCategory = function () {
            self.validateNow(true);
            if (self.errors().length === 0) {
                try {
                    $.ajax({
                        url: '/Category/Update',
                        type: 'post',
                        dataType: 'json',
                        data: ko.toJSON(this), //Here the data wil be converted to JSON
                        contentType: 'application/json',
                        success: successCallback,
                        error: errorCallback
                    });
                }
                catch (e) {
                    window.location.href = '/Category/Index/';
                }
            }
            else {
                self.errors.showAllMessages();
            }


        };
        self.errors = ko.validation.group(self);
    };
    var viewModel = new modelUpdate();
    ko.applyBindings(viewModel);
});


function successCallback(data) {
    bootbox.alert("Category Updated successfully!");
    window.location.href = '/Category/Index/';
}
function errorCallback(err) {
    window.location.href = '/Category/Index/';

}