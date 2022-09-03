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
    public interface ITipoUsuarioServicio {
        [Get("api/TipoUsuario")]
        RestResponse<Response<List<TipoUsuario>>> obtenerTiposUsuario();

        [Get("api/TipoUsuario/{id}")]
        RestResponse<Response<TipoUsuario>> obtenerTipoUsuario([Path("id")] int id);

        [Post("api/TipoUsuario")]
        RestResponse<Response<TipoUsuario>> crearTipoUsuario([Body] TipoUsuario tipoUsuario);

        [Put("api/TipoUsuario")]
        RestResponse<Response<TipoUsuario>> modificarTipoUsuario([Body] TipoUsuario tipoUsuario);

        [Delete("api/TipoUsuario/{id}")]
        RestResponse<Response<TipoUsuario>> eliminarTipoUsuario([Path("id")] int id);
    }
}
