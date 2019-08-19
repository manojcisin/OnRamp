    $(function () {
        $("#liOrder").addClass("active");
    ko.applyBindings(modelView);
    modelView.viewOrders();
});

    var modelView = {
        orders: ko.observableArray([]),
        viewOrders: function () {
            var thisObj = this;
            try {
        $.ajax({
            url: '/Order/GetList',
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                thisObj.orders(data); //Here we are assigning values to KO Observable array
                //$("#ordertable").DataTable();
                $('#ordertable').DataTable({
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
                //$(".drp").change(function (event) {
                //    debugger
                //})
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    } catch (e) {
        //window.location.href = '/Home/Read/';
    }
    },
    paymentStatus: [
            {name: 'Received', id: true },
            {name: 'Not Received', id: false },
],
productStatus: [
            {name: "Sold", id: 1 },
            {name: "Returned", id: 2 },
            {name: "Defective", id: 3 }
],
        updatePaymentStatus: function (obj, event) {
            var queryString = 'orderId=' + obj.Order_ID + '&paymentStatus=' + obj.Payment_Received
            $.get('/Order/UpdatePaymentStatusByOrderId?' + queryString, function (response) {
                if (response) {
        bootbox.alert("Payment status udpate successfully!");
    }
                else {
        bootbox.alert("Error Occured!");
    }
});
},
        updateProductStatus: function (obj, event) {
            var queryString = 'productBarcode=' + obj.Product_Barcode + '&productStatus=' + obj.Product_Status
            $.get('/Product/UpdateProductStatusByProductBarcode?' + queryString, function (response) {
                if (response) {
        bootbox.alert("Product Status udpate successfully!");
    }
                else {
        bootbox.alert("Error Occured!");
    }
});
}
};
