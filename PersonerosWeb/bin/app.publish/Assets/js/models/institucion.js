function resetModal() {
    window.document.querySelector("#modalInstitucionContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalInstitucionContenido").load("/Institucion/" + vista + "/" + id);
    } else {
        $("#modalInstitucionContenido").load("/Institucion/" + vista + "/");
    }
}

$("#btnAgregarInstitucion").click(function (eve) {
    resetModal();
    openModal("AgregarModificarInstitucion");
});

$(".btnDetalleInstitucion").click(function (eve) {
    resetModal();
    openModal("DetalleInstitucion", $(this).data("id"))
});

$(".btnModificarInstitucion").click(function (eve) {
    resetModal();
    openModal("AgregarModificarInstitucion", $(this).data("id"))
});

$(".btnEliminarInstitucion").click(function (eve) {
    resetModal();
    openModal("EliminarInstitucion", $(this).data("id"))
});

var modalInstitucion = document.getElementById('modalInstitucion')
modalInstitucion.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalInstitucion.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})