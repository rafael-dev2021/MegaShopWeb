$(document).ready(function () {
    $('.showDetailModel').on('click', function () {
        var id = $(this).data('id');
        $('#showModal_' + id).modal('show');
    });
});


