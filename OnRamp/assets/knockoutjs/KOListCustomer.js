    $(function () {

        $("#liCustomer").addClass("active");
    ko.applyBindings(modelView);
    modelView.viewCustomers();

        $(document).on("click", ".btnDelete", function (e) {
        bootbox.confirm({
            message: "Are you sure! You want remove this customer?",
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
                    $.get("/Customer/Delete?id=" + e.target.id, function (data) {
                        if (data) {
                            bootbox.alert("Customer deleted successfully!");
                            $("#customertable tbody").empty();
                            modelView.viewCustomers();
                        }
                    });
                }
            }
        });
    });
});
    var modelView = {
        customers: ko.observableArray([]),
        viewCustomers: function () {
            var thisObj = this;
            try {
        $.ajax({
            url: '/Customer/GetList',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                thisObj.customers(data); //Here we are assigning values to KO Observable array
                //$("#customertable").DataTable();
                $('#customertable').DataTable({
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
    } catch (e) {
        //window.location.href = '/Home/Read/';
    }
    }
};




