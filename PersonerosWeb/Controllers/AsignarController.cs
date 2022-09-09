using PersonerosWeb.Filters;
using PersonerosWeb.Models;
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
        // GET: Asignar
        public ActionResult Index()
        {
            //ViewBag.personas = persona.inicializarPersonasPorDistritoDeResidencia();
            ViewBag.tiposUsuario = tipoUsuario.inicializarTiposUsuarioElegible();
            ViewBag.instituciones = insitutcion.inicializarInstituciones();
            return View();
        }

        public ActionResult AgregarPersonero() {
            return View();
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
    }
}