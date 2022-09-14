using PersonerosWeb.Filters;
using PersonerosWeb.Models;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Controllers
{
    [Autenticado]
    //[OnlyAdmin]
    public class AsignarController : Controller
    {
        TipoUsuario tipoUsuario = new TipoUsuario();
        Institucion insitutcion = new Institucion();
        DesignacionMesa designacionMesa = new DesignacionMesa();
        // GET: Asignar
        public ActionResult Index()
        {
            //ViewBag.personas = persona.inicializarPersonasPorDistritoDeResidencia();
            ViewBag.tiposUsuario = tipoUsuario.inicializarTiposUsuarioElegible();
            ViewBag.instituciones = insitutcion.inicializarInstituciones();

            //personeros agrupados por institucion
            ViewBag.designacionPersoneros = designacionMesa.obtenerDesignacionesMesas().result.OrderBy(x => x.mesa.institucion.distrito.nombre).ThenBy(x => x.mesa.institucion.nombre).ThenBy(x => x.mesa.numero).ToList().GroupBy(x => x.mesa.institucion.nombre);
            return View();
        }

        public ActionResult Agregar(DesignacionMesa designacionMesa, string idUsuario, string[] idMesa, string[] idInstitucion) {
            if(ModelState.IsValid) {

                if(idMesa != null) { //aca en teoria se va a agregar un personero

                    var personeros = new List<DesignacionMesa>();

                    foreach(string mesa in idMesa) {
                        personeros.Add(new DesignacionMesa { 
                            idMesa = Convert.ToInt32(mesa),
                            idUsuario = Convert.ToInt32(idUsuario)
                        });
                    }

                    var response = designacionMesa.idDesignacionMesa == 0 ? designacionMesa.crearDesignacionMesa(personeros) : designacionMesa.modificarDesignacionMesa(personeros);
                    construirAlert(response);

                } else { //aca en teoria se va a agregar un coordinador o enlace

                }

                return Redirect("~/Asignar/Index");
            } else {
                return View("~/Views/Asignar/Index.cshtml");
            }


            if(!String.IsNullOrEmpty(idUsuario)) {

            }
            if(!String.IsNullOrEmpty(idMesa[0])) {

            }
            if(!String.IsNullOrEmpty(idInstitucion[0])) {

            }
            return Redirect("~/Asignar/Index");
        }

        public ActionResult AgregarCoordinadorEnlace () {
            return View();
        }

        public ActionResult GuardarUsuarioInstitucion() {
            return View();
        }

        public ActionResult GuardarUsuarioMesa() {
            return View();
        }

        [HttpGet]
        public ActionResult EliminarDesignacionMesa(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(designacionMesa.obtenerDesignacionMesa(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/Asignar/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarDesignacionMesa(int id) {
            var response = designacionMesa.eliminarDesignacionMesa(id);
            construirAlert(response);
            return Redirect("~/Asignar/Index");
        }

        private void construirAlert(Response<List<DesignacionMesa>> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }

        private void construirAlert(Response<DesignacionMesa> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}