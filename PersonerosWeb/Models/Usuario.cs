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
using System.Web.Mvc;

namespace PersonerosWeb.Models {
    public class Usuario {
        public int idUsuario { get; set; }
        [Display(Name = "Tipo de Usuario")]
        public int idTipoUsuario { get; set; }
        [Display(Name = "Persona")]
        public int idPersona { get; set; }
        [Display(Name = "Nombre de Usuario")]
        public string nombreUsuario { get; set; }
        [Display(Name = "Clave")]
        public string clave { get; set; }
        [Display(Name = "Cantidad máxima de mesas")]
        public int cantidadMaximaMesas { get; set; }
        [Display(Name = "Cantidad máxima de instituciones")]
        public int cantidadMaximaInstituciones { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public Persona persona { get; set; }


        //Implementacion de Metodos
        public Response<List<Usuario>> obtenerUsuarios() {
            var response = new Response<List<Usuario>>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IUsuarioServicio service = adapter.Create<IUsuarioServicio>();
                RestResponse<Response<List<Usuario>>> usuarioResponse = service.obtenerUsuarios();
                    response = usuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorObtenerUsuarios, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Usuario> obtenerUsuario(int id) {
            var response = new Response<Usuario>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IUsuarioServicio service = adapter.Create<IUsuarioServicio>();
                RestResponse<Response<Usuario>> usuarioResponse = service.obtenerUsuario(id);
                    response = usuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorBuscarUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Usuario> loginUsuario(Login userLogin) {
            var response = new Response<Usuario>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IUsuarioServicio service = adapter.Create<IUsuarioServicio>();
                RestResponse<Response<Usuario>> usuarioResponse = service.loginUsuario(userLogin);
                    response = usuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorLoginUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Usuario> crearUsuario() {
            var response = new Response<Usuario>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IUsuarioServicio service = adapter.Create<IUsuarioServicio>();
                RestResponse<Response<Usuario>> usuarioResponse = service.crearUsuario(this);
                response = usuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorCrearUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Usuario> modificarUsuario() {
            var response = new Response<Usuario>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IUsuarioServicio service = adapter.Create<IUsuarioServicio>();
                RestResponse<Response<Usuario>> usuarioResponse = service.modificarUsuario(this);
                response = usuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorModificarUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public Response<Usuario> eliminarUsuario(int id) {
            var response = new Response<Usuario>();
            try {
                RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
                IUsuarioServicio service = adapter.Create<IUsuarioServicio>();
                RestResponse<Response<Usuario>> usuarioResponse = service.eliminarUsuario(id);
                response = usuarioResponse.Data;
            } catch(Exception ex) {
                response = response.createErrorResponse(ErrorMessage.errorEliminarUsuario, new List<string> { ex.ToString() });
            }
            return response;
        }

        public List<SelectListItem> inicializarUsuariosPorDistritoResidencia() {
            var seleccione = new SelectListItem() {
                Text = "Seleccione Usuario",
                Value = "",
                Selected = true,
                Disabled = true
            };

            var personas = obtenerUsuarios().result.OrderBy(x => x.persona.distritoResidencia.nombre).ToList();

            List<SelectListGroup> grupos = personas.Select(x => x.persona.distritoResidencia.nombre).Distinct().Select(x => new Distrito {
                nombre = x
            }).ToList().ConvertAll(d => {
                return new SelectListGroup() {
                    Name = d.nombre
                };
            });

            List<SelectListItem> personasItems = personas.ConvertAll(d => {
                return new SelectListItem() {
                    Text = d.persona.nombres + " " + d.persona.apellidoPaterno + " " + d.persona.apellidoMaterno,
                    Value = d.idUsuario.ToString(),
                    Group = grupos.Find(x => x.Name.Equals(d.persona.distritoResidencia.nombre)),
                    Selected = false
                };
            });
            personasItems.Insert(0, seleccione);

            return personasItems;
        }
    }
}