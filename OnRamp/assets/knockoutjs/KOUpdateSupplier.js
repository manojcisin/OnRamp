

var parsedSelectedSupplier = $.parseJSON(selectedSupplier);

$(function () {
    ko.validation.init({
        errorElementClass: "wrong-field",
        decorateElement: true,
        errorClass: 'wrong-field'

    }, true);


    var modelUpdate = function () {

        var self = this;
        self.validateNow = ko.observable(false);
        self.Supplier_ID = ko.observable(parsedSelectedSupplier.Supplier_ID),
            self.Supplier_Name = ko.observable(parsedSelectedSupplier.Supplier_Name).extend({
                required: {
                    message: "supplier name is required",
                    onlyIf: function () {
                        return self.validateNow();
                    }
                }
            });
        self.Supplier_Email = ko.observable(parsedSelectedSupplier.Supplier_Email).extend({
            required: {
                message: "supplier email is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            },
            email: true

        });

        self.Supplier_Telephone_Number = ko.observable(parsedSelectedSupplier.Supplier_Telephone_Number).extend({
            required: {
                message: "supplier telephone number is required",
                onlyIf: function () {
                    return self.validateNow();
                }
            }
        });

        self.updateSupplier = function () {
                self.validateNow(true);
                if (self.errors().length === 0) {
                    try {
                        $.ajax({
                            url: '/Supplier/Update',
                            type: 'post',
                            dataType: 'json',
                            data: ko.toJSON(this), //Here the data wil be converted to JSON
                            contentType: 'application/json',
                            success: successCallback,
                            error: errorCallback
                        });
                    }
                    catch (e) {
                        window.location.href = '/Supplier/Index/';
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
    bootbox.alert("Supplier Updated successfully!");
    window.location.href = '/Supplier/Index/';
}
function errorCallback(err) {
    window.location.href = '/Supplier/Index/';

}