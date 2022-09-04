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
    public interface IMesaServicio {
        [Get("api/Mesa")]
        RestResponse<Response<List<Mesa>>> obtenerMesas();

        [Get("api/Mesa/{id}")]
        RestResponse<Response<Mesa>> obtenerMesa([Path("id")] int id);

        [Post("api/Mesa")]
        RestResponse<Response<Mesa>> crearMesa([Body] Mesa mesa);

        [Put("api/Mesa")]
        RestResponse<Response<Mesa>> modificarMesa([Body] Mesa mesa);

        [Delete("api/Mesa/{id}")]
        RestResponse<Response<Mesa>> eliminarMesa([Path("id")] int id);
    }
}
