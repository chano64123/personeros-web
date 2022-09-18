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
    public interface IUsuarioServicio {
        [Get("api/Usuario")]
        RestResponse<Response<List<Usuario>>> obtenerUsuarios();

        [Get("api/Usuario/{id}")]
        RestResponse<Response<Usuario>> obtenerUsuario([Path("id")] int id);

        [Post("api/Usuario")]
        RestResponse<Response<Usuario>> crearUsuario([Body] Usuario usuario);

        [Put("api/Usuario")]
        RestResponse<Response<Usuario>> modificarUsuario([Body] Usuario usuario);

        [Delete("api/Usuario/{id}")]
        RestResponse<Response<Usuario>> eliminarUsuario([Path("id")] int id);

        [Post("api/Usuario/login/web")]
        RestResponse<Response<Usuario>> loginUsuario([Body] Login login);
    }
}
