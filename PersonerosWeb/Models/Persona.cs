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
using System.Web.Mvc;
using System.Xml.Linq;

namespace PersonerosWeb.Models {
    public class Persona {
        public int idPersona { get; set; }
        [Display(Name = "Distrito de Residencia")]
        public int idDistritoDireccion { get; set; }
        [Display(Name = "Institución de Votación")]
        public int idInstitucionVotacion { get; set; }
        [Display(Name = "Documento de Identidad")]
        public string dni { get; set; }
        [Display(Name = "Nombres")]
        public string nombres { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }
        [Display(Name = "Teléfono/Celular")]
        public string celular { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        public Distrito distritoResidencia { get; set; }
        public Institucion institucionVotacion { get; set; }

        //Implementacion de Metodos
        public Response<List<Persona>> obtenerPersonas() {
            var response = new Response<List<Persona>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IPersonaServicio service = adapter.Create<IPersonaServicio>();
                RestResponse<Response<List<Persona>>> institucionResponse = service.obtenerPersonas();
                if(institucionResponse.StatusCode == HttpStatusCode.OK) {
                    response = institucionResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerPersonas, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Persona> obtenerPersona(int id) {
            var response = new Response<Persona>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IPersonaServicio service = adapter.Create<IPersonaServicio>();
                RestResponse<Response<Persona>> institucionResponse = service.obtenerPersona(id);
                if(institucionResponse.StatusCode == HttpStatusCode.OK) {
                    response = institucionResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarPersona, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Persona> crearPersona() {
            var response = new Response<Persona>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IPersonaServicio service = adapter.Create<IPersonaServicio>();
                RestResponse<Response<Persona>> institucionResponse = service.crearPersona(this);
                response = institucionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearTiopoUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Persona> modificarPersona(int id) {
            var response = new Response<Persona>();
            try {
                var institucion = new Persona();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IPersonaServicio service = adapter.Create<IPersonaServicio>();
                RestResponse<Response<Persona>> institucionResponse = service.modificarPersona(this);
                response = institucionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarPersona, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Persona> eliminarPersona(int id) {
            var response = new Response<Persona>();
            try {
                var institucion = new Persona();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IPersonaServicio service = adapter.Create<IPersonaServicio>();
                RestResponse<Response<Persona>> institucionResponse = service.eliminarPersona(id);
                response = institucionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarPersona, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> inicializarPersonaes() {
            var seleccione = new SelectListItem() {
                Text = "Seleccione Insitutción",
                Value = "",
                Selected = true,
                Disabled = true
            };

            List<SelectListItem> personas = obtenerPersonas().result.OrderBy(x => x.apellidoPaterno).OrderBy(x => x.apellidoMaterno).OrderBy(x => x.nombres).ToList().ConvertAll(d => {
                return new SelectListItem() {
                    Text = d.apellidoPaterno + " " + d.apellidoMaterno + ", " + d.nombres + " (" + d.dni + ")",
                    Value = d.idPersona.ToString(),
                    Selected = false
                };
            });
            personas.Insert(0, seleccione);

            return personas;
        }
    }
}