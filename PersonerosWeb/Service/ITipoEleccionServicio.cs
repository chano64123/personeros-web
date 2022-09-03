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
    public interface ITipoEleccionServicio {
        [Get("api/TipoEleccion")]
        RestResponse<Response<List<TipoEleccion>>> obtenerTiposElecciones();

        [Get("api/TipoEleccion/{id}")]
        RestResponse<Response<TipoEleccion>> obtenerTipoEleccion([Path("id")] int id);

        [Post("api/TipoEleccion")]
        RestResponse<Response<TipoEleccion>> crearTipoEleccion([Body] TipoEleccion tipoEleccion);

        [Put("api/TipoEleccion")]
        RestResponse<Response<TipoEleccion>> modificarTipoEleccion([Body] TipoEleccion tipoEleccion);

        [Delete("api/TipoEleccion/{id}")]
        RestResponse<Response<TipoEleccion>> eliminarTipoEleccion([Path("id")] int id);
    }
}
