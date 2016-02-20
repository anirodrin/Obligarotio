function ValidarDiasTraslado(sender, args) {
    var ret = true;
    var dias = args.Value;
    if (isNaN(dias)) {
        ret = false;
    }
    else if (dias <= 0) {
        ret = false;
    }
    args.IsValid = ret;
}

function ValidarPuntos(sender, args) {
    var ret = true;
    var puntos = args.Value;
    if (isNaN(puntos)) {
        ret = false;
    }
    else if (puntos <= 0) {
        ret = false;
    }
    args.IsValid = ret;
}

function ValidarCostoDiario(sender, args) {
    var ret = true;
    var costo = args.Value;
    if (isNaN(costo)) {
        ret = false;
    }
    else if (costo <= 0) {
        ret = false;
    }
    args.IsValid = ret;
}

//function validoSeleccionDestino() {
//    var mensaje = "";
//    var hayCheck = false;
//    if (grvDestinos.length > 0) {
//        for (i = 0; i < grvDestinos.length; i++) {
//            var obj = document.getElementById(grvDestinos[i]);
//            if (obj.checked == true) {
//                hayCheck = true;
//            }
//        }
//    }
//    if (!hayCheck) {
//        mensaje = ("Seleccione al menos un destino");
//    }
//    $("#lblMensajes").html(mensaje);
//    $("#lblMensajes").show();
//    return ret;
//}

function ValidoSeleccionDestino() {
    var seleccionado = false;

    $("#<%=grvDestinos%> :checkbox").each(function () {

        if (this.checked)
            seleccionado = true;

    });
    if (!seleccionado) {
        mensaje = ("Seleccione al menos un destino");
    }
    $("#lblMensajes").html(mensaje);
    $("#lblMensajes").show();
    return ret;
}