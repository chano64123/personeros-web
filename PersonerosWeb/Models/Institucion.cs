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

namespace PersonerosWeb.Models {
    public class Institucion {
        public int idInstitucion { get; set; }
        [Display(Name = "Distrito")]
        public int idDistrito { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        [Display(Name = "Cantidad de mesas")]
        public int cantidadMesas { get; set; }
        [Display(Name = "Cantidad de electores")]
        public int cantidadElectores { get; set; }
        public Distrito distrito { get; set; }

        //Implementacion de Metodos
        public Response<List<Institucion>> obtenerInstituciones() {
            var response = new Response<List<Institucion>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IInstitucionServicio service = adapter.Create<IInstitucionServicio>();
                RestResponse<Response<List<Institucion>>> institucionResponse = service.obtenerInstituciones();
                if(institucionResponse.StatusCode == HttpStatusCode.OK) {
                    response = institucionResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerInstituciones, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Institucion> obtenerInstitucion(int id) {
            var response = new Response<Institucion>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IInstitucionServicio service = adapter.Create<IInstitucionServicio>();
                RestResponse<Response<Institucion>> institucionResponse = service.obtenerInstitucion(id);
                if(institucionResponse.StatusCode == HttpStatusCode.OK) {
                    response = institucionResponse.Data;
                }
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarInstitucion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Institucion> crearInstitucion() {
            var response = new Response<Institucion>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IInstitucionServicio service = adapter.Create<IInstitucionServicio>();
                RestResponse<Response<Institucion>> institucionResponse = service.crearInstitucion(this);
                response = institucionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearTiopoUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Institucion> modificarInstitucion() {
            var response = new Response<Institucion>();
            try {
                var institucion = new Institucion();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IInstitucionServicio service = adapter.Create<IInstitucionServicio>();
                RestResponse<Response<Institucion>> institucionResponse = service.modificarInstitucion(this);
                response = institucionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarInstitucion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Institucion> eliminarInstitucion(int id) {
            var response = new Response<Institucion>();
            try {
                var institucion = new Institucion();
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IInstitucionServicio service = adapter.Create<IInstitucionServicio>();
                RestResponse<Response<Institucion>> institucionResponse = service.eliminarInstitucion(id);
                response = institucionResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarInstitucion, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> inicializarInstituciones() {
            var seleccione = new SelectListItem() {
                Text = "Seleccione Insitutción",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var instituciones = obtenerInstituciones().result.ToList();

            List<SelectListGroup> grupos = instituciones.Select(x => x.distrito.nombre).Distinct().Select(x => new Distrito {
                nombre = x
            }).ToList().ConvertAll(d => {
                return new SelectListGroup() {
                    Name = d.nombre
                };
            });

            List<SelectListItem> institucionesItems = instituciones.ConvertAll(d => {
                return new SelectListItem() {
                    Text = d.nombre,
                    Value = d.idInstitucion.ToString(),
                    Group = grupos.Find(x => x.Name.Equals(d.distrito.nombre)),
                    Selected = false
                };
            });
            institucionesItems.Insert(0, seleccione);

            return institucionesItems;
        }
    }
}