
$(function () {

    ko.validation.init({
        errorElementClass: "wrong-field",
        decorateElement: true,
        errorClass: 'wrong-field'

    }, true);

    var modelCreateSupplier = function () {
        var self = this;
        self.validateNow = ko.observable(false);
        self.Supplier_ID = ko.observable(),
            self.Supplier_Name = ko.observable().extend({
                required: {
                    message: "supplier name is required",
                    onlyIf: function () {
                        return self.validateNow();
                    }
                }
            });
        self.Supplier_Email = ko.observable().extend({
            required: {
                message: "supplier email is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            },
            email: true

        });
        self.Supplier_Telephone_Number = ko.observable().extend({
            required: {
                message: "supplier telephone number is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            }
        });

        self.createSupplier = function () {
                self.validateNow(true);
                if (self.errors().length === 0) {
                    try {
                        $.ajax({
                            url: '/Supplier/AddSupplier',
                            type: 'post',
                            dataType: 'json',
                            data: ko.toJSON(this), //Here the data wil be converted to JSON
                            contentType: 'application/json',
                            success: successCallback,
                            error: errorCallback
                        });
                    } catch (e) {
                        window.location.href = '/Supplier/Index/';
                    }
                } else {
                    self.errors.showAllMessages();
                }


            };
        self.errors = ko.validation.group(self);
    };

    var viewModel = new modelCreateSupplier();
    ko.applyBindings(viewModel);

});

function successCallback(data) {
    bootbox.alert("Supplier Added successfully!");
    window.location.href = '/Supplier/Index/';
}
function errorCallback(err) {
    window.location.href = '/Supplier/Index/';


}

