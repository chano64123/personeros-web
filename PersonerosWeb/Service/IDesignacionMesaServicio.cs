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
    public interface IDesignacionMesaServicio {
        [Get("api/DesignacionMesa")]
        RestResponse<Response<List<DesignacionMesa>>> obtenerDesignacionesMesas();

        [Get("api/DesignacionMesa/{id}")]
        RestResponse<Response<DesignacionMesa>> obtenerDesignacionMesa([Path("id")] int id);

        [Post("api/DesignacionMesa")]
        RestResponse<Response<List<DesignacionMesa>>> crearDesignacionMesa([Body] List<DesignacionMesa> designacionesMesas);

        [Put("api/DesignacionMesa")]
        RestResponse<Response<List<DesignacionMesa>>> modificarDesignacionMesa([Body] List<DesignacionMesa> DesignacionMesa);

        [Delete("api/DesignacionMesa/{id}")]
        RestResponse<Response<DesignacionMesa>> eliminarDesignacionMesa([Path("id")] int id);

    }
}
