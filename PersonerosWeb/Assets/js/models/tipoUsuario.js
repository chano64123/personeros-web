function resetModal() {
    window.document.querySelector("#modalTipoUsuarioContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalTipoUsuarioContenido").load("/TipoUsuario/" + vista + "/" + id);
    } else {
        $("#modalTipoUsuarioContenido").load("/TipoUsuario/" + vista + "/");
    }
}

$("#btnAgregarTipoUsuario").click(function (eve) {
    resetModal();
    openModal("AgregarModificarTipoUsuario");
});

$(".btnDetalleTipoUsuario").click(function (eve) {
    resetModal();
    openModal("DetalleTipoUsuario", $(this).data("id"))
});

$(".btnModificarTipoUsuario").click(function (eve) {
    resetModal();
    openModal("AgregarModificarTipoUsuario", $(this).data("id"))
});

$(".btnEliminarTipoUsuario").click(function (eve) {
    resetModal();
    openModal("EliminarTipoUsuario", $(this).data("id"))
});

var modalTipoUsuario = document.getElementById('modalTipoUsuario')
modalTipoUsuario.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalTipoUsuario.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})