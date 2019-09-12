// JQuerry

$(function () {
    $('#categoria-select').select2({
        ajax: {
            url: '/categoria/select2',
            dataType: 'json'
        }
    });

});
