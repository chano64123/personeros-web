using PersonerosWeb.Models;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
                    var js = new JavaScriptSerializer();
                    user = js.Deserialize<Usuario>(ticket.UserData.ToString());
                }
            }
            return user;
        }
        public static void AddUserToSession(Usuario usuario) {
            bool persist = true;
            var cookie = FormsAuthentication.GetAuthCookie("usuario", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddMonths(30000);

            var js = new JavaScriptSerializer();
            var usarioString = js.Serialize(usuario);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, usarioString);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}