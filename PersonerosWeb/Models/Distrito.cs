using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PersonerosWeb.Models {
    public class Distrito {
        public int idDistrito { get; set; }
        [Display(Name = "Nombre del Distrito")]
        public string nombre { get; set; }
    }
}