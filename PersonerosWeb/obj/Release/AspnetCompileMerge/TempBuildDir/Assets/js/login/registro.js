function resetModal() {
    window.document.querySelector("#modalLoginContenido").innerHTML = '';
}

$("#btnRegistrarse").click(function (eve) {
    resetModal();
    $("#modalLoginContenido").load("/Registro/Index/");
});

function mostrarRegistroUsuarioExito() {
    Swal.fire("Exito!", "Cuenta creada correctamentre! Ya puede iniciar sesión.", "success")
}
function mostrarRegistroUsuarioSinExito() {
    Swal.fire("Error!", "No se pudo crear la cuenta!", "error")
}

var modalRegistro = document.getElementById('modalRegistro')
modalRegistro.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    var button = event.relatedTarget
    //get data value
    var title = button.getAttribute('data-bs-title')
    // Update the modal's content.
    var modalTitle = modalLogin.querySelector('.modal-title')
    //update modal content value
    modalRegistro.textContent = title
})