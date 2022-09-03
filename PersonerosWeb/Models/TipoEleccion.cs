using PersonerosWeb.Resourses;
using PersonerosWeb.Service;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Models {
    public class TipoEleccion {
        public int idTipoEleccion { get; set; }
        public string nombre { get; set; }
        public Persona persona { get; set; }

        //Implementacion de Metodos
        public Response<List<TipoEleccion>> obtenerTiposElecciones() {
            var response = new Response<List<TipoEleccion>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoEleccionServicio service = adapter.Create<ITipoEleccionServicio>();
                RestResponse<Response<List<TipoEleccion>>> tipoEleccionResponse = service.obtenerTiposElecciones();
                if(tipoEleccionResponse.StatusCode == HttpStatusCode.OK) {
                    response = tipoEleccionResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerTiposUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoEleccion> obtenerTipoEleccion(int id) {
            var response = new Response<TipoEleccion>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoEleccionServicio service = adapter.Create<ITipoEleccionServicio>();
                RestResponse<Response<TipoEleccion>> tipoEleccionResponse = service.obtenerTipoEleccion(id);
                if(tipoEleccionResponse.StatusCode == HttpStatusCode.OK) {
                    response = tipoEleccionResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarTipoEleccion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoEleccion> crearTipoEleccion() {
            var response = new Response<TipoEleccion>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoEleccionServicio service = adapter.Create<ITipoEleccionServicio>();
                RestResponse<Response<TipoEleccion>> tipoEleccionResponse = service.crearTipoEleccion(this);
                response = tipoEleccionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearTiopoUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoEleccion> modificarTipoEleccion(int id) {
            var response = new Response<TipoEleccion>();
            try {
                var tipoEleccion = new TipoEleccion();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoEleccionServicio service = adapter.Create<ITipoEleccionServicio>();
                RestResponse<Response<TipoEleccion>> tipoEleccionResponse = service.modificarTipoEleccion(this);
                response = tipoEleccionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarTipoEleccion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<TipoEleccion> eliminarTipoEleccion(int id) {
            var response = new Response<TipoEleccion>();
            try {
                var tipoEleccion = new TipoEleccion();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                ITipoEleccionServicio service = adapter.Create<ITipoEleccionServicio>();
                RestResponse<Response<TipoEleccion>> tipoEleccionResponse = service.eliminarTipoEleccion(id);
                response = tipoEleccionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarTipoEleccion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> inicializarTiposElecciones() {
            var seleccione = new SelectListItem() {
                Text = "Seleccione Tipo de Eleccion",
                Value = "",
                Selected = true,
                Disabled = true
            };

            List<SelectListItem> tiposElecciones = obtenerTiposElecciones().result.OrderBy(x => x.nombre).ToList().ConvertAll(d => {
                return new SelectListItem() {
                    Text = d.nombre,
                    Value = d.idTipoEleccion.ToString(),
                    Selected = false
                };
            });
            tiposElecciones.Insert(0, seleccione);

            return tiposElecciones;
        }
    }
}