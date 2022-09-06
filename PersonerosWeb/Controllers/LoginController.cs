using PersonerosWeb.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonerosWeb.Filters;
using PersonerosWeb.Models;

namespace PersonerosWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [NoLogin]
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login) {
            var response = login.iniciarSesion();
            if(response.ok) {
                ViewBag.alert = "false";
                return Redirect("~/Dashboard");
            } else {
                ViewBag.alert = "true";
                ViewBag.message = response.msg;
                return View("Index");
            }
        }

        public ActionResult CerrarSesion() {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}