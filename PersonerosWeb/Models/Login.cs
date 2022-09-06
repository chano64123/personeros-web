using Newtonsoft.Json;
using PersonerosWeb.Helpers;
using PersonerosWeb.Resourses;
using PersonerosWeb.Service;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace PersonerosWeb.Models {
    public class Login {
        [Display(Name = "Nombre de Usuario")]
        [Required]
        public string nombreUsuario { get; set; }
        [Display(Name = "Clave")]
        [Required]
        public string clave { get; set; }

        //Implementacion de Metodos
        public MessageHelper iniciarSesion() {
            var response = new MessageHelper();
            RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
            IUsuarioServicio service = adapter.Create<IUsuarioServicio>();
            RestResponse<Response<Usuario>> usuarioResponse = service.loginUsuario(this);

            response.ok = usuarioResponse.Data.success;
            response.msg = usuarioResponse.Data.displayMessage;

            if(usuarioResponse.StatusCode == HttpStatusCode.OK) {
                var usuario = usuarioResponse.Data.result;
                SessionHelper.AddUserToSession(usuario);
            }

            return response;
        }
    }
}