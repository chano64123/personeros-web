using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public int cantidadMaximaColegios { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public Persona persona { get; set; }


        //Implementacion de Metodos
        string baseUrl = Recursos.baseUrlApi;
    }
}