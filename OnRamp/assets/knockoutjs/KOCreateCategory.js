

$(function () {
    ko.applyBindings(modelCreateCategory);
});

var modelCreateCategory = {
    Category_ID: ko.observable(),
    Category_Name: ko.observable(),
    Category_Description: ko.observable(),
    createCategory: function () {
        try {
            $.ajax({
                url: '/Category/AddCategory',
                type: 'post',
                dataType: 'json',
                data: ko.toJSON(this), //Here the data wil be converted to JSON
                contentType: 'application/json',
                success: successCallback,
                error: errorCallback
            });
        } catch (e) {
            window.location.href = '/Category/Index/';
        }
    }
};
function successCallback(data) {
    bootbox.alert("Category Added successfully!");
    window.location.href = '/Category/Index/';
}
function errorCallback(err) {
    window.location.href = '/Category/Index/';
    
    
}