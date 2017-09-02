var _data;
$("#btnGet").click(function () {
    var url = $("#txtTest").val();
    var json;
    try {
        json = JSON.parse($("#txtJSON").val())
    } catch (e) {
        json = "";
    }
    $(".label").attr("class", "label");
    $.ajax({
        type: "GET",
        url: url,
        data: json,
        dataType: "json",
        success: function (data) {
            _data = data;
            $(".label").addClass("label-success");
            $(".label").text("OK");
        },
        error: function (data) {
            _data = data.responseText;
            $(".label").addClass("label-danger");
            $(".label").text("error");
        }
    });
});
$("#btnPost").click(function () {
    var url = $("#txtTest").val();
    var json;
    try {
        json = JSON.parse($("#txtJSON").val())
    } catch (e) {
        json = "";
    }

    $(".label").attr("class", "label");
    $.ajax({
        type: "POST",
        url: url,
        data: json,
        dataType: "json",
        success: function (data) {
            _data = data;
            $(".label").addClass("label-success");
            $(".label").text("OK");
        },
        error: function (data) {
            _data = data.responseText;
            $(".label").addClass("label-danger");
            $(".label").text("error");
        }
    });
});
$("#selGroup").change(function () {
    location = $("#selGroup :selected").attr("url");
});
$("#apiList>tbody>tr").dblclick(function () {
    var url = $(this).find("[name='url']").text();
    var txtJson = $(this).find("[name='par']").text();
    $("#txtTest").val(url);
    $("#txtJSON").val(txtJson);
});
$(window).scroll(function () {
    if ($(window).scrollTop() > $(".tool").offset().top - 50) {
        $(".tool-in").addClass("pin");
        $(".tool-in").width($(".tool").parent().width());
    } else {
        $(".tool-in").removeClass("pin");
    }
});
$(window).resize(function () {
    $(".tool-in").width($(".tool").parent().width());
});