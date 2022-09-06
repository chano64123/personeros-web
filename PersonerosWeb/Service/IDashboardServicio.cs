using PersonerosWeb.Models;
using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonerosWeb.Service {
    public interface IDashboardServicio {
        [Get("api/Reporte/totales/{identificadoUsuario}")]
        RestResponse<Response<Dashboard>> obtenerTotales([Path("identificadoUsuario")] int identificadoUsuario);
    }
}
