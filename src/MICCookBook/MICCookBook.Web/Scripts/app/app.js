// Base structure of the website
var COOKBOOK = {
    // Logic common to any controller
    common: {
        init: function () {
            $('#logoff').click(function () {
                $('#logoff-form').submit();
            });
        }
    }
};
