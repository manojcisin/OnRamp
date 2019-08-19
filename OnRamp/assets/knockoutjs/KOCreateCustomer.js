
$(function () {

    ko.validation.init({
        errorElementClass: "wrong-field",
        decorateElement: true,
        errorClass: 'wrong-field'

    }, true);

    var modelCreateCustomer = function () {
        var self = this;
        self.validateNow = ko.observable(false);
        self.Customer_ID = ko.observable(),
            self.Customer_Name = ko.observable().extend({
                required: {
                    message: "customer name is required",
                    onlyIf: function () {
                        return self.validateNow();
                    }
                }
            });
        self.Customer_Email = ko.observable().extend({
            required: {
                message: "customer email is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            },
            email: true 
          
        });
        self.Customer_Telephone_Number = ko.observable(),


            self.createCustomer = function () {
            self.validateNow(true);
            if (self.errors().length === 0) {
                try {
                    $.ajax({
                        url: '/Customer/AddCustomer',
                        type: 'post',
                        dataType: 'json',
                        data: ko.toJSON(this), //Here the data wil be converted to JSON
                        contentType: 'application/json',
                        success: successCallback,
                        error: errorCallback
                    });
                } catch (e) {
                    window.location.href = '/Customer/Index/';
                }
            } else {
                self.errors.showAllMessages();
            }


        };
        self.errors = ko.validation.group(self);
    };

    var viewModel = new modelCreateCustomer();
    ko.applyBindings(viewModel);

});

function successCallback(data) {
    bootbox.alert("Customer Added successfully!");
    window.location.href = '/Customer/Index/';
}
function errorCallback(err) {
    window.location.href = '/Customer/Index/';
}









