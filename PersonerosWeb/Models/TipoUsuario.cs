using PersonerosWeb.Resourses;
using PersonerosWeb.Service;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PersonerosWeb.Models {
    public class TipoUsuario {
        public int idTipoUsuario { get; set; }
        [Display(Name = "Nombre del Tipo de Usuario")]
        public string nombre { get; set; }
        [Display(Name = "Identificador")]
        public int identificador { get; set; }
        [Display(Name = "Nivel de Acceso")]
        public int nivelAcceso { get; set; }

        //Implementacion de Metodos
        public Response<List<TipoUsuario>> obtenerTiposUsuario() {
            var response = new Response<List<TipoUsuario>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoUsuarioServicio service = adapter.Create<ITipoUsuarioServicio>();
                RestResponse<Response<List<TipoUsuario>>> tipoUsuarioResponse = service.obtenerTiposUsuario();
                if(tipoUsuarioResponse.StatusCode == HttpStatusCode.OK) {
                    response = tipoUsuarioResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerTiposUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoUsuario> obtenerTipoUsuario(int id) {
            var response = new Response<TipoUsuario>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoUsuarioServicio service = adapter.Create<ITipoUsuarioServicio>();
                RestResponse<Response<TipoUsuario>> tipoUsuarioResponse = service.obtenerTipoUsuario(id);
                if(tipoUsuarioResponse.StatusCode == HttpStatusCode.OK) {
                    response = tipoUsuarioResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarTipoUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoUsuario> crearTipoUsuario() {
            var response = new Response<TipoUsuario>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoUsuarioServicio service = adapter.Create<ITipoUsuarioServicio>();
                RestResponse<Response<TipoUsuario>> tipoUsuarioResponse = service.crearTipoUsuario(this);
                response = tipoUsuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearTiopoUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoUsuario> modificarTipoUsuario() {
            var response = new Response<TipoUsuario>();
            try {
                var tipoUsuario = new TipoUsuario();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoUsuarioServicio service = adapter.Create<ITipoUsuarioServicio>();
                RestResponse<Response<TipoUsuario>> tipoUsuarioResponse = service.modificarTipoUsuario(this);
                response = tipoUsuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarTipoUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoUsuario> eliminarTipoUsuario(int id) {
            var response = new Response<TipoUsuario>();
            try {
                var tipoUsuario = new TipoUsuario();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoUsuarioServicio service = adapter.Create<ITipoUsuarioServicio>();
                RestResponse<Response<TipoUsuario>> tipoUsuarioResponse = service.eliminarTipoUsuario(id);
                response = tipoUsuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarTipoUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> inicializarTiposUsuario() {
            var seleccione = new SelectListItem() {
                Text = "Seleccione Tipo de Usuario",
                Value = "",
                Selected = true,
                Disabled = true
            };

            List<SelectListItem> tiposUsuario = obtenerTiposUsuario().result.OrderByDescending(x => x.nombre).ToList().ConvertAll(d => {
                return new SelectListItem() {
                    Text = d.nombre,
                    Value = d.idTipoUsuario.ToString(),
                    Selected = false
                };
            });
            tiposUsuario.Insert(0, seleccione);

            return tiposUsuario;
        }
    }
}