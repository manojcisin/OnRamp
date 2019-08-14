$(document).ready(function (evt) {
    
    $('#fileupload').fileupload({
        dataType: 'json',
        add: function (e, data) {
            //$('#btnFileAttach').attr("disabled", "disabled");
            //var selectedFile = data.files[0];
            //var ext = data.files[0].name.split('.').pop().toLowerCase();
            //var index = data.files[0].name.lastIndexOf(".");
            //var fileName = data.files[0].name.substring(0, index);

            //var regexPattern = /[#%&*:<>?/{|}]/;
            //if (regexPattern.test(fileName)) {
            //    $('#btnFileAttach').removeAttr("disabled");
            //    _ShowSimplePopUpAuto("Alert", 'Invalid file name! File name should not contain these characters # % & * : < > ? /  { | }');
            //}
              
            //else if (selectedFile.size > 5242880) {
            //    $('#btnFileAttach').removeAttr("disabled");
            //    _ShowSimplePopUpAuto("Alert", "File size exceeds maximum size (5 MB)!");
            //}

            //else {
            //    var isValide = selectFile(selectedFile);
            //    if (isValide) {
                data.submit();
            //    }
            //}
        },
        done: function (e, data) {
            //var attachedFiles = $('.clsFileChk');
            //var fileCount = attachedFiles.length;
            //if ($("#hidDeleteFileCount") != null && $("#hidDeleteFileCount") != "undefined") {
            //    var deleteCount = parseInt($("#hidDeleteFileCount").val());
            //    fileCount = fileCount + deleteCount;
            //}
            //$("#fileUploadImg" + fileCount).attr("title", data.result);
            //if (data.result.Status == "Done") {
            //    $("#fileUploadImg" + fileCount).attr("src", "./Content/images/tick-mark-green.gif");
            //    $("#download" + fileCount).attr('<a href="' + data.result.FileName + '"/>');
            //    $("#hdnFileName" + fileCount).val(data.result.FileName);
            //    $("label[for=chk" + fileCount + "]").removeClass("checkbox_unchecked").addClass("checkbox_checked");
            //}
            //else {
            //    $("#fileUploadImg" + fileCount).attr("src", "./Content/images/errorIcon.gif");
            //}
            //$('#btnFileAttach').removeAttr("disabled");
        }
    });

});