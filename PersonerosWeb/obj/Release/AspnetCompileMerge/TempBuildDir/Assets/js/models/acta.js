function resetModal() {
    window.document.querySelector("#modalActaContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalActaContenido").load("/Acta/" + vista + "/" + id);
    } else {
        $("#modalActaContenido").load("/Acta/" + vista + "/");
    }
}

$("#btnAgregarActa").click(function (eve) {
    resetModal();
    openModal("AgregarModificarActa");
});

$(".btnDetalleActa").click(function (eve) {
    resetModal();
    openModal("DetalleActa", $(this).data("id"))
});

$(".btnModificarActa").click(function (eve) {
    resetModal();
    openModal("AgregarModificarActa", $(this).data("id"))
});

$(".btnEliminarActa").click(function (eve) {
    resetModal();
    openModal("EliminarActa", $(this).data("id"))
});

var modalActa = document.getElementById('modalActa')
modalActa.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalActa.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})