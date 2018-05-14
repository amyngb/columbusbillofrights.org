var viewPort = {
    width: jQuery(window).width(),
    height: jQuery(window).height()
};

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