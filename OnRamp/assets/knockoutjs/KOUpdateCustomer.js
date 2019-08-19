

var parsedSelectedCustomer = $.parseJSON(selectedCustomer);

$(function () {
    ko.validation.init({
        errorElementClass: "wrong-field",
        decorateElement: true,
        errorClass: 'wrong-field'

    }, true);


    var modelUpdate = function () {

        var self = this;
        self.validateNow = ko.observable(false);
        self.Customer_ID = ko.observable(parsedSelectedCustomer.Customer_ID),
            self.Customer_Name = ko.observable(parsedSelectedCustomer.Customer_Name).extend({
                required: {
                    message: "customer name is required",
                    onlyIf: function () {
                        return self.validateNow();
                    }
                }
            });
        self.Customer_Email = ko.observable(parsedSelectedCustomer.Customer_Email).extend({
            required: {
                message: "customer email is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            },
            email: true

        });

        self.Customer_Telephone_Number = ko.observable(parsedSelectedCustomer.Customer_Telephone_Number),

            self.updateCustomer = function () {
            self.validateNow(true);
            if (self.errors().length === 0) {
                try {
                    $.ajax({
                        url: '/Customer/Update',
                        type: 'post',
                        dataType: 'json',
                        data: ko.toJSON(this), //Here the data wil be converted to JSON
                        contentType: 'application/json',
                        success: successCallback,
                        error: errorCallback
                    });
                }
                catch (e) {
                    window.location.href = '/Customer/Index/';
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
    bootbox.alert("Customer Updated successfully!");
    window.location.href = '/Customer/Index/';
}
function errorCallback(err) {
    window.location.href = '/Customer/Index/';

}