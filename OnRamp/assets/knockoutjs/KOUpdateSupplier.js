

var parsedSelectedSupplier = $.parseJSON(selectedSupplier);
$(function () {
    ko.applyBindings(modelUpdate);
});
var modelUpdate = {
    Supplier_ID: ko.observable(parsedSelectedSupplier.Supplier_ID),
    Supplier_Name: ko.observable(parsedSelectedSupplier.Supplier_Name),
    Supplier_Email: ko.observable(parsedSelectedSupplier.Supplier_Email),
    Supplier_Telephone_Number: ko.observable(parsedSelectedSupplier.Supplier_Telephone_Number),

    updateSupplier: function () {
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
};
function successCallback(data) {
    bootbox.alert("Supplier Updated successfully!");
    window.location.href = '/Supplier/Index/';
}
function errorCallback(err) {
    window.location.href = '/Supplier/Index/';

}