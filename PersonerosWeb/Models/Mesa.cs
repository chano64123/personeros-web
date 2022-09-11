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
    public class Mesa {
        public int idMesa { get; set; }
        [Display(Name = "Institucion")]
        public int idInstitucion { get; set; }
        [Display(Name = "Número del Aula")]
        public string aula { get; set; }
        [Display(Name = "Número de Mesa")]
        public string numero { get; set; }
        [Display(Name = "Cantidad de electores")]
        public int cantidadElectores { get; set; }
        public Institucion institucion { get; set; }

        //Implementacion de Metodos
        public Response<List<Mesa>> obtenerMesas() {
            var response = new Response<List<Mesa>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IMesaServicio service = adapter.Create<IMesaServicio>();
                RestResponse<Response<List<Mesa>>> mesaResponse = service.obtenerMesas();
                response = mesaResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerMesas, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Mesa> obtenerMesa(int id) {
            var response = new Response<Mesa>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IMesaServicio service = adapter.Create<IMesaServicio>();
                RestResponse<Response<Mesa>> mesaResponse = service.obtenerMesa(id);
                response = mesaResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarMesa, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Mesa> crearMesa() {
            var response = new Response<Mesa>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IMesaServicio service = adapter.Create<IMesaServicio>();
                RestResponse<Response<Mesa>> mesaResponse = service.crearMesa(this);
                response = mesaResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearMesa, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Mesa> modificarMesa() {
            var response = new Response<Mesa>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IMesaServicio service = adapter.Create<IMesaServicio>();
                RestResponse<Response<Mesa>> mesaResponse = service.modificarMesa(this);
                response = mesaResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarMesa, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Mesa> eliminarMesa(int id) {
            var response = new Response<Mesa>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IMesaServicio service = adapter.Create<IMesaServicio>();
                RestResponse<Response<Mesa>> mesaResponse = service.eliminarMesa(id);
                response = mesaResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarMesa, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> inicializarMesaes() {
            var seleccione = new SelectListItem() {
                Text = "Seleccione Mesa",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var mesas = obtenerMesas().result.ToList();

            List<SelectListGroup> grupos = mesas.Select(x => x.institucion.nombre).Distinct().Select(x => new Institucion {
                nombre = x
            }).ToList().ConvertAll(d => {
                return new SelectListGroup() {
                    Name = d.nombre
                };
            });

            List<SelectListItem> mesasItems = mesas.ConvertAll(d => {
                return new SelectListItem() {
                    Text = d.numero,
                    Value = d.idMesa.ToString(),
                    Group = grupos.Find(x => x.Name.Equals(d.institucion.nombre)),
                    Selected = false
                };
            });
            //mesasItems.Insert(0, seleccione);

            return mesasItems;
        }
    }
}