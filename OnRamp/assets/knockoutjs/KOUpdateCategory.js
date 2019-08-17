

var parsedSelectedCategory = $.parseJSON(selectedCategory);
$(function () {
    ko.applyBindings(modelUpdate);
});
var modelUpdate = {
    Category_ID: ko.observable(parsedSelectedCategory.Category_ID),
    Category_Name: ko.observable(parsedSelectedCategory.Category_Name),
    Category_Description: ko.observable(parsedSelectedCategory.Category_Description),

    updateCategory: function () {
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
};
function successCallback(data) {
    bootbox.alert("Category Updated successfully!");
    window.location.href = '/Category/Index/';
}
function errorCallback(err) {
    window.location.href = '/Category/Index/';

}