(function ($, document) {
    "use strict";
    var $document = $(document);

    function submitForm(e) {
        e.preventDefault();

        var $form = $(e.currentTarget),
            $q = $form.find('[data-quantity]');
        console.log($q.val());
    }

    $document.on('submit', 'form[data-form]', submitForm);

})(jQuery, document);