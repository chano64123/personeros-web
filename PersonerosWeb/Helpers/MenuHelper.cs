using PersonerosWeb.Resourses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;

namespace PersonerosWeb.Helpers {
    public class MenuHelper {
        public string controlador { get; set; }
        public string ruta { get; set; }
        public string icono { get; set; }
        public string opcion { get; set; }
        public bool muestra { get; set; }
        public List<int> permisos { get; set; }

        public MenuHelper(string controlador, string ruta, string icono, string opcion, bool muestra, List<int> permisos) {
            this.controlador = controlador;
            this.ruta = ruta;
            this.icono = icono;
            this.opcion = opcion;
            this.muestra = muestra;
            this.permisos = permisos;
        }
    }
}