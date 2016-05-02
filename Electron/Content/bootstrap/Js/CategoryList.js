
$(function () {
    $("form").submit(function () {
        var selTypeText = $("#Category_id option:selected").text();
        $("#hidText").val(selTypeText);
    });
});
