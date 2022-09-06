using PersonerosWeb.Filters;
using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers
{
    [Autenticado]
    public class InstitucionController : Controller
    {
        Institucion institucion = new Institucion();
        Distrito distrito = new Distrito();
        // GET: Institucion
        public ActionResult Index() {
            var response = institucion.obtenerInstituciones();
            ViewBag.captionTable = response.displayMessage;
            var result = from p in response.result.OrderBy(x => x.distrito.nombre).ToList()
                         group p by p.distrito.nombre into institucion
                         select institucion;
            //return View(response.result.OrderBy(x => x.distrito.nombre).ToList());
            return View(result);
        }

        public ActionResult DetalleInstitucion(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/Institucion/Index");
            } else {
                var response = institucion.obtenerInstitucion(Convert.ToInt32(id));
                if(response.result != null) {
                    //ViewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Institucion/Index");
                }
            }
        }

        public ActionResult AgregarModificarInstitucion(int id = 0) {
            ViewBag.distritos = distrito.inicializarDistritos();
            if(id == 0) {
                return View(new Institucion());
            } else {
                var response = institucion.obtenerInstitucion(id);
                if(response.result != null) {
                    //iewBag.message = response.displayMessage;
                    return View(response.result);
                } else {
                    return Redirect("~/Institucion/Index");
                }
            }
        }

        public ActionResult GuardarInstitucion(Institucion institucion) {
            if(ModelState.IsValid) {
                //para distrito
                institucion.idDistrito = institucion.distrito.idDistrito;
                institucion.distrito = null;
                
                var response = institucion.idInstitucion == 0 ? institucion.crearInstitucion() : institucion.modificarInstitucion();
                construirAlert(response);
                //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", resultado));
                return Redirect("~/Institucion/Index");
            } else {
                return View("~/Views/Institucion/AgregarModificarInstitucion.cshtml", institucion);
            }
        }

        [HttpGet]
        public ActionResult EliminarInstitucion(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(institucion.obtenerInstitucion(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/Institucion/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarInstitucion(int id) {
            var response = institucion.eliminarInstitucion(id);
            construirAlert(response);
            //ControllerContext.HttpContext.Response.SetCookie(new HttpCookie("alert", result));
            return Redirect("~/Institucion/Index");
        }

        private void construirAlert(Response<Institucion> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}