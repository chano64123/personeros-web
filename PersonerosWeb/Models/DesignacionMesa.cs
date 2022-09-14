using PersonerosWeb.Resourses;
using PersonerosWeb.Service;
using RestSharp;
using Retrofit.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonerosWeb.Models {
    public class DesignacionMesa {
        public int idDesignacionMesa { get; set; }
        public int idUsuario { get; set; }
        public int idMesa { get; set; }
        public Usuario usuario { get; set; }
        public Mesa mesa { get; set; }

        //Implementacion de Metodos
        public Response<List<DesignacionMesa>> obtenerDesignacionesMesas() {
            var response = new Response<List<DesignacionMesa>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionMesaServicio service = adapter.Create<IDesignacionMesaServicio>();
                RestResponse<Response<List<DesignacionMesa>>> distritoResponse = service.obtenerDesignacionesMesas();
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerDesignacionesMesas, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DesignacionMesa> obtenerDesignacionMesa(int id) {
            var response = new Response<DesignacionMesa>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionMesaServicio service = adapter.Create<IDesignacionMesaServicio>();
                RestResponse<Response<DesignacionMesa>> distritoResponse = service.obtenerDesignacionMesa(id);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarDesignacionMesa, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<List<DesignacionMesa>> crearDesignacionMesa(List<DesignacionMesa> designacionesMesa) {
            var response = new Response<List<DesignacionMesa>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionMesaServicio service = adapter.Create<IDesignacionMesaServicio>();
                RestResponse<Response<List<DesignacionMesa>>> distritoResponse = service.crearDesignacionMesa(designacionesMesa);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearDesignacionMesa, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<List<DesignacionMesa>> modificarDesignacionMesa(List<DesignacionMesa> designacionesMesa) {
            var response = new Response<List<DesignacionMesa>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionMesaServicio service = adapter.Create<IDesignacionMesaServicio>();
                RestResponse<Response<List<DesignacionMesa>>> distritoResponse = service.modificarDesignacionMesa(designacionesMesa);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarDesignacionMesa, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<DesignacionMesa> eliminarDesignacionMesa(int id) {
            var response = new Response<DesignacionMesa>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IDesignacionMesaServicio service = adapter.Create<IDesignacionMesaServicio>();
                RestResponse<Response<DesignacionMesa>> distritoResponse = service.eliminarDesignacionMesa(id);
                response = distritoResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarDesignacionMesa, new List<string> { ex.ToString() });
            }
            return response;
        }
    }
}