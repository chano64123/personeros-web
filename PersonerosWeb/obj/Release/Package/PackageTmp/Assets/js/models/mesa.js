function resetModal() {
    window.document.querySelector("#modalMesaContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalMesaContenido").load("/Mesa/" + vista + "/" + id);
    } else {
        $("#modalMesaContenido").load("/Mesa/" + vista + "/");
    }
}

$("#btnAgregarMesa").click(function (eve) {
    resetModal();
    openModal("AgregarModificarMesa");
});

$(".btnDetalleMesa").click(function (eve) {
    resetModal();
    openModal("DetalleMesa", $(this).data("id"))
});

$(".btnModificarMesa").click(function (eve) {
    resetModal();
    openModal("AgregarModificarMesa", $(this).data("id"))
});

$(".btnEliminarMesa").click(function (eve) {
    resetModal();
    openModal("EliminarMesa", $(this).data("id"))
});

var modalMesa = document.getElementById('modalMesa')
modalMesa.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalMesa.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})