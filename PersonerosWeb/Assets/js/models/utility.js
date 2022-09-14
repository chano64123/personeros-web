function valideKeyNumber(evt) {
    var code = (evt.which) ? evt.which : evt.keyCode;
    if (code >= 48 && code <= 57 || code == 13) {
        return true;
    }
    return false;
}

function capitalizeWords(val) {
        return val.toLowerCase()
        .trim()
        .split(' ')
        .map(v => v[0].toUpperCase() + v.substr(1))
        .join(' ');
}

function crearComboBusqueda(elemento, placeholder, padre, data, isMultiple, maxQuantity) {
    var objeto = new Object();

    if (isMultiple != true) {
        console.log(isMultiple)
        elemento.prepend($('<option />', {}));
    }


    objeto.placeholder = placeholder;
    objeto.allowClear = true;
    objeto.language = {
        noResults: function () {
            return "No se encontraron resultados";
        },
        searching: function () {
            return "Buscando...";
        },
        maximumSelected: function (args) {
            return 'Solo puedes seleccionar ' + args.maximum + ' elementos';
        },
    };
    objeto.theme = "bootstrap-5";
    objeto.selectionCssClass = "select2--large";

    if (padre != null && padre != "") {
        objeto.dropdownParent = padre;
    }
    if (data != null && data != "") {
        objeto.data = data;
    }
    if (isMultiple) {
        objeto.multiple = true;
    } else {
        objeto.multiple = false;
    }
    if (maxQuantity != 0 && maxQuantity != null) {
        objeto.maximumSelectionLength = maxQuantity;
    }

    elemento.select2(objeto);
}

function mostrarAlertBusqueda(text) {
    Swal.fire({
        title: text,
        didOpen: () => {
            Swal.showLoading();
        }
    });
}

function limpiarSeleccion(elemento) {
    elemento.val(null).trigger("change");
}

function limpiarCombo(elemento) {
    elemento.empty();
}

function isNumber(val) {
    return !isNaN(val)
}

function ocultarElemento(elemento) {
    elemento.style.display = "none";
}

function mostrarElemento(elemento) {
    elemento.style.display = "block";
}

function count(maxValue, idElement) {
    var counter = { var: 0 };
    var anim = TweenMax.to(counter, 5, {
        var: maxValue,
        onUpdate: function () {
            var number = Math.ceil(counter.var);
            $(idElement).html(number);
            if (number === counter.var) { anim.kill(); }
        },
        onComplete: function () {
            count();
        },
        ease: Circ.easeOut
    });
}