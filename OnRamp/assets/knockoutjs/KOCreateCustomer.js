

$(function () {
    ko.applyBindings(modelCreateCustomer);
});

var modelCreateCustomer = {
    Customer_ID: ko.observable(),
    Customer_Name: ko.observable(),
    Customer_Email: ko.observable(),
    Customer_Telephone_Number: ko.observable(),
    createCustomer: function () {
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
    }
};
function successCallback(data) {
    bootbox.alert("Customer Added successfully!");
    window.location.href = '/Customer/Index/';
}
function errorCallback(err) {
    window.location.href = '/Customer/Index/';


}