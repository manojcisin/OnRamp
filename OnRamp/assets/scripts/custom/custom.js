/**
Custom module for you to write your own javascript functions
**/

// Global Variables
var ModalBodyURL = '';

var Custom = function () {

    // private functions & variables

    var myFunc = function (text) {
        alert(text);
    };

    // public functions
    return {

        // Loads a modal body with dynamic HTML from a given URL function
        // Avoids errors with Google Maps not showing properly
        // USE -----------------------------------------------
        // Give the main modal div tag an ID value, as well as the modal body the same ID with the word "Body" at the end.
        // <button class="btn default" id="**buttonId**" ModalLoad-URL="** URL to load into the modal body **">** Button Text **</button>
        // Custom.ModalBodyDynamicLoad('** modalId **', '** buttonId **');
        // ---------------------------------------------------
        ModalBodyDynamicLoad: function (modalId, buttonId) {
            //alert(modalId,+" "+ buttonId);

            $('#' + buttonId).live("click", function () {


                // If the URL varabile is null, do not do anything
                if (!$(this).attr('ModalLoad-URL')) return;

                // Set the global variable ModalBodyURL
                ModalBodyURL = $(this).attr('ModalLoad-URL');

                // Clear the modal body of HTML
                $('#' + modalId + 'Body').html();

                // Begin the modal popup animation
                $('#' + modalId).modal('show');
            });

            $("#btnClose").live("click", function () {
                var locId = ModalBodyURL.split("=")[1];

                window.location = '/Location/ViewLocation/' + locId;
            });
            

            $('#' + modalId).on('shown.bs.modal', function () {
                // Gets the HTML to populate the modal body
                var details = $.get(ModalBodyURL);

                // Once complete, populate modal body with the HTML returned
                details.done(function (html) {
                    $('#' + modalId + 'Body').html(html);
                });

                // If it fails, write the error to the console, and clear the modal body HTML
                details.fail(function (jqXHR, textStatus, errorThrown) {
                    console.error(errorThrown);
                    $('#' + modalId + 'Body').html('<span style="color: red">' + errorThrown + '</span>');
                });
            });
        }

    };

}();

/***
Usage
***/
//Custom.init();
//Custom.doSomeStuff();