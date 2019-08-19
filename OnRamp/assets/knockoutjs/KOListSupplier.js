
$(function () {
    $("#liSupplier").addClass("active");
    ko.applyBindings(modelView);
    modelView.viewSuppliers();

    $(document).on("click", ".btnDelete", function (e) {
        bootbox.confirm({
            message: "Are you sure! You want remove this supplier?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) { 
                if (result) {
                    $.get("/Supplier/Delete?id=" + e.target.parentElement.id, function (data) {
                        if (data) {
                            bootbox.alert("Supplier deleted successfully!", function () {

                                location.reload();
                            });
                            modelView.removeSupplier(e);
                        }
                    });
                }
            }
        });
    });
});



var modelView = {
    suppliers: ko.observableArray([]),
    viewSuppliers: function () {
        var thisObj = this;
        try {
            $.ajax({
                url: '/Supplier/GetList',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    thisObj.suppliers(data); //Here we are assigning values to KO Observable array
                    //$("#suppliertable").DataTable();
                    $('#suppliertable').DataTable({
                        dom: 'Bfrtip',
                        "pageLength": 20,
                        "lengthChange": true,
                        buttons: [
                            {
                                extend: 'excelHtml5', exportOptions: {
                                    columns: [0, 1, 2, 3]
                                }
                            },
                            {
                                extend: 'csvHtml5', exportOptions: {
                                    columns: [0, 1, 2, 3]
                                }
                            },
                            {
                                extend: 'pdfHtml5', exportOptions: {
                                    columns: [0, 1, 2, 3]
                                }
                            }
                        ]
                    });
                },
                error: function (err) {
                    alert(err.status + " : " + err.statusText);
                }
            });
        }
        catch (e) {
            // window.location.href = '/Home/Read/';
        }
    },
    removeSupplier: function (e) {
        this.suppliers.splice(parseInt(e.target.parentElement.attributes['rowindex'].value), 1);        
    }
};




