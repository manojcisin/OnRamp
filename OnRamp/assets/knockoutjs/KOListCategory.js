    $(function () {
        $("#liCategory").addClass("active");
        ko.applyBindings(modelView);
        modelView.viewCategory();

        $(document).on("click", ".btnDelete", function (e) {
            bootbox.confirm({
                message: "Are you sure! You want remove this category?",
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
                        $.get("/Category/Delete?id=" + e.target.parentElement.id, function (data) {
                            if (data) {
                                bootbox.alert("Category deleted successfully!", function () {

                                    location.reload();
                                });
                                modelView.removeCategory(e);
                               
                            }
                        });
                    }
                }
            });
        });
    });
    var modelView = {
        categories: ko.observableArray([]),
        viewCategory: function () {
            var thisObj = this;
            try {
                $.ajax({
                    url: '/Category/GetList',
                    type: 'GET',
                    dataType: 'json',
                    contentType: 'application/json',
                    success: function (data) {
                        thisObj.categories(data); //Here we are assigning values to KO Observable array
                        //$("#categorytable").DataTable();
                        $('#categorytable').DataTable({
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
        },
        removeCategory: function (e) {
            modelView.categories.splice(parseInt(e.target.parentElement.attributes['rowindex'].value), 1);
           
        }
    };