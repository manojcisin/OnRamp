var FormImageCrop = function () {


    var demo3 = function() {
        // Create variables (in this scope) to hold the API and image size
        var jcrop_api,
            boundx,
            boundy,
            // Grab some information about the preview pane
            $preview = $('#preview-pane'),
            $pcnt = $('#preview-pane .preview-container'),
            $pimg = $('#preview-pane .preview-container img'),

            xsize = $pcnt.width(),
            ysize = $pcnt.height();

        console.log('init', [xsize, ysize]);

        $('#demo3').Jcrop({
            onChange: updatePreview,
            onSelect: updatePreview,
            aspectRatio: xsize / ysize
        }, function() {
            // Use the API to get the real image size
            var bounds = this.getBounds();
            boundx = bounds[0];
            boundy = bounds[1];
            // Store the API in the jcrop_api variable
            jcrop_api = this;
            // Move the preview into the jcrop container for css positioning
            $preview.appendTo(jcrop_api.ui.holder);
        });

        function updatePreview(c) {
            if (parseInt(c.w) > 0) {
                var rx = xsize / c.w;
                var ry = ysize / c.h;

                $pimg.css({
                    width: Math.round(rx * boundx) + 'px',
                    height: Math.round(ry * boundy) + 'px',
                    marginLeft: '-' + Math.round(rx * c.x) + 'px',
                    marginTop: '-' + Math.round(ry * c.y) + 'px'
                });
                showCoords();
            }
        };
        function getRandom() {
            var dim = jcrop_api.getBounds();
            return [
                Math.round(Math.random() * dim[0]),
                Math.round(Math.random() * dim[1]),
                Math.round(Math.random() * dim[0]),
                Math.round(Math.random() * dim[1])
            ];
        };
        function showCoords(c) {
            $('#x1').val(c.x);
            $('#y1').val(c.y);
            $('#x2').val(c.x2);
            $('#y2').val(c.y2);
            $('#w').val(c.w);
            $('#h').val(c.h);
        };


    };
    
 


    var handleResponsive = function() {
        if ($(window).width() <= 1024 && $(window).width() >= 678) {
            $('.responsive-1024').each(function() {
                $(this).attr("data-class", $(this).attr("class"));
                $(this).attr("class", 'responsive-1024 col-md-12');
            });
        } else {
            $('.responsive-1024').each(function() {
                if ($(this).attr("data-class")) {
                    $(this).attr("class", $(this).attr("data-class"));
                    $(this).removeAttr("data-class");
                }
            });
        }
    };

    return {
        //main function to initiate the module
        init: function () {
            
            if (!jQuery().Jcrop) {
                return;
            }
            Metronic.addResizeHandler(handleResponsive);
            handleResponsive();
            demo3();
       
        }

    };

}();