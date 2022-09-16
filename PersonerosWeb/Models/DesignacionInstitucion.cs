using PersonerosWeb.Resourses;
using PersonerosWeb.Service;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonerosWeb.Models {
    public class DesignacionInstitucion {
        public int idDesignacionInstitucion { get; set; }
        public int idUsuario { get; set; }
        public int idInstitucion { get; set; }
        public Usuario usuario { get; set; }
        public Institucion institucion { get; set; }

        //Implementacion de Metodos
        public string nombreCompletoUsuario() {
            return this.usuario.persona.nombres + " " + this.usuario.persona.apellidoPaterno + " " + this.usuario.persona.apellidoMaterno + "|" + usuario.idUsuario;
        }

        public Response<List<DesignacionInstitucion>> obtenerDesignacionesInstituciones() {
            var response = new Response<List<DesignacionInstitucion>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionInstitucionServicio service = adapter.Create<IDesignacionInstitucionServicio>();
                RestResponse<Response<List<DesignacionInstitucion>>> distritoResponse = service.obtenerDesignacionesInstitucions();
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerDesignacionesInstituciones, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DesignacionInstitucion> obtenerDesignacionInstitucion(int id) {
            var response = new Response<DesignacionInstitucion>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionInstitucionServicio service = adapter.Create<IDesignacionInstitucionServicio>();
                RestResponse<Response<DesignacionInstitucion>> distritoResponse = service.obtenerDesignacionInstitucion(id);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarDesignacionInstitucion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<List<DesignacionInstitucion>> crearDesignacionInstitucion(List<DesignacionInstitucion> designacionesInstitucion) {
            var response = new Response<List<DesignacionInstitucion>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionInstitucionServicio service = adapter.Create<IDesignacionInstitucionServicio>();
                RestResponse<Response<List<DesignacionInstitucion>>> distritoResponse = service.crearDesignacionInstitucion(designacionesInstitucion);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearDesignacionInstitucion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<List<DesignacionInstitucion>> modificarDesignacionInstitucion(List<DesignacionInstitucion> designacionesInstitucion) {
            var response = new Response<List<DesignacionInstitucion>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionInstitucionServicio service = adapter.Create<IDesignacionInstitucionServicio>();
                RestResponse<Response<List<DesignacionInstitucion>>> distritoResponse = service.modificarDesignacionInstitucion(designacionesInstitucion);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarDesignacionInstitucion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DesignacionInstitucion> eliminarDesignacionInstitucion(int id) {
            var response = new Response<DesignacionInstitucion>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionInstitucionServicio service = adapter.Create<IDesignacionInstitucionServicio>();
                RestResponse<Response<DesignacionInstitucion>> distritoResponse = service.eliminarDesignacionInstitucion(id);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarDesignacionInstitucion, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}