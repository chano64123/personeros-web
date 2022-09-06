function resetModal() {
    window.document.querySelector("#modalPersonaContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalPersonaContenido").load("/Persona/" + vista + "/" + id);
    } else {
        $("#modalPersonaContenido").load("/Persona/" + vista + "/");
    }
}

$("#btnAgregarPersona").click(function (eve) {
    resetModal();
    openModal("AgregarModificarPersona");
});

$(".btnDetallePersona").click(function (eve) {
    resetModal();
    openModal("DetallePersona", $(this).data("id"))
});

$(".btnModificarPersona").click(function (eve) {
    resetModal();
    openModal("AgregarModificarPersona", $(this).data("id"))
});

$(".btnEliminarPersona").click(function (eve) {
    resetModal();
    openModal("EliminarPersona", $(this).data("id"))
});

var modalPersona = document.getElementById('modalPersona')
modalPersona.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalPersona.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})