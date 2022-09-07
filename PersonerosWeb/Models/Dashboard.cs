using PersonerosWeb.Resourses;
using PersonerosWeb.Service;
using RestSharp;
using Retrofit.Net;
using System.Collections.Generic;

namespace PersonerosWeb.Models {
    public class Dashboard {
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public string logo { get; set; }
        public string color { get; set; }
        public string controlador { get; set; }
        public string accion { get; set; }
        public List<int> permiso { get; set; }

        //cantidades
        public int cantidadActas { get; set; }
        public int cantidadDistritos { get; set; }
        public int cantidadInstituciones { get; set; }
        public int cantidadMesas { get; set; }
        public int cantidadPersona { get; set; }
        public int cantidadTiposEleccion { get; set; }
        public int cantidadTiposUsuario { get; set; }
        public int cantidadUsuarios { get; set; }

        //constructores
        public Dashboard() {
        }

        public Dashboard(int cantidad, string nombre, string color, string controlador, string accion, List<int> permiso) {
            this.cantidad = cantidad;
            this.nombre = nombre;
            this.logo = logo;
            this.color = color;
            this.controlador = controlador;
            this.accion = accion;
            this.permiso = permiso;
        }

        //Implementacion de Metodos
        public Dashboard obtenerTotales(Usuario usuario) {
            var totales = new Response<Dashboard>();
            RestAdapter adapter = new RestAdapter(Recursos.baseUrlApi);
            IDashboardServicio service = adapter.Create<IDashboardServicio>();
            RestResponse<Response<Dashboard>> reporteResonse = service.obtenerTotales(usuario.tipoUsuario.identificador);
            totales = reporteResonse.Data;
            return totales.result;
        }
    }
}