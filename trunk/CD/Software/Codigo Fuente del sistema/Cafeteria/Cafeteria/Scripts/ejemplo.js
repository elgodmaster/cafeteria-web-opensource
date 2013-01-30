$(document).ready(function () {
    var idUsuario = localStorage.getItem("idUsuario");
    var nombre = localStorage.getItem("nombre");

    $('#venta').click(function () {
        alert(idUsuario);
        //var idUsuario = localStorage.getItem("idUsuario");
        var p= $("#nombreUsuario").val();
        var jsonventa = {
            user: idUsuario,
            pass: p
        };
        //alert(p);
        
        $.ajax({
            type: "POST",
            data: JSON.stringify(jsonventa),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "/Venta/LoginResult",
            success: function (data) {
               // var abc = data.usuario;
                //var url = "/Compras/Index";
                //window.location.href = url;
                //localStorage.setItem("GG", abc);
                //localStorage.setItem("GG2", data);
                //localStorage.setItem("GG3", "mmm");
            }

        });
        
    });


});