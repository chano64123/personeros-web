function resetModal() {
    window.document.querySelector("#modalDistritoContenido").innerHTML = '';
}

function openModal(vista, id) {
    if (id > 0) {
        $("#modalDistritoContenido").load("/Distrito/" + vista + "/" + id);
    } else {
        $("#modalDistritoContenido").load("/Distrito/" + vista + "/");
    }
}

$("#btnAgregarDistrito").click(function (eve) {
    resetModal();
    openModal("AgregarModificarDistrito");
});

$(".btnDetalleDistrito").click(function (eve) {
    resetModal();
    openModal("DetalleDistrito", $(this).data("id"))
});

$(".btnModificarDistrito").click(function (eve) {
    resetModal();
    openModal("AgregarModificarDistrito", $(this).data("id"))
});

$(".btnEliminarDistrito").click(function (eve) {
    resetModal();
    openModal("EliminarDistrito", $(this).data("id"))
});

var modalDistrito = document.getElementById('modalDistrito')
modalDistrito.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalDistrito.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})