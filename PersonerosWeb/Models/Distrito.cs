using PersonerosWeb.Resourses;
using PersonerosWeb.Service;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace PersonerosWeb.Models {
    public class Distrito {
        public int idDistrito { get; set; }
        [Display(Name = "Nombre del Distrito")]
        public string nombre { get; set; }

        //Implementacion de Metodos
        public Response<List<Distrito>> obtenerDistritos() {
            var response = new Response<List<Distrito>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDistritoServicio service = adapter.Create<IDistritoServicio>();
                RestResponse<Response<List<Distrito>>> distritoResponse = service.obtenerDistritos();
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerDistritos, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Distrito> obtenerDistrito(int id) {
            var response = new Response<Distrito>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDistritoServicio service = adapter.Create<IDistritoServicio>();
                RestResponse<Response<Distrito>> distritoResponse = service.obtenerDistrito(id);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarDistrito, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Distrito> crearDistrito() {
            var response = new Response<Distrito>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDistritoServicio service = adapter.Create<IDistritoServicio>();
                RestResponse<Response<Distrito>> distritoResponse = service.crearDistrito(this);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearDistrito, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Distrito> modificarDistrito() {
            var response = new Response<Distrito>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDistritoServicio service = adapter.Create<IDistritoServicio>();
                RestResponse<Response<Distrito>> distritoResponse = service.modificarDistrito(this);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarDistrito, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Distrito> eliminarDistrito(int id) {
            var response = new Response<Distrito>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDistritoServicio service = adapter.Create<IDistritoServicio>();
                RestResponse<Response<Distrito>> distritoResponse = service.eliminarDistrito(id);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarDistrito, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> inicializarDistritos() {
            var seleccione = new SelectListItem() {
                Text = "Seleccione Distrito",
                Value = "",
                Selected = true,
                Disabled = true
            };

            List<SelectListItem> distritos = obtenerDistritos().result.OrderBy(x => x.nombre).ToList().ConvertAll(d => {

                return new SelectListItem() {
                    Text = d.nombre,
                    Value = d.idDistrito.ToString(),
                    Selected = false
                };
            });
            //distritos.Insert(0, seleccione);

            return distritos;
        }
    }
}