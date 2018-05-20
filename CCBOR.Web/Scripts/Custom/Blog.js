$(document).ready(function () {
    $('#blog2-btn').click(function () {
        if ($('#blog2-btn').html() == "READ MORE") 
            $("#blog2-btn").text('READ LESS');
        else 
            $("#blog2-btn").text('READ MORE');
    })

    $('#blog5-btn').click(function () {
        if ($('#blog5-btn').html() == "READ MORE")
            $("#blog5-btn").text('READ LESS');
        else
            $("#blog5-btn").text('READ MORE');
    })
});