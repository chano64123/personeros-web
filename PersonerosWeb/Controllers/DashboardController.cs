using PersonerosWeb.Filters;
using PersonerosWeb.Helpers;
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
    public class DashboardController : Controller
    {
        // GET: Dashboard
        Dashboard dashboard = new Dashboard();
        public ActionResult Index() {
            //var totales = dashboard.obtenerTotales(SessionHelper.GetUser());
            Dashboard totales = new Dashboard(); 
            List<Dashboard> modulos = new List<Dashboard>() {
                new Dashboard(totales.cantidadDistritos, Opcion.distrito, ColorFondo.verde, Controlador.distrito, Ruta.accionIndex, new List<int>(){ Convert.ToInt32(TipoDeUsuario.administrador) } ),
                new Dashboard(totales.cantidadInstituciones, Opcion.institucion, ColorFondo.verde, Controlador.institucion, Ruta.accionIndex, new List<int>(){ Convert.ToInt32(TipoDeUsuario.administrador), Convert.ToInt32(TipoDeUsuario._base) } ),
                new Dashboard(totales.cantidadMesas, Opcion.mesa, ColorFondo.verde, Controlador.mesa, Ruta.accionIndex,  new List<int>(){ Convert.ToInt32(TipoDeUsuario.administrador), Convert.ToInt32(TipoDeUsuario._base) } ),

                new Dashboard(totales.cantidadPersona, Opcion.persona, ColorFondo.cyan, Controlador.persona, Ruta.accionIndex, new List<int>(){ Convert.ToInt32(TipoDeUsuario.administrador), Convert.ToInt32(TipoDeUsuario._base) } ),
                new Dashboard(totales.cantidadTiposEleccion, Opcion.tipoEleccion, ColorFondo.cyan, Controlador.tipoEleccion, Ruta.accionIndex, new List<int>(){ Convert.ToInt32(TipoDeUsuario.administrador), Convert.ToInt32(TipoDeUsuario._base) } ),
                new Dashboard(totales.cantidadTiposUsuario, Opcion.tipoUsuario,  ColorFondo.cyan, Controlador.tipoUsuario, Ruta.accionIndex, new List<int>(){ Convert.ToInt32(TipoDeUsuario.administrador) } ),

                new Dashboard(totales.cantidadUsuarios, Opcion.usuario, ColorFondo.plomo, Controlador.usuario, Ruta.accionIndex, new List<int>(){ Convert.ToInt32(TipoDeUsuario.administrador), Convert.ToInt32(TipoDeUsuario._base) } ),
            };
            ViewBag.modulos = modulos;
            return View();
        }
    }
}