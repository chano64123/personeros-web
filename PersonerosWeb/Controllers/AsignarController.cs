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
        DesignacionInstitucion designacionInstitucion = new DesignacionInstitucion();
        // GET: Asignar
        public ActionResult Index()
        {
            //ViewBag.personas = persona.inicializarPersonasPorDistritoDeResidencia();
            ViewBag.tiposUsuario = tipoUsuario.inicializarTiposUsuarioElegible();
            ViewBag.instituciones = insitutcion.inicializarInstituciones();

            //personeros agrupados por institucion
            ViewBag.designacionPersoneros = designacionMesa.obtenerDesignacionesMesas().result.OrderBy(x => x.mesa.institucion.distrito.nombre).ThenBy(x => x.mesa.institucion.nombre).ThenBy(x => x.mesa.numero).ToList().GroupBy(x => x.mesa.institucion.nombre);

            var designacionesInstituciones = designacionInstitucion.obtenerDesignacionesInstituciones().result.OrderBy(x => x.institucion.distrito.nombre).ThenBy(x => x.institucion.nombre).ThenBy(x => x.usuario.persona.nombres).ToList();

            //coordinadores normalito
            ViewBag.designacionCoordinadores = designacionesInstituciones.Where(x => x.usuario.tipoUsuario.identificador == Convert.ToInt32(TipoDeUsuario.coordinador)).GroupBy(x => x.institucion.distrito.nombre);

            //enlaces agrupado por persona
            ViewBag.designacionEnlaces = designacionesInstituciones.Where(x => x.usuario.tipoUsuario.identificador == Convert.ToInt32(TipoDeUsuario.enlace)).GroupBy(x => x.nombreCompletoUsuario() /*new { x.idUsuario, x.nombreCompletoUsuario() }*/);

            return View();
        }

        public ActionResult Agregar(DesignacionMesa designacionMesa, string idUsuario, string[] idMesa, string[] idInstitucion) {
            if(!ModelState.IsValid) {
                return View("~/Views/Asignar/Index.cshtml");

            }
            
            if(idMesa != null) { //aca en teoria se va a agregar un personero

                var personeros = new List<DesignacionMesa>();

                foreach(string mesa in idMesa) {
                    personeros.Add(new DesignacionMesa { 
                        idMesa = Convert.ToInt32(mesa),
                        idUsuario = Convert.ToInt32(idUsuario)
                    });
                }

                var response = designacionMesa.idDesignacionMesa == 0 ? designacionMesa.crearDesignacionMesa(personeros) : designacionMesa.modificarDesignacionMesa(personeros);
                construirAlert<DesignacionMesa>(response);

            } else { //aca en teoria se va a agregar un coordinador o enlace
            
                var coordinadorEnlace = new List<DesignacionInstitucion>();

                foreach(string institucion in idInstitucion) {
                    coordinadorEnlace.Add(new DesignacionInstitucion {
                        idInstitucion = Convert.ToInt32(institucion),
                        idUsuario = Convert.ToInt32(idUsuario)
                    });
                }

                var response = designacionMesa.idDesignacionMesa == 0 ? designacionInstitucion.crearDesignacionInstitucion(coordinadorEnlace) : designacionInstitucion.modificarDesignacionInstitucion(coordinadorEnlace);
                construirAlert<DesignacionInstitucion>(response);
            }

            return Redirect("~/Asignar/Index");
        }

        public ActionResult DetalleDesignacionMesa(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/Asignar/Index");
            } else {
                var response = designacionMesa.obtenerDesignacionMesa(Convert.ToInt32(id));
                if(response.result != null) {
                    return View(response.result);
                } else {
                    return Redirect("~/Asignar/Index");
                }
            }
        }

        public ActionResult DetalleDesignacionInstitucion(string id) {
            if(String.IsNullOrEmpty(id)) {
                return Redirect("~/Asignar/Index");
            } else {
                var response = designacionInstitucion.obtenerDesignacionInstitucion(Convert.ToInt32(id));
                if(response.result != null) {
                    return View(response.result);
                } else {
                    return Redirect("~/Asignar/Index");
                }
            }
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
            construirAlert<DesignacionMesa>(response);
            return Redirect("~/Asignar/Index");
        }

        [HttpGet]
        public ActionResult EliminarDesignacionInstitucion(string id) {
            if(!String.IsNullOrEmpty(id)) {
                return View(designacionInstitucion.obtenerDesignacionInstitucion(Convert.ToInt32(id)).result);
            } else {
                return Redirect("~/Asignar/Index");
            }
        }

        [HttpPost]
        public ActionResult EliminarDesignacionInstitucion(int id) {
            var response = designacionInstitucion.eliminarDesignacionInstitucion(id);
            construirAlert<DesignacionInstitucion>(response);
            return Redirect("~/Asignar/Index");
        }

        private void construirAlert<T>(Response<List<T>> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }

        private void construirAlert<T>(Response<T> response) {
            Session["messageAlert"] = response.displayMessage;
            Session["titleAlert"] = response.success ? TitutloAlert.Success : TitutloAlert.Error;
            Session["iconAlert"] = response.success ? IconAlert.Success : IconAlert.Error;
        }
    }
}