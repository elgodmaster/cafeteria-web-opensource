$(function () {
    $('.modal').click(function () {
        $('<div/>').appendTo('body').dialog({
            close: function (event, ui) {
                dialog.remove();
            },
            modal: true,
            width: 300,
            title: "Asignar Perfiles ",
            position: "center",
            buttons: {
                "Aceptar": function () {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "" ,
                        success: function (data) {
                            //oTable.fnDraw(false);
                            if (data.me == "") {
                                $(this).dialog("close");
                                location.reload();
                            }
                        }
                    });

                },
                "Cancelar": function () {
                    $(this).dialog("close");
                    return false;
                }
            }

        }).load(this.href, {});

        return false;
    });
});