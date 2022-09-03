using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers
{
    public class DistritoController : Controller
    {
        Distrito distrito = new Distrito();
        // GET: Distrito
        public ActionResult Index() {
            var response = distrito.obtenerDistritos();
            ViewBag.captionTable = response.displayMessage;
            return View(response.result);
        }

        public ActionResult DetalleDistrito(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/Distrito/Index");
            } else {
                var response = distrito.obtenerDistrito(Convert.ToInt32(id));
                if(response.result != null) {
                    //ViewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Distrito/Index");
                }
            }
        }

        public ActionResult AgregarModificarDistrito(int id = 0) {
            if(id == 0) {
                return View(new Distrito());
            } else {
                var response = distrito.obtenerDistrito(id);
                if(response.result != null) {
                    //iewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Distrito/Index");
                }
            }
        }

        public ActionResult GuardarDistrito(Distrito distrito) {
            if(ModelState.IsValid) {
                var response = distrito.idDistrito == 0 ? distrito.crearDistrito() : distrito.modificarDistrito(distrito.idDistrito);
                construirAlert(response);
                //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", resultado));
                return Redirect("~/Distrito/Index");
            } else {
                return View("~/Views/Distrito/AgregarModificarDistrito.cshtml", distrito);
            }
        }

        [HttpGet]
        public ActionResult EliminarDistrito(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(distrito.obtenerDistrito(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/Distrito/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarDistrito(int id) {
            var response = distrito.eliminarDistrito(id);
            construirAlert(response);
            //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", result));
            return Redirect("~/Distrito/Index");
        }

        private void construirAlert(Response<Distrito> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}