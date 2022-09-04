function resetModal() {
    window.document.querySelector("#modalUsuarioContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalUsuarioContenido").load("/Usuario/" + vista + "/" + id);
    } else {
        $("#modalUsuarioContenido").load("/Usuario/" + vista + "/");
    }
}

$("#btnAgregarUsuario").click(function (eve) {
    resetModal();
    openModal("AgregarModificarUsuario");
});

$(".btnDetalleUsuario").click(function (eve) {
    resetModal();
    openModal("DetalleUsuario", $(this).data("id"))
});

$(".btnModificarUsuario").click(function (eve) {
    resetModal();
    openModal("AgregarModificarUsuario", $(this).data("id"))
});

$(".btnEliminarUsuario").click(function (eve) {
    resetModal();
    openModal("EliminarUsuario", $(this).data("id"))
});

var modalUsuario = document.getElementById('modalUsuario')
modalUsuario.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalUsuario.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})