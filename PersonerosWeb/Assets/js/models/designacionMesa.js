function resetModal() {
    window.document.querySelector("#modalDesignacionMesaContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalDesignacionMesaContenido").load("/Asignar/" + vista + "/" + id);
    } else {
        $("#modalDesignacionMesaContenido").load("/Asignar/" + vista + "/");
    }
}

$("#btnAgregarDesignacionMesa").click(function (eve) {
    resetModal();
    openModal("AgregarModificarDesignacionMesa");
});

$(".btnDetalleDesignacionMesa").click(function (eve) {
    resetModal();
    openModal("DetalleDesignacionMesa", $(this).data("id"))
});

$(".btnModificarDesignacionMesa").click(function (eve) {
    resetModal();
    openModal("AgregarModificarDesignacionMesa", $(this).data("id"))
});

$(".btnEliminarDesignacionMesa").click(function (eve) {
    console.log($(this).data("id"))
    resetModal();
    openModal("EliminarDesignacionMesa", $(this).data("id"))
});

var modalDesignacionMesa = document.getElementById('modalDesignacionMesa')
modalDesignacionMesa.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalDesignacionMesa.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})