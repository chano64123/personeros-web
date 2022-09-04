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
    public interface IPersonaServicio {
        [Get("api/Persona")]
        RestResponse<Response<List<Persona>>> obtenerPersonas();

        [Get("api/Persona/{id}")]
        RestResponse<Response<Persona>> obtenerPersona([Path("id")] int id);

        [Post("api/Persona")]
        RestResponse<Response<Persona>> crearPersona([Body] Persona persona);

        [Put("api/Persona")]
        RestResponse<Response<Persona>> modificarPersona([Body] Persona persona);

        [Delete("api/Persona/{id}")]
        RestResponse<Response<Persona>> eliminarPersona([Path("id")] int id);
    }
}
