using PersonerosWeb.Filters;
using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers {
    [Autenticado]
    public class PersonaController : Controller {
        Persona persona = new Persona();
        Institucion institucion = new Institucion();
        Distrito distrito = new Distrito();
        // GET: Persona
        public ActionResult Index() {
            var response = persona.obtenerPersonas();
            var result = from p in response.result.OrderBy(x => x. institucionVotacion.distrito.nombre).ThenBy(x => x.institucionVotacion.nombre).ThenByDescending(x => x.idPersona).ToList()
                         group p by p.institucionVotacion.nombre into persona
                         select persona;
            ViewBag.captionTable = response.displayMessage;
            return View(result);
            //return View(response.result);
        }

        public ActionResult DetallePersona(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/Persona/Index");
            } else {
                var response = persona.obtenerPersona(Convert.ToInt32(id));
                if(response.result != null) {
                    //ViewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Persona/Index");
                }
            }
        }

        public ActionResult AgregarModificarPersona(int id = 0) {
            ViewBag.distritos = distrito.inicializarDistritos();
            ViewBag.instituciones = institucion.inicializarInstituciones();
            if(id == 0) {
                return View(new Persona());
            } else {
                var response = persona.obtenerPersona(id);
                if(response.result != null) {
                    //iewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Persona/Index");
                }
            }
        }

        public ActionResult GuardarPersona(Persona persona) {
            if(ModelState.IsValid) {
                //para distrito
                persona.idDistritoDireccion = persona.distritoResidencia.idDistrito;
                persona.distritoResidencia = null;
                //para distrito
                persona.idInstitucionVotacion = persona.institucionVotacion.idInstitucion;
                persona.institucionVotacion = null;

                var response = persona.idPersona == 0 ? persona.crearPersona() : persona.modificarPersona();
                construirAlert(response);
                //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", resultado));
                return Redirect("~/Persona/Index");
            } else {
                return View("~/Views/Persona/AgregarModificarPersona.cshtml", persona);
            }
        }

        [HttpGet]
        public ActionResult EliminarPersona(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(persona.obtenerPersona(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/Persona/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarPersona(int id) {
            var response = persona.eliminarPersona(id);
            construirAlert(response);
            //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", result));
            return Redirect("~/Persona/Index");
        }

        private void construirAlert(Response<Persona> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}