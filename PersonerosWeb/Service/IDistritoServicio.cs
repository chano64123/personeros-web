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
    public interface IDistritoServicio {
        [Get("api/Distrito")]
        RestResponse<Response<List<Distrito>>> obtenerDistritos();

        [Get("api/Distrito/{id}")]
        RestResponse<Response<Distrito>> obtenerDistrito([Path("id")] int id);

        [Post("api/Distrito")]
        RestResponse<Response<Distrito>> crearDistrito([Body] Distrito distrito);

        [Put("api/Distrito")]
        RestResponse<Response<Distrito>> modificarDistrito([Body] Distrito distrito);

        [Delete("api/Distrito/{id}")]
        RestResponse<Response<Distrito>> eliminarDistrito([Path("id")] int id);
    }
}
