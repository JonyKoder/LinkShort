// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(function () {
    const input = $('input');
    const addButton = $('#addLinkButton');

    input.on('input', function () {
        if (input.val().trim() !== '') {
            addButton.show();
        } else {
            addButton.hide();
        }
    });
});

// Write your JavaScript code.
