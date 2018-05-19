var viewPort = {
    width: jQuery(window).width(),
    height: jQuery(window).height()
};

jQuery(document).ready(function () {

    initSubscribeForm();
});

function initSubscribeForm() {

    if (jQuery('#subscribeForm').length > 0) {
        jQuery("#subscribeForm").validate({
            rules:
                {
                    EmailAddress:
                        {
                            required: true,
                            email: true
                        }
                },
            messages:
                {
                    EmailAddress:
                        {
                            required: '',
                            email: 'Please Enter A VALID Email Address!'
                        }
                },
            submitHandler: function (form) {
                var inputEmailAddress = $(emailAddress).val().trim();
                var model = { emailAddress: inputEmailAddress };
                $.ajax(
                    {
                        url: urlCommon.SubscribeToNewsletter,
                        contentType: "application/json; charset=utf-8",
                        async: true,
                        type: 'POST',
                        cache: false,
                        dataType: "json",
                        data: JSON.stringify(model),
                        beforeSend: function () {
                            ShowWaitModal();
                        },
                        success: function (data) {
                            $(form)[0].reset();
                            if (data) {
                                _toastr("SUCCESS!", "top-full-width", "success", false);
                            }
                            else {
                                _toastr("ERROR!", "top-full-width", "error", false);
                            }
                            $('#ShowWaitModal').modal('hide');
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            _toastr("ERROR!", "top-full-width", "error", false);
                            $('#ShowWaitModal').modal('hide');
                            alert("error");
                            alert(jqXHR.responseText);
                        }
                    });
            },
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            }
        });
    };
}

function ShowWaitModal() {
    alignShowWaitModal();
    $('#ShowWaitModal').modal('show');
}

function alignShowWaitModal() {

    var modalDialog = $('#ShowWaitModal').find(".modal-dialog");
    var vHeight = viewPort.height;
    var val = Math.max(0, ($(window).height() - modalDialog.height()) / 2);

    if (viewPort.width < 768) {
        modalDialog.css("margin-top", "25%");
    }
    else {
        modalDialog.css("margin-top", "10%");
    }

}