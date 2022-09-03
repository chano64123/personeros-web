using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers
{
    public class TipoEleccionController : Controller
    {
        // GET: TipoEleccion
        TipoEleccion tipoEleccion = new TipoEleccion();
        public ActionResult Index() {
            var response = tipoEleccion.obtenerTiposElecciones();
            ViewBag.captionTable = response.displayMessage;
            return View(response.result);
        }

        public ActionResult DetalleTipoEleccion(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/TipoEleccion/Index");
            } else {
                var response = tipoEleccion.obtenerTipoEleccion(Convert.ToInt32(id));
                if(response.result != null) {
                    //ViewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/TipoEleccion/Index");
                }
            }
        }

        public ActionResult AgregarModificarTipoEleccion(int id = 0) {
            if(id == 0) {
                return View(new TipoEleccion());
            } else {
                var response = tipoEleccion.obtenerTipoEleccion(id);
                if(response.result != null) {
                    //iewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/TipoEleccion/Index");
                }
            }
        }

        public ActionResult GuardarTipoEleccion(TipoEleccion tipoEleccion) {
            if(ModelState.IsValid) {
                var response = tipoEleccion.idTipoEleccion == 0 ? tipoEleccion.crearTipoEleccion() : tipoEleccion.modificarTipoEleccion(tipoEleccion.idTipoEleccion);
                construirAlert(response);
                //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", resultado));
                return Redirect("~/TipoEleccion/Index");
            } else {
                return View("~/Views/TipoEleccion/AgregarModificarTipoEleccion.cshtml", tipoEleccion);
            }
        }

        [HttpGet]
        public ActionResult EliminarTipoEleccion(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(tipoEleccion.obtenerTipoEleccion(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/TipoEleccion/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarTipoEleccion(int id) {
            var response = tipoEleccion.eliminarTipoEleccion(id);
            construirAlert(response);
            //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", result));
            return Redirect("~/TipoEleccion/Index");
        }

        private void construirAlert(Response<TipoEleccion> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}