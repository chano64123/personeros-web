using PersonerosWeb.Resourses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        [Display(Name = "Celular")]
        public string celular { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        //Implementacion de Metodos
        string baseUrl = Recursos.baseUrlApi;
    }
}