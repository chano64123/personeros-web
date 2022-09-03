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
    public interface IInstitucionServicio {
        [Get("api/Institucion")]
        RestResponse<Response<List<Institucion>>> obtenerInstituciones();

        [Get("api/Institucion/{id}")]
        RestResponse<Response<Institucion>> obtenerInstitucion([Path("id")] int id);

        [Post("api/Institucion")]
        RestResponse<Response<Institucion>> crearInstitucion([Body] Institucion distrito);

        [Put("api/Institucion")]
        RestResponse<Response<Institucion>> modificarInstitucion([Body] Institucion distrito);

        [Delete("api/Institucion/{id}")]
        RestResponse<Response<Institucion>> eliminarInstitucion([Path("id")] int id);
    }
}
