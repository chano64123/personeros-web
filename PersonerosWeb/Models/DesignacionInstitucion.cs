using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonerosWeb.Models {
    public class DesignacionInstitucion {
        public int idDesignacionInstitucion { get; set; }
        public Usuario usuario { get; set; }
        public Institucion institucion { get; set; }
    }
}