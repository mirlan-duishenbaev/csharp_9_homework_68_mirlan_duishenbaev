// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('input[type=radio][name=roleChooser]').change(function () {
    if (this.value == 'applicant') {
        $('#userName').html('Имя пользователя');
    } else if (this.value == 'employer') {
        $('#userName').html('Наименование компании');
    }
});


$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        event.preventDefault();
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);

        console.log(url)
        $.get(decodedUrl).done(function (data) {
            console.log(data)
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
            .fail(error => console.log(error))
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
        })
    })
})