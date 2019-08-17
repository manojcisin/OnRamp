

var parsedSelectedCustomer = $.parseJSON(selectedCustomer);
$(function () {
    ko.applyBindings(modelUpdate);
});
var modelUpdate = {
    Customer_ID: ko.observable(parsedSelectedCustomer.Customer_ID),
    Customer_Name: ko.observable(parsedSelectedCustomer.Customer_Name),
    Customer_Email: ko.observable(parsedSelectedCustomer.Customer_Email),
    Customer_Telephone_Number: ko.observable(parsedSelectedCustomer.Customer_Telephone_Number),

    updateCustomer: function () {
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
};
function successCallback(data) {
    bootbox.alert("Customer Updated successfully!");
    window.location.href = '/Customer/Index/';
}
function errorCallback(err) {
    window.location.href = '/Customer/Index/';

}