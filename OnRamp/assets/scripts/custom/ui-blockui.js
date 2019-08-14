var UIBlockUI = function () {

    var handleSample1 = function () {

        $('#blockui_sample_1_1').click(function(){
            Metronic.blockUI({
                target: '#blockui_sample_1_portlet_body'
            });

            window.setTimeout(function () {
                Metronic.unblockUI('#blockui_sample_1_portlet_body');
            }, 2000);
        });

        $('#blockui_sample_1_2').click(function(){
            Metronic.blockUI({
                target: '#blockui_sample_1_portlet_body',
                boxed: true
            });

            window.setTimeout(function () {
                Metronic.unblockUI('#blockui_sample_1_portlet_body');
            }, 2000);
        });
    }

    var handleSample2 = function () {

        $('#blockui_sample_2_1').click(function(){
            Metronic.blockUI();

            window.setTimeout(function () {
                Metronic.unblockUI();
            }, 2000);
        });

        $('#blockui_sample_2_2').click(function(){
            Metronic.blockUI({boxed: true});

            window.setTimeout(function () {
                Metronic.unblockUI();
            }, 2000);
        });


        $('#blockui_sample_2_3').click(function(){
            Metronic.startPageLoading('Please wait...');

            window.setTimeout(function () {
                Metronic.stopPageLoading();
            }, 2000);
        });

    }

    var handleSample3 = function () {

         $('#blockui_sample_3_1_0').click(function(){
            Metronic.blockUI({
                target: '#basic',
                overlayColor: 'none',
                cenrerY: true,
                boxed: true
            });

            window.setTimeout(function () {
                Metronic.unblockUI('#basic');
            }, 2000);
        });

         $('#blockui_sample_3_1').click(function(){
            Metronic.blockUI({
                target: '#blockui_sample_3_1_element',
                overlayColor: 'none',
                boxed: true
            });
        });

         $('#blockui_sample_3_1_1').click(function(){
            Metronic.unblockUI('#blockui_sample_3_1_element');
        });

        $('#blockui_sample_3_2').click(function(){
            Metronic.blockUI({
                target: '#blockui_sample_3_2_element',
                boxed: true
            });
        });

         $('#blockui_sample_3_2_1').click(function(){
            Metronic.unblockUI('#blockui_sample_3_2_element');
        });



    }

    var handleSample4 = function() {
        Metronic.blockUI({
            target: 'html',
            boxed: true

        });
        
    };

   
    return {
        //main function to initiate the module
        init: function () {
            handleSample4();

        }

    };

}();