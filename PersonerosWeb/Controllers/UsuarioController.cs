using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers
{
    public class UsuarioController : Controller
    {
        Usuario usuario = new Usuario();
        TipoUsuario tipoUsuario = new TipoUsuario();
        Persona persona = new Persona();
        // GET: Usuario
        public ActionResult Index() {
            var response = usuario.obtenerUsuarios();
            ViewBag.captionTable = response.displayMessage;
            return View(response.result);
        }

        public ActionResult DetalleUsuario(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/Usuario/Index");
            } else {
                var response = usuario.obtenerUsuario(Convert.ToInt32(id));
                if(response.result != null) {
                    //ViewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Usuario/Index");
                }
            }
        }

        public ActionResult AgregarModificarUsuario(int id = 0) {
            ViewBag.personas = persona.inicializarPersonasPorDistritoDeResidencia();
            ViewBag.tiposUsuario = tipoUsuario.inicializarTiposUsuario();
            if(id == 0) {
                return View(new Usuario());
            } else {
                var response = usuario.obtenerUsuario(id);
                if(response.result != null) {
                    //iewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Usuario/Index");
                }
            }
        }

        public ActionResult GuardarUsuario(Usuario usuario) {
            if(ModelState.IsValid) {
                //para TIPO USUARIO
                usuario.idTipoUsuario = usuario.tipoUsuario.idTipoUsuario;
                usuario.tipoUsuario = null;
                //para PERSONA
                usuario.idPersona = usuario.persona.idPersona;
                usuario.persona = null;
                //para la clave
                usuario.clave = String.IsNullOrEmpty(usuario.clave) ? "" : usuario.clave;

                var response = usuario.idUsuario == 0 ? usuario.crearUsuario() : usuario.modificarUsuario();
                construirAlert(response);
                //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", resultado));
                return Redirect("~/Usuario/Index");
            } else {
                return View("~/Views/Usuario/AgregarModificarUsuario.cshtml", usuario);
            }
        }

        [HttpGet]
        public ActionResult EliminarUsuario(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(usuario.obtenerUsuario(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/Usuario/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarUsuario(int id) {
            var response = usuario.eliminarUsuario(id);
            construirAlert(response);
            //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", result));
            return Redirect("~/Usuario/Index");
        }

        private void construirAlert(Response<Usuario> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}