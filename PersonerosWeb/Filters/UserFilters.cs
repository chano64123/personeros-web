using PersonerosWeb.Helpers;
using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonerosWeb.Filters {
    // Si no estamos logeado, regresamos al login
    public class AutenticadoAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);

            if(!SessionHelper.ExistUserInSession()) {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {
                    controller = "Login",
                    action = "Index"
                }));
            }
        }
    }

    // Si estamos logeado ya no podemos acceder a la página de Login
    public class NoLoginAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);

            if(SessionHelper.ExistUserInSession()) {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {
                    controller = "Dashboard",
                    action = "Index"
                }));
            }
        }
    }

    [Autenticado]
    public class OnlyAdminAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);
            if(SessionHelper.ExistUserInSession()) {
                var usuario = SessionHelper.GetUser();
                if(!usuario.tipoUsuario.identificador.Equals(Convert.ToInt32(TipoDeUsuario.administrador))) {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {
                        controller = "Dashboard",
                        action = "Index"
                    }));
                }
            } else {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {
                    controller = "Dashboard",
                    action = "Index"
                }));
            }

        }
    }
}