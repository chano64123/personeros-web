using PersonerosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PersonerosWeb.Helpers {
    public class SessionHelper {
        public static bool ExistUserInSession() {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        public static void DestroyUserSession() {
            FormsAuthentication.SignOut();
        }
        public static Usuario GetUser() {
            Usuario user = new Usuario();
            if(HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity) {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if(ticket != null) {
                    string[] userData = ticket.UserData.ToString().Split('>');
                    user.idUsuario = Convert.ToInt32(userData[0]);
                    user.idTipoUsuario = Convert.ToInt32(userData[1]);
                    user.idPersona = Convert.ToInt32(userData[2]);
                    user.nombreUsuario = userData[3];
                    user.clave = userData[4];
                    user.cantidadMaximaMesas = Convert.ToInt32(userData[5]);
                    user.cantidadMaximaInstituciones = Convert.ToInt32(userData[6]);
                    //user.tipoUsuario = userData[7];
                    //user.persona = userData[8];
                }
            }
            return user;
        }
        public static void AddUserToSession(string usuario) {
            bool persist = true;
            var cookie = FormsAuthentication.GetAuthCookie("usuario", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddMonths(3);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate,
                                                          ticket.Expiration, ticket.IsPersistent, usuario);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}