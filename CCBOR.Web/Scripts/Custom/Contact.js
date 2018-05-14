jQuery(document).ready(function () {
    loadScript(plugin_path + 'form.validate/jquery.form.min.js', function () {
        loadScript(plugin_path + 'form.validate/jquery.validation.min.js');
    });
    initContactForm();
});

function initContactForm() {

    loadScript(plugin_path + 'form.validate/jquery.form.min.js', function () {

        loadScript(plugin_path + 'form.validate/jquery.validation.min.js', function () {

            if (jQuery('#contactForm').length > 0) {

                jQuery("#contactForm").validate({
                    rules:
                        {
                            FullName:
                                {
                                    required: true
                                },
                            EmailAddress:
                                {
                                    required: true,
                                    email: true
                                },
                            PhoneNumber:
                                {
                                    required: false
                                },
                            Subject:
                                {
                                    required: true
                                },
                            Message:
                                {
                                    required: true,
                                    minlength: 10
                                }
                        },
                    messages:
                        {
                            FullName:
                                {
                                    required: '',
                                },
                            EmailAddress:
                                {
                                    required: '',
                                    email: 'Please Enter A VALID Email Address!'
                                },
                            Subject:
                                {
                                    required: ''
                                },
                            Message:
                                {
                                    required: ''
                                }
                        },
                    submitHandler: function (form) {
                        modelContact.FullName = $(fullName).val().trim();
                        modelContact.EmailAddress = $(emailAddress).val().trim();
                        modelContact.PhoneNumber = $(phoneNumber).val().trim();
                        modelContact.Subject = $(subject).val().trim();
                        modelContact.Message = $(message).val().trim();
                        $.ajax(
                            {
                                url: urlContact.SendContactForm,
                                contentType: "application/json; charset=utf-8",
                                async: true,
                                type: 'POST',
                                cache: false,
                                dataType: "json",
                                data: JSON.stringify(modelContact),
                                beforeSend: function () {
                                    ShowWaitModal();
                                },
                                success: function (data) {
                                    $(form)[0].reset();
                                    _toastr("MESSAGE SENT!", "top-full-width", "success", false);
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

        });
    });
}