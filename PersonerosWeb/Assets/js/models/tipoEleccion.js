function resetModal() {
    window.document.querySelector("#modalTipoEleccionContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalTipoEleccionContenido").load("/TipoEleccion/" + vista + "/" + id);
    } else {
        $("#modalTipoEleccionContenido").load("/TipoEleccion/" + vista + "/");
    }
}

$("#btnAgregarTipoEleccion").click(function (eve) {
    resetModal();
    openModal("AgregarModificarTipoEleccion");
});

$(".btnDetalleTipoEleccion").click(function (eve) {
    resetModal();
    openModal("DetalleTipoEleccion", $(this).data("id"))
});

$(".btnModificarTipoEleccion").click(function (eve) {
    resetModal();
    openModal("AgregarModificarTipoEleccion", $(this).data("id"))
});

$(".btnEliminarTipoEleccion").click(function (eve) {
    resetModal();
    openModal("EliminarTipoEleccion", $(this).data("id"))
});

var modalTipoEleccion = document.getElementById('modalTipoEleccion')
modalTipoEleccion.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalTipoEleccion.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})