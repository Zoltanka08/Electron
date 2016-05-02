
    $(function () {
        $("form").submit(function () {
            var selTypeText = $("#id option:selected").text();
            $("#hidText").val(selTypeText);
        });
    });
