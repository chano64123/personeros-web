function resetModal() {
    window.document.querySelector("#modalDesignacionInstitucionContenido").innerHTML = '';
}

function openModalInstitucion(vista, id) {
    if (id > 0) {
        $("#modalDesignacionInstitucionContenido").load("/Asignar/" + vista + "/" + id);
    } else {
        $("#modalDesignacionInstitucionContenido").load("/Asignar/" + vista + "/");
    }
}

$("#btnAgregarDesignacionInstitucion").click(function (eve) {
    resetModal();
    openModalInstitucion("AgregarModificarDesignacionInstitucion");
});

$(".btnDetalleDesignacionInstitucion").click(function (eve) {
    resetModal();
    openModalInstitucion("DetalleDesignacionInstitucion", $(this).data("id"))
});

$(".btnModificarDesignacionInstitucion").click(function (eve) {
    resetModal();
    openModalInstitucion("AgregarModificarDesignacionInstitucion", $(this).data("id"))
});

$(".btnEliminarDesignacionInstitucion").click(function (eve) {
    resetModal();
    openModalInstitucion("EliminarDesignacionInstitucion", $(this).data("id"))
});

var modalDesignacionInstitucion = document.getElementById('modalDesignacionInstitucion')
modalDesignacionInstitucion.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalDesignacionInstitucion.querySelector('.modal-title')
    //update modal content value
    modalTitle.textContent = title
})