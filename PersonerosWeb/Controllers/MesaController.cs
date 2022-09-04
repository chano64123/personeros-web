using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers
{
    public class MesaController : Controller
    {
        Mesa mesa = new Mesa();
        Institucion institucion = new Institucion();
        // GET: Mesa
        public ActionResult Index() {
            var response = mesa.obtenerMesas();
            ViewBag.captionTable = response.displayMessage;
            return View(response.result.ToList());
        }

        public ActionResult DetalleMesa(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/Mesa/Index");
            } else {
                var response = mesa.obtenerMesa(Convert.ToInt32(id));
                if(response.result != null) {
                    //ViewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Mesa/Index");
                }
            }
        }

        public ActionResult AgregarModificarMesa(int id = 0) {
            ViewBag.instituciones = institucion.inicializarInstituciones();
            if(id == 0) {
                return View(new Mesa());
            } else {
                var response = mesa.obtenerMesa(id);
                if(response.result != null) {
                    //iewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Mesa/Index");
                }
            }
        }

        public ActionResult GuardarMesa(Mesa mesa) {
            if(ModelState.IsValid) {
                //para institucion
                mesa.idInstitucion = mesa.institucion.idInstitucion;
                mesa.institucion = null;

                //totdo normal
                var response = mesa.idMesa == 0 ? mesa.crearMesa() : mesa.modificarMesa();
                construirAlert(response);
                //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", resultado));
                return Redirect("~/Mesa/Index");
            } else {
                return View("~/Views/Mesa/AgregarModificarMesa.cshtml", mesa);
            }
        }

        [HttpGet]
        public ActionResult EliminarMesa(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(mesa.obtenerMesa(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/Mesa/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarMesa(int id) {
            var response = mesa.eliminarMesa(id);
            construirAlert(response);
            //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", result));
            return Redirect("~/Mesa/Index");
        }

        private void construirAlert(Response<Mesa> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}