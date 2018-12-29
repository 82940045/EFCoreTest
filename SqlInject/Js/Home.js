//js
Test();

function Test() {
    var MobilePhone = $("#MobilePhone").val();
    $.ajax({
        url: "/Home/TestSqlIn",
        dataType: "json",
        type: "post",
        data: { MobilePhone: MobilePhone },
        success: function (data) {
            var dataObj = data;
            $.each(dataObj, function (index, item) {
                $("#menu" + item.Id).attr("src", item.Ico);
            });

        }
    });
}