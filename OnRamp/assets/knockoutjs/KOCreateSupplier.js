

$(function () {
    ko.applyBindings(modelCreateSupplier);
});

var modelCreateSupplier = {
    Supplier_ID: ko.observable(),
    Supplier_Name: ko.observable(),
    Supplier_Email: ko.observable(),
    Supplier_Telephone_Number: ko.observable(),
    createSupplier: function () {
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
    }
};
function successCallback(data) {
    bootbox.alert("Supplier Added successfully!");
    window.location.href = '/Supplier/Index/';
}
function errorCallback(err) {
    window.location.href = '/Supplier/Index/';


}