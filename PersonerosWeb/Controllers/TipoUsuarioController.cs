using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PersonerosWeb.Controllers {
    public class TipoUsuarioController : Controller {
        TipoUsuario tipoUsuario = new TipoUsuario();
        // GET: TipoUsuario
        public ActionResult Index() {
            var response = tipoUsuario.obtenerTiposUsuario();
            ViewBag.captionTable = response.displayMessage;
            return View(response.result);
        }

        public ActionResult DetalleTipoUsuario(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/TipoUsuario/Index");
            } else {
                var response = tipoUsuario.obtenerTipoUsuario(Convert.ToInt32(id));
                if(response.result != null) {
                    //ViewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/TipoUsuario/Index");
                }
            }
        }

        public ActionResult AgregarModificarTipoUsuario(int id = 0) {
            if(id == 0) {
                return View(new TipoUsuario());
            } else {
                var response = tipoUsuario.obtenerTipoUsuario(id);
                if(response.result != null) {
                    //iewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/TipoUsuario/Index");
                }
            }
        }

        public ActionResult GuardarTipoUsuario(TipoUsuario tipoUsuario) {
            if(ModelState.IsValid) {
                var response = tipoUsuario.idTipoUsuario == 0 ? tipoUsuario.crearTipoUsuario() : tipoUsuario.modificarTipoUsuario();
                construirAlert(response);
                //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", resultado));
                return Redirect("~/TipoUsuario/Index");
            } else {
                return View("~/Views/TipoUsuario/AgregarModificarTipoUsuario.cshtml", tipoUsuario);
            }
        }

        [HttpGet]
        public ActionResult EliminarTipoUsuario(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(tipoUsuario.obtenerTipoUsuario(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/TipoUsuario/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarTipoUsuario(int id) {
            var response = tipoUsuario.eliminarTipoUsuario(id);
            construirAlert(response);
            //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", result));
            return Redirect("~/TipoUsuario/Index");
        }

        private void construirAlert(Response<TipoUsuario> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}