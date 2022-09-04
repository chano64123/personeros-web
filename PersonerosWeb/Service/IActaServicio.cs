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
    public interface IActaServicio {
        [Get("api/Acta")]
        RestResponse<Response<List<Acta>>> obtenerActas();

        [Get("api/Acta/{id}")]
        RestResponse<Response<Acta>> obtenerActa([Path("id")] int id);

        [Post("api/Acta")]
        RestResponse<Response<Acta>> crearActa([Body] Acta acta);

        [Put("api/Acta")]
        RestResponse<Response<Acta>> modificarActa([Body] Acta acta);

        [Delete("api/Acta/{id}")]
        RestResponse<Response<Acta>> eliminarActa([Path("id")] int id);
    }
}
